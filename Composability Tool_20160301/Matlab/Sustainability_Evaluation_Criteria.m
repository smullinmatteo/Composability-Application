function [ operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays ] = Sustainability_Evaluation_Criteria(umpPathName,massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4, GWPCH4, RateN2O, GWPN2O,Rland,Rinc,Rrec,Rhaz)
%function [ operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays ] = Sustainability_Evaluation_Criteria(inputVars)
%This function accepts the results of the process and linking model
%parametric equations and then inputs them to determine the final
%sustainability scores
% inputVars
% index = 1;
% massConsumable = inputVars(index);index = index+1;
% costConsumable = inputVars(index);index = index+1;
% powerConsumed = inputVars(index);index = index+1;
% costPower = inputVars(index);index = index+1;
% processTime = inputVars(index);index = index+1;
% wage = inputVars(index);index = index+1;
% illness = inputVars(index);index = index+1;
% injury = inputVars(index);index = index+1;
% illnessDaysLost = inputVars(index);index = index+1;
% injuryDaysLost = inputVars(index);index = index+1;
% waterRate = inputVars(index);index = index+1;
% energyCost = inputVars(index);index = index+1;
% waterCost = inputVars(index);index = index+1;
% RateCO2 = inputVars(index);index = index+1;
% RateCH4 = inputVars(index);index = index+1;
% GWPCH4 = inputVars(index);index = index+1;
% RateN2O = inputVars(index);index = index+1;
% GWPN2O = inputVars(index);index = index+1;
% Rland = inputVars(index);index = index+1;
% Rinc = inputVars(index);index = index+1;
% Rrec = inputVars(index);index = index+1;
% Rhaz = inputVars(index);index = index+1;
%test dummy variables
%powerConsumed = 10;
%processTime = 5;

%% Read Values from File
fid = fopen(umpPathName, 'rt');
data = textscan(fid, '%s %f %s', 'Delimiter',',','HeaderLines',1);
metrics = data{1};
inputVars = data{2};
%ASSUMING THE ORDER OF VARIABLES ARE ALWAYS THE SAME
index = 1;
inputVars(isnan(inputVars)) = 0;
if(massConsumable == 0)
    massConsumable = inputVars(index);
end
index = index+1;
if(costConsumable == 0)
    costConsumable = inputVars(index);
end
index = index+1;
if(powerConsumed == 0)
    powerConsumed = inputVars(index);
end
index = index+1;
if(costPower == 0)
    costPower = inputVars(index);
end
index = index+1;
if(processTime == 0)
    processTime = inputVars(index);
end
index = index+1;
if(wage == 0)
    wage = inputVars(index);
end
index = index+1;
if(illness == 0)
    illness = inputVars(index);
end
index = index+1;
if(injury == 0)
    injury = inputVars(index);
end
index = index+1;
if(illnessDaysLost == 0)
    illnessDaysLost = inputVars(index);
end
index = index+1;
if(injuryDaysLost == 0)
    injuryDaysLost = inputVars(index);
end
index = index+1;
if(waterRate == 0)
    waterRate = inputVars(index);
end
index = index+1;
if(energyCost == 0)
    energyCost = inputVars(index);
end
index = index+1;
if(waterCost == 0)
    waterCost = inputVars(index);
end
index = index+1;
if(RateCO2 == 0)
    RateCO2 = inputVars(index);
end
index = index+1;
if(RateCH4 == 0)
    RateCH4 = inputVars(index);
end
index = index+1;
if(GWPCH4 == 0)
    GWPCH4 = inputVars(index);
end
index = index+1;
if(RateN2O == 0)
    RateN2O = inputVars(index);
end
index = index+1;
if(GWPN2O == 0)
    GWPN2O = inputVars(index);
end
index = index+1;
if(Rland == 0)
    Rland = inputVars(index);
end
index = index+1;
if(Rinc == 0)
    Rinc = inputVars(index);
end
index = index+1;
if(Rrec == 0)
    Rrec = inputVars(index);
end
index = index+1;
if(Rhaz == 0)
    Rhaz = inputVars(index);
end
index = index+1;

%% Compute the equations
energyUse= powerConsumed * processTime; %(kWh)
waterUse = waterRate * processTime; %L
averageWage = wage * processTime; %($/hr)



operatingCost = massConsumable * costConsumable +energyUse*energyCost +processTime * averageWage + waterUse*waterCost;
GHGEmissions = energyUse *(RateCO2 + RateCH4 * GWPCH4 + RateN2O * GWPN2O); %(kg CO2 eq.)
totalWaste = (Rland+Rinc+Rrec+Rhaz) *processTime; %(kg)
lostWorkDays = illness * illnessDaysLost + injury * injuryDaysLost; %(No.)


end

