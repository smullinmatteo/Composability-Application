function [ Hardness_Vickers ] = HT_CL_Hard( St_C,St_Si,St_Mn,St_Ni,St_Cr,St_Mo,St_V,Vr,T,t )
%The Creusot-Loire System
%[Maynier, Dollet, and Bastien 1978], [Trzaska, Jegietto, and Dobzanski 2009]

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%Creusot-Loire System

%The function is somehow broken, the pearlite is 97 when it should be 240
%Maybe incorrect H value. Maybe cooling rate comparison not correct.
%Verify equations against those from Maynier

%input parameters
%T = ;% deg K
n = 2.3;% napierian lograithm of 10
R = 8.3144621; % J/(mol*K) gas constant
H = 460.55*10^3;% J/mol
%t = ;% time
to = 60*60;% unit of time = 1 hr

%some parameter
Pa = ((1/T)-(n*R/H)*(log(t/to)))^-1;

%Cooling Velocities in logrithms C/hr
Log_Vm = 9.81-(4.62*St_C+1.05*St_Mn+0.5*St_Cr+0.66*St_Mo+0.54*St_Ni+0.00183*Pa);
Log_Vm90 = 8.76-(4.04*St_C+0.96*St_Mn+0.58*St_Cr+0.97*St_Mo+0.49*St_Ni+0.001*Pa);
Log_Vm50 = 8.50-(4.13*St_C+0.86*St_Mn+0.41*St_Cr+0.94*St_Mo+0.57*St_Ni+0.0012*Pa);
Log_Vb = 10.17-(3.80*St_C+1.07*St_Mn+0.57*St_Cr+1.58*St_Mo+0.70*St_Ni+0.0032*Pa);
Log_Vb90 = 10.55-(3.65*St_C+1.08*St_Mn+0.61*St_Cr+1.49*St_Mo+0.77*St_Ni+0.0032*Pa);
Log_Vb50 = 8.74-(2.23*St_C+0.86*St_Mn+0.59*St_Cr+1.60*St_Mo+0.56*St_Ni+0.0032*Pa);
Log_Vfp = 6.36-(0.43*St_C+0.49*St_Mn+0.26*St_Cr+0.38*St_Mo+(2*St_Mo^.5)+0.78*St_Ni+0.0019*Pa);
Log_Vfp90 = 7.51-(1.38*St_C+0.35*St_Mn+0.11*St_Cr+2.31*St_Mo+0.93*St_Ni+0.0033*Pa);

%remove logrithims & convert to C/sec
Vm = (10^Log_Vm)/(60*60);
Vm90 = (10^Log_Vm90)/(60*60);
Vm50 = (10^Log_Vm50)/(60*60);
Vb = (10^Log_Vb)/(60*60);
Vb90 = (10^Log_Vb90)/(60*60);
Vb50 = (10^Log_Vb50)/(60*60);
Vfp = (10^Log_Vfp)/(60*60);
Vfp90 = (10^Log_Vfp90)/(60*60);


%solve for parameters from cooling rate. The cooling rate is checked
%against the critical cooling rate values and then the percent composition
%is interpolated.

if Vr>=Vm %incorrectly comparing time to cooling rate??? These should both be cooling rates.
    Xm = 100;
    Xb = 0;
    Xf = 0;
    Xp = 0;
elseif Vr>=Vm90
    Xm = (Vr-Vm90)*(100-90)*(1/(Vm-Vm90))+90;
    Xb = 100-Xm;
    Xf = 0;
    Xp = 0;
elseif Vr>=Vm50
    Xm = (Vr-Vm50)*(90-50)*(1/(Vm90-Vm50))+50;
    Xb = 100-Xm;
    Xf = 0;
    Xp = 0;
elseif Vr>=Vb
    Xm = (Vr-Vb)*(50)*(1/(Vm50-Vb));
    Xb = 100-Xm;
    Xf = 0;
    Xp = 0;
elseif Vr>=Vb90
    Xm = 0;
    Xb = (Vr-Vb90)*(100-90)*(1/(Vb-Vb90))+90;
    Xf = 100-Xb;
    Xp = 0;
elseif Vr>=Vb50
    Xm = 0;
    Xb = (Vr-Vb50)*(90-50)*(1/(Vb90-Vb50))+50;
    Xf = 100-Xb;
    Xp = 0;
else
    Xm = 0;
    Xb = 0;
    Xf = 100;
    Xp = 0;
end    


    Xm=Xm/100;
    Xb=Xb/100;
    Xf=Xf/100;
    Xp=Xp/100;

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%Hardness model

Hvm = 127+949*St_C+27*St_Si*11*St_Mn+8*St_Ni+16*St_Cr+21*log(Vr);

Hvb = -323+185*St_C+330*St_Si+153*St_Mn+65*St_Ni+144*St_Cr+191*St_Mo+...
      (89+53*St_C-55*St_Si-22*St_Mn-10*St_Ni-20*St_Cr-33*St_Mo)*log(Vr);

Hvfp = 42+223*St_C+53*St_Si+30*St_Mn+12.6*St_Ni+7*St_Cr+19*St_Mo+...
      (10-19*St_Si+4*St_Ni+8*St_Cr+130*St_V)*log(Vr);

Hardness_Vickers = Xm*Hvm+Xb*Hvb+(Xf+Xp)*Hvfp;



end

