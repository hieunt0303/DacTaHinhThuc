using System;
using System.Collections.Generic;
using System.Text;

namespace DacTa
{
    public class pyPreFunction : pyNameFunction
    {
        public string state;


        public void CheckState(List<string> input, string pre, string namepath)
        {
            string[] path = namepath.Split(new[] { "(", ")" }, StringSplitOptions.None);


            input.Add(SetNamePG("KiemTra", namepath, path[1]));

            string check = pre;
            check = pre.Replace("pre", "").Replace(" ", string.Empty);

            if (check == "")
            {
                input.Add("\treturn 1");
            }
            else
            {
                state = string.Format("\tif({0}):", check.Replace("&&", "and"));
                input.Add(state);
                input.Add("\t\treturn 1");
                input.Add("\treturn 0");
            }


        }
    }
}
