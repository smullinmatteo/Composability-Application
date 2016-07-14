using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composability_Tool_20160301
{
    public class UMP
    {
        public string name { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public List<String> inputList { get; set; }
        public List<String> outputList { get; set; }
        public List<String> feedbackList { get; set; }
        public List<String> productProcessInfoList { get; set; }
        public List<String> resourceInfoList { get; set; }

        public List<UMPEquation> equations;

        public Dictionary<String, String> nameVarDic { get; set; }

        /*public UMP(string _name, string _type, string _description, List<String> _inputList, List<String> _outputList, List<String> _feedbackList, List<String> _productProcessInfoList, List<String> _resourceInfoList, List<UMPEquation> _eq)
        {
            inputList = _inputList;
            outputList = _outputList;
            feedbackList = _feedbackList;
            productProcessInfoList = _productProcessInfoList;
            resourceInfoList = _resourceInfoList;
            equations = _eq;
            name = _name;
            type = _type;
            description = _description;

        }*/

        public void setNameVarDic(Dictionary<String, String> _nameVarDic)
        {
            nameVarDic = _nameVarDic;
        }

        public UMP()
        {

        }

        public UMP(string _name, string _type, string _description)
        {
            inputList = new List<string>();
            outputList = new List<string>();
            feedbackList = new List<string>();
            productProcessInfoList = new List<string>();
            resourceInfoList = new List<string>();
            equations = new List<UMPEquation>();
            name = _name;
            type = _type;
            description = _description;
        }

        public void AddInput(string inputName)
        {
            inputList.Add(inputName);
        }

        public void AddOutput(string outputName)
        {
            outputList.Add(outputName);
        }

        public void AddFeedback(string feedbackName)
        {
            feedbackList.Add(feedbackName);
        }

        public void AddProductProcessInfo(string productProcessInfoname)
        {
            productProcessInfoList.Add(productProcessInfoname);
        }

        public void AddResourceInfo(string resourceInfoName)
        {
            resourceInfoList.Add(resourceInfoName);
        }

        public void AddEquation(UMPEquation eq)
        {
            equations.Add(eq);
        }
    }
}
