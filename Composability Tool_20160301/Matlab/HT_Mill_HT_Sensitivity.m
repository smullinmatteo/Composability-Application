clear all
format compact

%input variables

%Timer
tic;

%for loop to control the sensivity analysis
n = 200; % number of temperature points
m = 20; % number of volume points
% Array_Energy = zeros(n,6);
Array_Energy = zeros(m,n,20);

for j = 1:m %changing the volume
    for i = 1:n %changing the cooling time

        

%         WP_Thick = 5*(40-i)/40; %in thickness in inches used to calculate oven times
%         WP_Length = 4;
%         WP_Width = 4;
%         WP_Vol_Int = WP_Thick*WP_Length*WP_Width*(0.0254^3);% m3 Initial Volume
        
        %%%%%%%%%%%%%%%%%%%%%%%%%%%
        %Initial Workpiece State
        %WP_Hard = ;%Hardness
    WP_Vol_Int = 0.0009218*j*.1;% m3 Initial Volume
        WP_Den = 7850;% kg/m3 Density Steel
        WP_Mass_Int = WP_Vol_Int*WP_Den; %kg
    WP_Thick = 2*j*.1; %in thickness in inches used to calculate oven times
    
    Array_Energy(j,i,7) = WP_Vol_Int*100*100*100;

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


        %%%%%%%%%%%%%%%%%%%%%%%%%%
        %Recrystalization Annealing

        %Input paramters
        t_Anneal = 60*60*WP_Thick; % sec Annealing Process Time; [ASM handbook on Heat treating, pg.282], Rule of thumb for full austenization is given as 1hr. per inch of part thickness. For model improvement, consider adding this as a rate parameter that could be adjusted.
        Temp_Oven = 840; % C Oven Temperature
        Temp_Room = 28;% C Room Temperature
        Temp_DownFlue = 30;% C Temperature flue downstream (outdoor temperature)
        Temp_Wall = 40;% C Furnace wall temperature

        %Call energy function
        Energy_Anneal = Energy_Oven(t_Anneal,Temp_Oven,Temp_Room,Temp_DownFlue,WP_Mass_Int); %Energy given in megajoules (MJ)
        %disp('MJ');

    Array_Energy(j,i,1) = Energy_Anneal;
    

        %%%%%%%%%%%%%%%%%%%%%%%%%%
        %Workpiece state 2

        %Input parameters

    %     Cooling_Rate = 8.5/(60*60); %C/sec cooling rate for annealing (8.5 deg. C/hour); [pg. 293, ASM heat treat guide]
    %     Cooling_Rate = 49.1/(60*60); %C/sec cooling rate for annealing
    t_Cooling = ((i)*.1)*60*60; %sec cooling time for annealing (16.5 hour); [pg. 293, ASM heat treat guide]
    Cooling_Rate = (Temp_Oven-Temp_Room)/t_Cooling;
        T = Temp_Oven;
    Array_Energy(j,i,6) = ((i)*.1);
        
        %Call hardness function
        WP_Hv =HT_CL_Hard(St_C,St_Si,St_Mn,St_Ni,St_Cr,St_Mo,St_V,Cooling_Rate,T,t_Cooling); %Vickers Hardness,  [Maynier, Dollet, and Bastien 1978], [Trzaska, Jegietto, and Dobzanski 2009]
        %WP_Hv = 240;   %Vickers Hardness    [ASM Handbook] used in place for the hardness model because it was inaccurate
        WP_UTS = -99.8+3.734*WP_Hv; %MPa,       [Pavlina and Van Tyne 2008]
        WP_UTS = WP_UTS*10^6; %Pa

        %WP_Hv should be near 223 HB (from ASM handbook) which is near 240-250 HV.
        %This gives me 97.


        %%%%%%%%%%%%%%%%%%%%%%%%%%
        %Reducing (Chipping)

        %Input Parameters
    WP_Vol_Fin = 0.0004929;% m3 Final Workpiece Volume
%     VMR = 0.0004289*m*.1;% m3 Volume of material removed
    VMR = WP_Vol_Int-WP_Vol_Fin;
        MRR = 0.63*(0.0254^3)*(1/60);% m3/sec material removal rate (0.63 in3/min for 1/2in endmill and 1.47 in3/min for 1in endmill) [Polgar 1995]
        VelCut = 106.68/60; % mpm meters per minute                                                     double check
        ThetaMax = 360;

        %call energy function
        [Energy_Cut,t_Reduce] = Cutting_Energy_Incremental(WP_UTS,VMR,MRR,VelCut,ThetaMax); %N [Groover 2015]

        % t_Reduce;

        %Scale energy up to whole mill
        Percent_Cut_Energy = .15;% percent of energy used for machining, [gutowski]
        Energy_Mill = Energy_Cut/(Percent_Cut_Energy*10^6);  %MJ
        %disp('MJ');

    Array_Energy(j,i,2) = Energy_Mill;

        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        %Workpiece State 3

%     WP_Vol_final = WP_Vol_Int - VMR;% m3 workpiece final volume
        WP_Mass_Final = WP_Vol_Fin*WP_Den; % kg
    WP_Thick = 1*j*.1;%in used to calculate oven times

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

        %call function
        Energy_Hard = Energy_Oven(t_Hard,Temp_Oven,Temp_Room,Temp_DownFlue,WP_Mass_Final); %MJ
        %disp('MJ');

    Array_Energy(j,i,3) = Energy_Hard;

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

        %Call energy function
        Energy_Recover = Energy_Oven(t_Recover,Temp_Oven,Temp_Room,Temp_DownFlue,WP_Mass_Final); %MJ
        %disp('MJ');

    Array_Energy(j,i,4) = Energy_Recover;


        %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        %Final Output
        Energy_Total = Energy_Anneal + Energy_Mill + Energy_Hard + Energy_Recover; %MJ
        %disp('MJ');

    Array_Energy(j,i,5) = Energy_Total;
%     Array_Energy(i,6) = i*.1;
    end
end

% figure
% plot(Array_Energy(20,:,2))
% xlabel('Annealing Cooling Time')
% ylabel('Energy')

%Array_Energy(:,:,6) = cooling rate
%Array_Energy(:,:,7) = volume

figure
mesh( Array_Energy(1,:,6), Array_Energy(:,1,7), Array_Energy(:,:,2))
xlabel('Annealing Cooling Time (hrs)')
ylabel('Volume (cm^3)')
zlabel('Energy (KJ)')

% figure
% mesh(Array_Energy(:,:,2))
% xlabel('Annealing Cooling Time')
% ylabel('Volume')
% zlabel('Energy')

% figure
% mesh(Array_Energy(:,:,5))
% hold on
% mesh(Array_Energy(:,:,4))
% hold on
% mesh(Array_Energy(:,:,3))
% hold on
% mesh(Array_Energy(:,:,2))
% hold on
% mesh(Array_Energy(:,:,1))
% legend('Anneal','Mill','Harden','Temper','Total')
% xlabel('Annealing Cooling Time')
% ylabel('Volume')
% zlabel('Energy')
% zlim([0,1640])
% legend('Mill')

% figure
% plot(Array_Energy)
% legend('Anneal','Mill','Harden','Temper','Total')
% xlabel('i')
% ylabel('Energy')

%timer
toc




