using System;

namespace EnglishSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {

            }
            else
            {
                foreach (string i in args)
                    filesys.ConvertToCS.convert(i);
            }
        }
    }
}