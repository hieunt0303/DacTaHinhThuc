using System;
using System.Collections.Generic;
using System.Text;

namespace DacTa
{
    public class PreFunction:NameFunction
    {
        public string state;

        
        public void CheckState(List<string> input,string pre,string namepath)
        {
            string[] path = namepath.Split(new[] { "(", ")" }, StringSplitOptions.None);
            

            input.Add(SetNamePG("KiemTra",namepath,path[1]));
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
