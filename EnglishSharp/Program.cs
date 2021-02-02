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
                filesys.ConvertToCS.convert(args[0]);
            }
        }
    }
}