using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EnglishSharp.filesys
{
    class HEPP
    {
        public static Header loadFromSource(string name)
        {
            string source = File.ReadAllText($"{name}.hepp", Encoding.UTF8);

            foreach (string line in source.Split('\n'))
            {
                string[] args = line.Split(' ');

                if (args[0][0] == '/')
                {
                    if (args[0] == "/macro")
                    {

                    }
                    else if (args[0] == "/with")
                    {

                    }
                    else if (args[0] == "/type")
                    {

                    }
                    else if (args[0] == "/end")
                    {

                    }
                }
                else
                {

                }
            }

            return new Header();
        }
    }

    class Header
    {

    }
}