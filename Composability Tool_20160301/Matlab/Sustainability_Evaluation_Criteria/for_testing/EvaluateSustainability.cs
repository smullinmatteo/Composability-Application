/*
* MATLAB Compiler: 6.2 (R2016a)
* Date: Tue Jul 12 17:06:30 2016
* Arguments: "-B" "macro_default" "-W"
* "dotnet:Sustainability_Evaluation_Criteria,EvaluateSustainability,0.0,private" "-T"
* "link:lib" "-d" "C:\Users\Zara\Documents\Visual Studio 2015\Projects\Composability
* Tool_20160301\Composability Tool_20160301\Composability
* Tool_20160301\Matlab\Sustainability_Evaluation_Criteria\for_testing" "-v"
* "class{EvaluateSustainability:C:\Users\Zara\Documents\Visual Studio
* 2015\Projects\Composability Tool_20160301\Composability Tool_20160301\Composability
* Tool_20160301\Matlab\Sustainability_Evaluation_Criteria.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace Sustainability_Evaluation_Criteria
{

  /// <summary>
  /// The EvaluateSustainability class provides a CLS compliant, MWArray interface to the
  /// MATLAB functions contained in the files:
  /// <newpara></newpara>
  /// C:\Users\Zara\Documents\Visual Studio 2015\Projects\Composability
  /// Tool_20160301\Composability Tool_20160301\Composability
  /// Tool_20160301\Matlab\Sustainability_Evaluation_Criteria.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class EvaluateSustainability : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB Runtime instance.
    /// </summary>
    static EvaluateSustainability()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

          int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "Sustainability_Evaluation_Criteria.ctf";

          Stream embeddedCtfStream = null;

          String[] resourceStrings = assembly.GetManifestResourceNames();

          foreach (String name in resourceStrings)
          {
            if (name.Contains(ctfFileName))
            {
              embeddedCtfStream = assembly.GetManifestResourceStream(name);
              break;
            }
          }
          mcr= new MWMCR("",
                         ctfFilePath, embeddedCtfStream, true);
        }
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the EvaluateSustainability class.
    /// </summary>
    public EvaluateSustainability()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~EvaluateSustainability()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a single output, 0-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria()
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", new MWArray[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName);
    }


    /// <summary>
    /// Provides a single output, 2-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable);
    }


    /// <summary>
    /// Provides a single output, 3-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable);
    }


    /// <summary>
    /// Provides a single output, 4-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed);
    }


    /// <summary>
    /// Provides a single output, 5-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower);
    }


    /// <summary>
    /// Provides a single output, 6-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime);
    }


    /// <summary>
    /// Provides a single output, 7-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage);
    }


    /// <summary>
    /// Provides a single output, 8-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness);
    }


    /// <summary>
    /// Provides a single output, 9-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness, MWArray injury)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury);
    }


    /// <summary>
    /// Provides a single output, 10-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness, MWArray injury, MWArray 
                                                illnessDaysLost)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost);
    }


    /// <summary>
    /// Provides a single output, 11-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness, MWArray injury, MWArray 
                                                illnessDaysLost, MWArray injuryDaysLost)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost);
    }


    /// <summary>
    /// Provides a single output, 12-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness, MWArray injury, MWArray 
                                                illnessDaysLost, MWArray injuryDaysLost, 
                                                MWArray waterRate)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate);
    }


    /// <summary>
    /// Provides a single output, 13-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness, MWArray injury, MWArray 
                                                illnessDaysLost, MWArray injuryDaysLost, 
                                                MWArray waterRate, MWArray energyCost)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost);
    }


    /// <summary>
    /// Provides a single output, 14-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness, MWArray injury, MWArray 
                                                illnessDaysLost, MWArray injuryDaysLost, 
                                                MWArray waterRate, MWArray energyCost, 
                                                MWArray waterCost)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost);
    }


    /// <summary>
    /// Provides a single output, 15-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness, MWArray injury, MWArray 
                                                illnessDaysLost, MWArray injuryDaysLost, 
                                                MWArray waterRate, MWArray energyCost, 
                                                MWArray waterCost, MWArray RateCO2)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2);
    }


    /// <summary>
    /// Provides a single output, 16-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness, MWArray injury, MWArray 
                                                illnessDaysLost, MWArray injuryDaysLost, 
                                                MWArray waterRate, MWArray energyCost, 
                                                MWArray waterCost, MWArray RateCO2, 
                                                MWArray RateCH4)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4);
    }


    /// <summary>
    /// Provides a single output, 17-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <param name="GWPCH4">Input argument #17</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness, MWArray injury, MWArray 
                                                illnessDaysLost, MWArray injuryDaysLost, 
                                                MWArray waterRate, MWArray energyCost, 
                                                MWArray waterCost, MWArray RateCO2, 
                                                MWArray RateCH4, MWArray GWPCH4)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4, GWPCH4);
    }


    /// <summary>
    /// Provides a single output, 18-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <param name="GWPCH4">Input argument #17</param>
    /// <param name="RateN2O">Input argument #18</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness, MWArray injury, MWArray 
                                                illnessDaysLost, MWArray injuryDaysLost, 
                                                MWArray waterRate, MWArray energyCost, 
                                                MWArray waterCost, MWArray RateCO2, 
                                                MWArray RateCH4, MWArray GWPCH4, MWArray 
                                                RateN2O)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4, GWPCH4, RateN2O);
    }


    /// <summary>
    /// Provides a single output, 19-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <param name="GWPCH4">Input argument #17</param>
    /// <param name="RateN2O">Input argument #18</param>
    /// <param name="GWPN2O">Input argument #19</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness, MWArray injury, MWArray 
                                                illnessDaysLost, MWArray injuryDaysLost, 
                                                MWArray waterRate, MWArray energyCost, 
                                                MWArray waterCost, MWArray RateCO2, 
                                                MWArray RateCH4, MWArray GWPCH4, MWArray 
                                                RateN2O, MWArray GWPN2O)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4, GWPCH4, RateN2O, GWPN2O);
    }


    /// <summary>
    /// Provides a single output, 20-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <param name="GWPCH4">Input argument #17</param>
    /// <param name="RateN2O">Input argument #18</param>
    /// <param name="GWPN2O">Input argument #19</param>
    /// <param name="Rland">Input argument #20</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness, MWArray injury, MWArray 
                                                illnessDaysLost, MWArray injuryDaysLost, 
                                                MWArray waterRate, MWArray energyCost, 
                                                MWArray waterCost, MWArray RateCO2, 
                                                MWArray RateCH4, MWArray GWPCH4, MWArray 
                                                RateN2O, MWArray GWPN2O, MWArray Rland)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4, GWPCH4, RateN2O, GWPN2O, Rland);
    }


    /// <summary>
    /// Provides a single output, 21-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <param name="GWPCH4">Input argument #17</param>
    /// <param name="RateN2O">Input argument #18</param>
    /// <param name="GWPN2O">Input argument #19</param>
    /// <param name="Rland">Input argument #20</param>
    /// <param name="Rinc">Input argument #21</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness, MWArray injury, MWArray 
                                                illnessDaysLost, MWArray injuryDaysLost, 
                                                MWArray waterRate, MWArray energyCost, 
                                                MWArray waterCost, MWArray RateCO2, 
                                                MWArray RateCH4, MWArray GWPCH4, MWArray 
                                                RateN2O, MWArray GWPN2O, MWArray Rland, 
                                                MWArray Rinc)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4, GWPCH4, RateN2O, GWPN2O, Rland, Rinc);
    }


    /// <summary>
    /// Provides a single output, 22-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <param name="GWPCH4">Input argument #17</param>
    /// <param name="RateN2O">Input argument #18</param>
    /// <param name="GWPN2O">Input argument #19</param>
    /// <param name="Rland">Input argument #20</param>
    /// <param name="Rinc">Input argument #21</param>
    /// <param name="Rrec">Input argument #22</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness, MWArray injury, MWArray 
                                                illnessDaysLost, MWArray injuryDaysLost, 
                                                MWArray waterRate, MWArray energyCost, 
                                                MWArray waterCost, MWArray RateCO2, 
                                                MWArray RateCH4, MWArray GWPCH4, MWArray 
                                                RateN2O, MWArray GWPN2O, MWArray Rland, 
                                                MWArray Rinc, MWArray Rrec)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4, GWPCH4, RateN2O, GWPN2O, Rland, Rinc, Rrec);
    }


    /// <summary>
    /// Provides a single output, 23-input MWArrayinterface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <param name="GWPCH4">Input argument #17</param>
    /// <param name="RateN2O">Input argument #18</param>
    /// <param name="GWPN2O">Input argument #19</param>
    /// <param name="Rland">Input argument #20</param>
    /// <param name="Rinc">Input argument #21</param>
    /// <param name="Rrec">Input argument #22</param>
    /// <param name="Rhaz">Input argument #23</param>
    /// <returns>An MWArray containing the first output argument.</returns>
    ///
    public MWArray Sustainability_Evaluation_Criteria(MWArray umpPathName, MWArray 
                                                massConsumable, MWArray costConsumable, 
                                                MWArray powerConsumed, MWArray costPower, 
                                                MWArray processTime, MWArray wage, 
                                                MWArray illness, MWArray injury, MWArray 
                                                illnessDaysLost, MWArray injuryDaysLost, 
                                                MWArray waterRate, MWArray energyCost, 
                                                MWArray waterCost, MWArray RateCO2, 
                                                MWArray RateCH4, MWArray GWPCH4, MWArray 
                                                RateN2O, MWArray GWPN2O, MWArray Rland, 
                                                MWArray Rinc, MWArray Rrec, MWArray Rhaz)
    {
      return mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4, GWPCH4, RateN2O, GWPN2O, Rland, Rinc, Rrec, Rhaz);
    }


    /// <summary>
    /// Provides the standard 0-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", new MWArray[]{});
    }


    /// <summary>
    /// Provides the standard 1-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName);
    }


    /// <summary>
    /// Provides the standard 2-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable);
    }


    /// <summary>
    /// Provides the standard 3-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable);
    }


    /// <summary>
    /// Provides the standard 4-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed);
    }


    /// <summary>
    /// Provides the standard 5-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower);
    }


    /// <summary>
    /// Provides the standard 6-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime);
    }


    /// <summary>
    /// Provides the standard 7-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage);
    }


    /// <summary>
    /// Provides the standard 8-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness);
    }


    /// <summary>
    /// Provides the standard 9-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness, MWArray injury)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury);
    }


    /// <summary>
    /// Provides the standard 10-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness, MWArray injury, 
                                                  MWArray illnessDaysLost)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost);
    }


    /// <summary>
    /// Provides the standard 11-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness, MWArray injury, 
                                                  MWArray illnessDaysLost, MWArray 
                                                  injuryDaysLost)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost);
    }


    /// <summary>
    /// Provides the standard 12-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness, MWArray injury, 
                                                  MWArray illnessDaysLost, MWArray 
                                                  injuryDaysLost, MWArray waterRate)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate);
    }


    /// <summary>
    /// Provides the standard 13-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness, MWArray injury, 
                                                  MWArray illnessDaysLost, MWArray 
                                                  injuryDaysLost, MWArray waterRate, 
                                                  MWArray energyCost)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost);
    }


    /// <summary>
    /// Provides the standard 14-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness, MWArray injury, 
                                                  MWArray illnessDaysLost, MWArray 
                                                  injuryDaysLost, MWArray waterRate, 
                                                  MWArray energyCost, MWArray waterCost)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost);
    }


    /// <summary>
    /// Provides the standard 15-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness, MWArray injury, 
                                                  MWArray illnessDaysLost, MWArray 
                                                  injuryDaysLost, MWArray waterRate, 
                                                  MWArray energyCost, MWArray waterCost, 
                                                  MWArray RateCO2)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2);
    }


    /// <summary>
    /// Provides the standard 16-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness, MWArray injury, 
                                                  MWArray illnessDaysLost, MWArray 
                                                  injuryDaysLost, MWArray waterRate, 
                                                  MWArray energyCost, MWArray waterCost, 
                                                  MWArray RateCO2, MWArray RateCH4)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4);
    }


    /// <summary>
    /// Provides the standard 17-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <param name="GWPCH4">Input argument #17</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness, MWArray injury, 
                                                  MWArray illnessDaysLost, MWArray 
                                                  injuryDaysLost, MWArray waterRate, 
                                                  MWArray energyCost, MWArray waterCost, 
                                                  MWArray RateCO2, MWArray RateCH4, 
                                                  MWArray GWPCH4)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4, GWPCH4);
    }


    /// <summary>
    /// Provides the standard 18-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <param name="GWPCH4">Input argument #17</param>
    /// <param name="RateN2O">Input argument #18</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness, MWArray injury, 
                                                  MWArray illnessDaysLost, MWArray 
                                                  injuryDaysLost, MWArray waterRate, 
                                                  MWArray energyCost, MWArray waterCost, 
                                                  MWArray RateCO2, MWArray RateCH4, 
                                                  MWArray GWPCH4, MWArray RateN2O)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4, GWPCH4, RateN2O);
    }


    /// <summary>
    /// Provides the standard 19-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <param name="GWPCH4">Input argument #17</param>
    /// <param name="RateN2O">Input argument #18</param>
    /// <param name="GWPN2O">Input argument #19</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness, MWArray injury, 
                                                  MWArray illnessDaysLost, MWArray 
                                                  injuryDaysLost, MWArray waterRate, 
                                                  MWArray energyCost, MWArray waterCost, 
                                                  MWArray RateCO2, MWArray RateCH4, 
                                                  MWArray GWPCH4, MWArray RateN2O, 
                                                  MWArray GWPN2O)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4, GWPCH4, RateN2O, GWPN2O);
    }


    /// <summary>
    /// Provides the standard 20-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <param name="GWPCH4">Input argument #17</param>
    /// <param name="RateN2O">Input argument #18</param>
    /// <param name="GWPN2O">Input argument #19</param>
    /// <param name="Rland">Input argument #20</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness, MWArray injury, 
                                                  MWArray illnessDaysLost, MWArray 
                                                  injuryDaysLost, MWArray waterRate, 
                                                  MWArray energyCost, MWArray waterCost, 
                                                  MWArray RateCO2, MWArray RateCH4, 
                                                  MWArray GWPCH4, MWArray RateN2O, 
                                                  MWArray GWPN2O, MWArray Rland)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4, GWPCH4, RateN2O, GWPN2O, Rland);
    }


    /// <summary>
    /// Provides the standard 21-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <param name="GWPCH4">Input argument #17</param>
    /// <param name="RateN2O">Input argument #18</param>
    /// <param name="GWPN2O">Input argument #19</param>
    /// <param name="Rland">Input argument #20</param>
    /// <param name="Rinc">Input argument #21</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness, MWArray injury, 
                                                  MWArray illnessDaysLost, MWArray 
                                                  injuryDaysLost, MWArray waterRate, 
                                                  MWArray energyCost, MWArray waterCost, 
                                                  MWArray RateCO2, MWArray RateCH4, 
                                                  MWArray GWPCH4, MWArray RateN2O, 
                                                  MWArray GWPN2O, MWArray Rland, MWArray 
                                                  Rinc)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4, GWPCH4, RateN2O, GWPN2O, Rland, Rinc);
    }


    /// <summary>
    /// Provides the standard 22-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <param name="GWPCH4">Input argument #17</param>
    /// <param name="RateN2O">Input argument #18</param>
    /// <param name="GWPN2O">Input argument #19</param>
    /// <param name="Rland">Input argument #20</param>
    /// <param name="Rinc">Input argument #21</param>
    /// <param name="Rrec">Input argument #22</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness, MWArray injury, 
                                                  MWArray illnessDaysLost, MWArray 
                                                  injuryDaysLost, MWArray waterRate, 
                                                  MWArray energyCost, MWArray waterCost, 
                                                  MWArray RateCO2, MWArray RateCH4, 
                                                  MWArray GWPCH4, MWArray RateN2O, 
                                                  MWArray GWPN2O, MWArray Rland, MWArray 
                                                  Rinc, MWArray Rrec)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4, GWPCH4, RateN2O, GWPN2O, Rland, Rinc, Rrec);
    }


    /// <summary>
    /// Provides the standard 23-input MWArray interface to the
    /// Sustainability_Evaluation_Criteria MATLAB function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="umpPathName">Input argument #1</param>
    /// <param name="massConsumable">Input argument #2</param>
    /// <param name="costConsumable">Input argument #3</param>
    /// <param name="powerConsumed">Input argument #4</param>
    /// <param name="costPower">Input argument #5</param>
    /// <param name="processTime">Input argument #6</param>
    /// <param name="wage">Input argument #7</param>
    /// <param name="illness">Input argument #8</param>
    /// <param name="injury">Input argument #9</param>
    /// <param name="illnessDaysLost">Input argument #10</param>
    /// <param name="injuryDaysLost">Input argument #11</param>
    /// <param name="waterRate">Input argument #12</param>
    /// <param name="energyCost">Input argument #13</param>
    /// <param name="waterCost">Input argument #14</param>
    /// <param name="RateCO2">Input argument #15</param>
    /// <param name="RateCH4">Input argument #16</param>
    /// <param name="GWPCH4">Input argument #17</param>
    /// <param name="RateN2O">Input argument #18</param>
    /// <param name="GWPN2O">Input argument #19</param>
    /// <param name="Rland">Input argument #20</param>
    /// <param name="Rinc">Input argument #21</param>
    /// <param name="Rrec">Input argument #22</param>
    /// <param name="Rhaz">Input argument #23</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public MWArray[] Sustainability_Evaluation_Criteria(int numArgsOut, MWArray 
                                                  umpPathName, MWArray massConsumable, 
                                                  MWArray costConsumable, MWArray 
                                                  powerConsumed, MWArray costPower, 
                                                  MWArray processTime, MWArray wage, 
                                                  MWArray illness, MWArray injury, 
                                                  MWArray illnessDaysLost, MWArray 
                                                  injuryDaysLost, MWArray waterRate, 
                                                  MWArray energyCost, MWArray waterCost, 
                                                  MWArray RateCO2, MWArray RateCH4, 
                                                  MWArray GWPCH4, MWArray RateN2O, 
                                                  MWArray GWPN2O, MWArray Rland, MWArray 
                                                  Rinc, MWArray Rrec, MWArray Rhaz)
    {
      return mcr.EvaluateFunction(numArgsOut, "Sustainability_Evaluation_Criteria", umpPathName, massConsumable, costConsumable, powerConsumed, costPower, processTime, wage, illness, injury, illnessDaysLost, injuryDaysLost, waterRate, energyCost, waterCost, RateCO2, RateCH4, GWPCH4, RateN2O, GWPN2O, Rland, Rinc, Rrec, Rhaz);
    }


    /// <summary>
    /// Provides an interface for the Sustainability_Evaluation_Criteria function in
    /// which the input and output
    /// arguments are specified as an array of MWArrays.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// function [
    /// operatingCost,energyUse,waterUse,GHGEmissions,totalWaste,averageWage,lostWorkDays
    /// ] = Sustainability_Evaluation_Criteria(inputVars)
    /// This function accepts the results of the process and linking model
    /// parametric equations and then inputs them to determine the final
    /// sustainability scores
    /// inputVars
    /// index = 1;
    /// massConsumable = inputVars(index);index = index+1;
    /// costConsumable = inputVars(index);index = index+1;
    /// powerConsumed = inputVars(index);index = index+1;
    /// costPower = inputVars(index);index = index+1;
    /// processTime = inputVars(index);index = index+1;
    /// wage = inputVars(index);index = index+1;
    /// illness = inputVars(index);index = index+1;
    /// injury = inputVars(index);index = index+1;
    /// illnessDaysLost = inputVars(index);index = index+1;
    /// injuryDaysLost = inputVars(index);index = index+1;
    /// waterRate = inputVars(index);index = index+1;
    /// energyCost = inputVars(index);index = index+1;
    /// waterCost = inputVars(index);index = index+1;
    /// RateCO2 = inputVars(index);index = index+1;
    /// RateCH4 = inputVars(index);index = index+1;
    /// GWPCH4 = inputVars(index);index = index+1;
    /// RateN2O = inputVars(index);index = index+1;
    /// GWPN2O = inputVars(index);index = index+1;
    /// Rland = inputVars(index);index = index+1;
    /// Rinc = inputVars(index);index = index+1;
    /// Rrec = inputVars(index);index = index+1;
    /// Rhaz = inputVars(index);index = index+1;
    /// test dummy variables
    /// powerConsumed = 10;
    /// processTime = 5;
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of MWArray output arguments</param>
    /// <param name= "argsIn">Array of MWArray input arguments</param>
    ///
    public void Sustainability_Evaluation_Criteria(int numArgsOut, ref MWArray[] argsOut, 
                                         MWArray[] argsIn)
    {
      mcr.EvaluateFunction("Sustainability_Evaluation_Criteria", numArgsOut, ref argsOut, 
                                         argsIn);
    }



    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
