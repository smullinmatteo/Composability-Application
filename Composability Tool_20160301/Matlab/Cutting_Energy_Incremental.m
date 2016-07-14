function [ Energy_Cut,t_Reduce ] = Cutting_Energy_Incremental( WP_UTS,VMR,MRR,VelCut,ThetaMax)
%Integrate Cutting Forces to determine the total cutting force for a given
%volume, MMR, UTS, and Cutting Velocity
%   [Groover 2015]


%Tool input parameters
Nt = 2;             %number of teeth
Dia_Tool = 1*0.0254; %m tool diameter in meters used from assumption of polgar
Apt = Dia_Tool*.02/Nt; %m/tooth
%Ap_Rev = Apt*Nt; %m/rev advance per revolution
Helical_Angle = 20; %degrees; inclination angle of the cutting tool; try 20-40; page 14 http://www.guhring.com/documents/catalog/endmills/endmills.pdf
alpha = 40; %degrees; Rake_Angle
r = .5; %unitless; chip thickness ratio
% to = 0.000127; %m depth of cut

%Machine input parameters
VelCut = VelCut*60; %mpm meters per minute
RPM = VelCut/(3.141*Dia_Tool); %rev/min


%Calculate number of revolutions to integrate for the machining operation
Vol_Rev = MRR/(RPM/60); %m3/rev volume removed per revolution.
Revs = VMR/Vol_Rev; %total number of revolutions the tool will take


%calculate the constants for force calculation
FeedPMin = Apt*RPM*Nt;   %feed per minute (meters/min)
Timerev = 1/(RPM/60); %sec/rev time of revolution in seconds

%depth of cut to integrate over
zmax = .5*Dia_Tool; % depth of cut meters

%Step size for z integration
zstep = (2*pi()*Dia_Tool*.5)/(360*tand(Helical_Angle));

%have to calculate number of steps for for loop to work; could use while
%loop as alternative
zstepnumber = zmax/zstep;

%step size for angular integration
thetastep = (zstep*360*tand(Helical_Angle))/(2*pi()*Dia_Tool*.5);

%       a trigger for identifying the exit roation angle
bool = 0;
thetaExit = 360;

% When stp = 1 Elapsed time is 26128.610153 seconds.
% When stp = 100 Elapsed time is 405.800479 seconds.
%         M = zeros(1:num);
M = 0;
L = 0;
ctr = 1;
        
        %declare matricies so that they can be filled in later.
         J = zeros(round(ThetaMax),round(zstepnumber));
         K = zeros(round(ThetaMax),round(zstepnumber));
         JA  = zeros(round(ThetaMax),round(zstepnumber));
         JK  = zeros(round(ThetaMax),round(zstepnumber));
         
        %Integrate for the cutter angle
        for i=1:thetastep:ThetaMax %i is the angle of the cutter

                %Tricks code into integrating for the rotation of two
                %tooth cutting mill. Would have to change for more or less
%                 %teeth.
                theta = i;
                thetaNorm = (theta/360)-(floor(theta/360));
                if thetaNorm > 0.5;
                    thetaNorm = thetaNorm-0.5;
                elseif thetaNorm == 0;  
                    thetaNorm = 1;
                end
                theta = 360*thetaNorm;
                
%                 boolexit = 0; %for exiting if no cutters are engaged.
                row = 1; %for tracking the row
                
                %Integrate for the z direction
                for zint = 0:1:zstepnumber
                    
                    %identifies where the current zstep is in the rotation
                    thetaInt = theta - thetastep*(zint);
                    
                    %if the z increment is not engaged yet then exit the
                    %loop early
                    if thetaInt < theta
%                        boolexit = 1
                       break
                    end
                    
                    %Instantious Cutting Force Equations for X and Y, for a known UTS and
                            %spindle position
                            %Reducing (Chipping)
                                                        
                            %avoid divide by zero in r calculation
                            if thetaInt == 180
                                thetaInt = thetaInt - 1;
                            elseif thetaInt == 360
                                thetaInt = thetaInt - 1;
                            end
                            
                            %Chip Thickness calculation
                            to = Apt*sind(thetaInt); %m
                            
                            % %calculate shear angle and friction angle
                            phi = atand(r*cosd(alpha)/(1-r*sind(alpha)));
                            beta = 90+alpha-2*phi;

                            %calculate shear zone area, dependent on cutter orientation and engagement
                            % As = to*width/sin(phi); %m^2
                            ShearWidthMax = zmax/cosd(Helical_Angle); %maximum width of shear
                            % hypotenuse of shear triangle=Arc length  / sin(helical angle of cutter)
                            Width = (2*pi()*(Dia_Tool/2)*thetastep/360)/sind(Helical_Angle); %current width of shear
                            
                            WidthCheck = (2*pi()*(Dia_Tool/2)*theta/360)/sind(Helical_Angle); %used to track entire cutter position relative to chip height
                            
                            if thetaInt > thetaExit %if the incremental cutter has exited the engagement arc, then zero Area
%                                 Width = (2*pi()*(Dia_Tool/2)*(360-theta)/360)/sind(Helical_Angle); %current width of shear
%                                 As = to*Width/sind(phi);
                                As = 0;
                            elseif WidthCheck > ShearWidthMax %used to determine the exiting angle
                                As = to*Width/sind(phi);
                                if bool == 0; %to triger the exit of the cutter
                                    bool = 1;
                                    thetaExit = 360-thetaInt; %is exit correct? 360? if tooth 1 vs 2?
                                end
                            else
                                As = to*Width/sind(phi);
                            end


                            %calculate cutting force with known UTS (which corresponds to shear stress
                            %of the material)
                            dFc = WP_UTS*As*cosd(beta-alpha)/(sind(phi)*cosd(phi+beta-alpha)); %Newtons
                            dFt = WP_UTS*As*sind(beta-alpha)/(sind(phi)*cosd(phi+beta-alpha)); %Newtons

                            %Add source
                            dFx = -dFc*cosd(thetaInt)-dFt*sind(thetaInt); %Newtons
                            dFy = dFc*sind(thetaInt)-dFt*cosd(thetaInt); %Newtons


                    %cutting forces in X
                    J(ctr,row) = Nt*thetastep*(FeedPMin/60)*Timerev*dFx;  %Newtons*m/rev = J/rev
                    M = M + J(ctr,row);
                    %cutting forces in Y
                    K(ctr,row) = Nt*thetastep*(FeedPMin/60)*Timerev*dFy; %Newtons*m/rev = J/rev
                    L = L + K(ctr,row);
                    %matrix for shear area
                    JA(ctr,row) = As;
                    %matrix for sum of forces in X and Y, used for graphing
                    JK(ctr,row) = J(ctr,row)+K(ctr,row);
                    
                    row = row+1;
                end
                
                ctr = ctr + 1;

%                 %Wait Bar
%                 perc = i/num;
%                 waitbar(i/num,Wt_Br,sprintf('%d%% Waiting',perc))
%                 
%             end
        end

JS2 = sum(J,2);
KS2 = sum(K,2);
JKS2 = sum(JK,2);
JAS2 = sum(JA,2);

%this figure plots the cutting force and shear plane area. It is commented
%out so that it doesn't popup a bunch during the sensitivity analysis.

% figure
% subplot(2,1,1)
% plot(JS2); hold on;
% plot(KS2); hold on;
% plot(JKS2)
% title('Joules per Revolution')
% legend('X','Y','X+Y')
% subplot(2,1,2)
% % plot(JA1,'color','y'); hold on;
% plot(JAS2)
% title('Shear Area')
% legend('Area')
% %legend('X','Y','X+Y','Area1','Area2')

     
% % MaX = max(J)
% MaY = max(K)
% MaXY = max(JK)
% 
% MiX = min(J)
% MiY = min(K)
% MiXY = min(JK)

%multiply the 
Energy_X = M*Revs;
Energy_Y = L*Revs;


Energy_Cut = (Energy_X+Energy_Y);  %Joules
t_Reduce = Revs*Timerev*(360/ThetaMax);


% close(Wt_Br);
end

