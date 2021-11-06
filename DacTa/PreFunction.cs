using System;
using System.Collections.Generic;
using System.Text;

namespace DacTa
{
    public class PreFunction
    {
        public string state;

        
        public void CheckState(List<string> input,string pre)
        {
            input.Add("Public int Kiemtra(ref int a,ref int b) ");
            input.Add("\t\t{");
            
            
                string check  = pre;
                check = pre.Replace("pre", "").Replace(" ", string.Empty);
                if (check == "")
                {
                     input.Add("\t\t\treturn 1;");
                input.Add("\t\t}");
                }
                else
                {
                    state = string.Format("\t\t\tif({0})", check);
                     input.Add(state);
                     input.Add("\t\t\t{");
                     input.Add("\t\t\t\treturn 1;");
                     input.Add("\t\t\t}");
                     input.Add("\t\t\treturn 0;");
                }
            
            
        }
    }
}
