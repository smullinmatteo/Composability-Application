function [ Energy_Total ] = Energy_Oven( Time_Process,Temp_Oven,Temp_Room,Temp_Flue,WP_Mass )
%Summary of this function goes here
% Energy Performance assessment of Furnaces
% National Certification Examination for Energy Managers and Energy
% Auditors
% Guide Book 4, Energy Performance Assessment for Equipment and Utility
% Systems

% Energy Management Series
% Process Furnaces, Dryers, and Kilns
% Department of Mines and Resources Canada



%Input Parameters
Coefficient_OvenWall = 0.36 ; %W/(m*K)      [From Morgan Thermal Ceramics]
Area_WallSurface = 8; %m2
Thickness_Wall = 0.1524 ; %m
WP_Coefficient_HeatCapacity = 502; % J/(kg*K)
%Mass_Oven_Air = ;
Coefficient_FlueGasSpecificHeat = 1004.16; %J/(kg*K)           NW Natural 0.044lb/ft3
Density_FlueGas = 1.23; %kg/m3
FlowRate_FlueGas = 235*0.028316846592; %m3/min;      conversion from ft3 to m3
Percent_OxygenFlueGas = 8; % %
Mass_Stoichometric_Air = 11*0.0283168*1.225/(1*0.023168*0.66); %kg/kg CH4
Mass_CH4 = 1 ; %kg/kf CH4
% Enthalpy_CH4 = 45000;% kJ/kg Enthalpy of Combustion Natural Gas
% Percent_Uncombust = 3;% % Percent Uncombusted Combustibles
%FlueGas_AvailableHeat = 0.75;% user defined efficiency

%Conversion
Temp_Oven = Temp_Oven + 273;
Temp_Flue = Temp_Flue + 273;
Temp_Room = Temp_Room + 273;
% Temp_Wall = Temp_Wall + 273;


% % calculation of Wall temperature
% Boltzman = 5.6703*10^-8; %W/m2K4
% Emissivity = .59; %of stainless steel

% %quadratic solution to 4th degree aX^4+bX^3+cX^2+dX+e
% a = 1;
% b = 4*Temp_Room;
% c = 6*(Temp_Room^2);
% d = -4*(Temp_Room^3)+(Coefficient_OvenWall/(Thickness_Wall*Boltzman);
% e = (Temp_Room^4)+Temp_Oven*Coefficient_OvenWall/(Thickness_Wall*Boltzman*Emissivity);
% 
% p = (8*a*c-3*(b^2))/(8*(a^2));
% q = ((b^3)-4*a*b*c+8*(a^2)*d)/(8*(a^3));
% 
% G0 = (c^2)-3*b*d+12*a*e;
% G1 = (


%Finding roots for the convective and radiative heat transfer. Assumed that
%the heat transfer for both are equal, thus the root is multiplied by 2
%for a solution. The first root finder is for the wall temperature. Root 
%outputs will give two imaginary and two real roots.  This is used to 
%verify that a real value is used. The second finds the heat transfer. Both
%roots are checked to find the combination of real roots in the for loop.

%Inputs to radiation and convection.
Boltzman = 5.6703*10^-8;    %W/m2K4
Emissivity = .59;           %of stainless steel
Coefficient_Air = 300.19*1000 ;  %h, J/kg

%Wall Temperature
ra = Emissivity*Boltzman/Coefficient_Air;
rb = 0;
rc = 0;
rd = -1;
re = (-Emissivity*Boltzman/Coefficient_Air)*(Temp_Room^4)+Temp_Room;

rp = [ra rb rc rd re];
rr = roots(rp);

%Heat Transfer
rf = 1;
rg = -4*Temp_Room/(Coefficient_Air*Area_WallSurface);
rh = 6*(Temp_Room^2)/(Coefficient_Air*Area_WallSurface);
ri = (-4*(Temp_Room^3)/(Coefficient_Air*Area_WallSurface)+1/(Emissivity*Boltzman*Area_WallSurface));
rj = 0;

rq = [rf rg rh ri rj];
rs = roots(rq);

%Selects the real root.
for rz = 1:4
    rx = isreal(rr(rz));
    ry = isreal(rs(rz));
    if rx == 1 & ry == 1 
        if rs(rz) < 0
            rs(rz) = -rs(rz);
        end
        Heat_Rad_Conv = 2*rs(rz); %J/sec
    else
        Heat_Rad_Conv = 0; %J/sec
    end
end



%Calculations

Excess_Oxygen = (Percent_OxygenFlueGas/(21-Percent_OxygenFlueGas))*100;   %percent

Mass_Air = Mass_Stoichometric_Air*(1+(Excess_Oxygen/100));                %kg

Time_MassFlow = (Mass_Air+Mass_CH4)/(Density_FlueGas*(FlowRate_FlueGas)/60); %sec

Heat_FlueGasLoss = (Temp_Oven-Temp_Flue)*(Mass_Air+Mass_CH4)...
                    *Coefficient_FlueGasSpecificHeat*(1/Time_MassFlow);%...
                    %*(1-FlueGas_AvailableHeat);                           %J/sec
                
Heat_OvenWallLoss = Coefficient_OvenWall*Area_WallSurface...
                    *(Temp_Oven-Temp_Room)/Thickness_Wall;              %J/sec

Energy_Part_Carryoff = WP_Coefficient_HeatCapacity*WP_Mass...
                      *(Temp_Oven-Temp_Room);                       %J
                  
                                   
Energy_Total = (((Heat_OvenWallLoss+Heat_FlueGasLoss+Heat_Rad_Conv)...
                *Time_Process)+Energy_Part_Carryoff)...
                /(1000*1000);                                  %MJ
            
            
%Mass_CH4Burned = (Energy_Total/Percent_Uncombust)*(1/Enthalpy_CH4)
            
end

