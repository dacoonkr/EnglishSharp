using System;

namespace EnglishSharp
{
    class Program
    {
        static int varUsed = 0;
        
        public static string getUnusedVar()
        {
            return $"vtmp{varUsed}";
        }

        static void Main(string[] args)
        {
            filesys.ConvertToCS.convert("input.epp");

            /*
            if (args.Length == 0)
            {

            }
            else
            {
                foreach (string i in args)
                    filesys.ConvertToCS.convert(i);
            }
            */
        }
    }
}