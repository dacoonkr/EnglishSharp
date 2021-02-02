using System;

namespace EnglishSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {

            }
            else
            {
                filesys.ConvertToCS.convert(args[1]);
            }
        }
    }
}