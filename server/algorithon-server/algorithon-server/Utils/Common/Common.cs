using System;

namespace algorithon_server.Utils.Common
{
    public class Common
    {
        public string SubString(string program, string input, string newInput)
        {
            string temp = program.Substring(0, program.IndexOf(input, StringComparison.Ordinal));
            string temp2 = program.Substring(program.IndexOf(input, StringComparison.Ordinal) + input.Length);
            return temp + newInput + temp2;
        }
    }
}