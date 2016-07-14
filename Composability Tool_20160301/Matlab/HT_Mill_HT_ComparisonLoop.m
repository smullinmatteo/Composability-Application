%clear all
format compact

%input variables


n = 40;
% Array_Anneal = zeros(1,num);
% Array_Mill = zeros(1,num);
% Array_Hard = zeros(1,num);
% Array_Temp = zeros(1,num);
% Array_Total = zeros(1,num);
Array_Energy = zeros(n,5);

 for i=1:n

WP_Thick = 5*(40-i)/40; %in thickness in inches used to calculate oven times
WP_Length = 4;
WP_Width = 4;


    %%%%%%%%%%%%%%%%%%%%%%%%%%%
    %Initial Workpiece State
    %WP_Hard = ;%Hardness
%    WP_Vol_Int = 0.0009218;% m3 Initial Volume
    
WP_Vol_Int = WP_Thick*WP_Length*WP_Width*(0.0254^3);% m3 Initial Volume
    
    WP_Den = 7850;% kg/m3 Density Steel
    WP_Mass_Int = WP_Vol_Int*WP_Den; %kg
 
    %weight percent steel composition; 4340; assumed highest percent
    %composition
    St_C = 0.43;
    St_Si = 0.3;
    St_Mn = 0.8;
    St_Ni = 2;
    St_Cr = 0.9;
    St_Mo = 0.3;
    St_V = 0;
    St_Cu = 0;
    ST_Fe= 95.27;
%     ST_Fe = 100-(St_C+St_Si+St_Mn+St_Ni+St_Cr+St_Mo+St_V+St_Cu);


    %%%%%%%%%%%%%%%%%%%%%%%%%%
    %Recrystalization Annealing

    %Input paramters
    t_Anneal = 60*60*WP_Thick; % sec Annealing Process Time; [ASM handbook on Heat treating, pg.282], Rule of thumb for full austenization is given as 1hr. per inch of part thickness. For model improvement, consider adding this as a rate parameter that could be adjusted.
     Temp_Oven = 840; % C Oven Temperature
    Temp_Room = 28;% C Room Temperature
    Temp_DownFlue = 30;% C Temperature flue downstream (outdoor temperature)
    Temp_Wall = 40;% C Furnace wall temperature

% Temp_Oven = 1000*(40-i)/40;    
    
    %Call energy function
    Energy_Anneal = Energy_Oven(t_Anneal,Temp_Oven,Temp_Room,Temp_DownFlue,WP_Mass_Int); %Energy given in megajoules (MJ)
%     disp('MJ');

Array_Energy(i,1) = Energy_Anneal;



    %%%%%%%%%%%%%%%%%%%%%%%%%%
    %Workpiece state 2

    %Input parameters
    Cooling_Rate = 8.5/(60*60); %C/sec cooling rate for annealing (8.5 deg. C/hour); [pg. 293, ASM heat treat guide]
    t_Cooling = 16.5*60*60; %sec cooling time for annealing (16.5 hour); [pg. 293, ASM heat treat guide]
    T = Temp_Oven;


    %Call hardness function
%    WP_Hv =HT_CL_Hard(St_C,St_Si,St_Mn,St_Ni,St_Cr,St_Mo,St_V,Cooling_Rate,T,t_Cooling); %Vickers Hardness,  [Maynier, Dollet, and Bastien 1978], [Trzaska, Jegietto, and Dobzanski 2009]
    WP_Hv = 240;   %Vickers Hardness    [ASM Handbook] used in place for the hardness model because it was inaccurate
    WP_UTS = -99.8+3.734*WP_Hv; %MPa,       [Pavlina and Van Tyne 2008]
    WP_UTS = WP_UTS*10^6; %Pa

    %WP_Hv should be near 223 HB (from ASM handbook) which is near 240-250 HV.
    %This gives me 97.


    %%%%%%%%%%%%%%%%%%%%%%%%%%
    %Reducing (Chipping)

    %Input Parameters
    VMR = 0.0004289;% m3 Volume of material removed
    MRR = 1.63*(0.0254^3)*(1/60);% m3/sec material removal rate (0.63 in3/min for 1/2in endmill and 1.47 in3/min for 1in endmill) [Polgar 1995]
    VelCut = 106.68/60; % mpm meters per minute                                                     double check

VMR = WP_Vol_Int*.8;
    
% if i<39
% MRR = 10*(0.0254^3)*(1/60)*(40-i)/40;    
% else
% MRR = 10*(0.0254^3)*(1/60)*(40-i/2)/40;      
% end

    ThetaMax = 360;

    %call energy function
    [Energy_Cut,t_Reduce] = Cutting_Energy_Incremental(WP_UTS,VMR,MRR,VelCut,ThetaMax); %N [Groover 2015]

    % t_Reduce;

    %Scale energy up to whole mill
    Percent_Cut_Energy = .15;% percent of energy used for machining, [gutowski]
    Energy_Mill = Energy_Cut/(Percent_Cut_Energy*10^6)  %MJ
    disp('MJ');


Array_Energy(i,2) = Energy_Mill;



    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %Workpiece State 3

    WP_Vol_final = WP_Vol_Int - VMR;% m3 workpiece final volume
    WP_Mass_Final = WP_Vol_final*WP_Den; % kg
%     WP_Thick = 1;%in used to calculate oven times

WP_Thick = WP_Thick*.4
    
    %if the next step were to anneal 
    %if you were anealing the part again instead of hardening, then the entire
    %part does not have to austenized and could be just the surface hardness
    %possibly add a model for calculating the surface hardness thickness




    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %Through hardening

    %Input parameters
    t_Hard =60*60*WP_Thick; % sec time through hardening; [ASM Handbook on Heat Treating pg.282] for calculation 1hr*#in thick
    Temp_Oven = 900;% C Oven Temperature
    Temp_Room = 28;% C Room Temperature
    Temp_DownFlue = 30;% C Temperature flue downstream

    
% Temp_Oven = 1000*(40-i)/40;    

    %call function
    Energy_Hard = Energy_Oven(t_Hard,Temp_Oven,Temp_Room,Temp_DownFlue,WP_Mass_Final); %MJ
%     disp('MJ');



Array_Energy(i,3) = Energy_Hard;


    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %Workpiece State 4

    %Input parameters
    Temp_Quench = 30; %temperature of the quenchant, choose water, oil, etc.
    % Cooling_Rate = 8.5/(60*60); %C/sec cooling rate for annealing;
    t_Cooling = 10; %Sec cooling time for annealing; look up cooling rate
    Cooling_Rate = (Temp_Oven-Temp_Quench)/t_Cooling; %C/sec cooling rate calculation
    T = Temp_Oven;


    %Call hardness function
    WP_Hv = HT_CL_Hard(St_C,St_Si,St_Mn,St_Ni,St_Cr,St_Mo,St_V,Cooling_Rate,T,t_Cooling);  %Victers Hardness, [Maynier, Dollet, and Bastien 1978], [Trzaska, Jegietto, and Dobzanski 2009]
    WP_UTS = -99.8+3.734*WP_Hv; %MPa,       [Pavlina and Van Tyne 2008]






    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %Workpiece Final State


    % % [Bag et al. 1999] Inter Critical Temperature from WP_Yield Strength
    % %Input parameters
    % WP_Hard_Fin = 282;% victers diamond pyrmid, final hardness
    % 
    % %Call Stength function
    % WP_YS_Fin = -90.7+2.876*WP_Hard_Fin;
    % 
    % %mean free path martensite
    % MFPM = 10^((2.8565-log10(WP_YS_Fin))/-0.25441);
    % 
    % %volume fraction of martensite
    % VFM = ((1.03-MFPM)/0.045)^(1/-2.87); %imaginary
    % 
    % %intercritical temperature
    % Temp_IC = log(VFM/0.0052)/0.0058


    %[Tavares, Pedroza, Teodosio, Gurova 1999]
    WP_YS_Fin = 300; %MPa

    Temp_IC = (551-WP_YS_Fin)/(0.454); %C




    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %Recovery annealing

    %Input parameters
    t_Recover = 60*60*.5;% sec time through hardening
     Temp_Oven = Temp_IC; % C Oven Temperature
    Temp_Room = 28;% C Room Temperature
    Temp_DownFlue = 30;% C Temperature flue downstream

    
% Temp_Oven = 1000*(40-i)/40;    
    
    
    %Call energy function
    Energy_Recover = Energy_Oven(t_Recover,Temp_Oven,Temp_Room,Temp_DownFlue,WP_Mass_Final); %MJ
%     disp('MJ');


Array_Energy(i,4) = Energy_Recover;


    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    %Final Output
    Energy_Total = Energy_Anneal + Energy_Mill + Energy_Hard + Energy_Recover; %MJ
%     disp('MJ');

Array_Energy(i,5) = Energy_Total;
i
 end
 

figure
plot(Array_Energy)
legend('Anneal','Mill','Harden','Temper','Total')
xlabel('i')
ylabel('energy')






