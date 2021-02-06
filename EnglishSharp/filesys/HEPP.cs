using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EnglishSharp.filesys
{
    class HEPP
    {
        public static List<Header> loadFromSource(string name)
        {
            List<Header> headers = new List<Header>();

            string source = File.ReadAllText($"{name}.hepp", Encoding.UTF8);
            Header header = new Header();

            foreach (string line in source.Split('\n'))
            {
                string[] args = line.Trim().Split(' ');

                if (args.Length == 0) continue;
                if (args[0].Length == 0) continue;

                if (args[0][0] == '/')
                {
                    if (args[0] == "/macro")
                    {
                        header = new Header();
                        header.name = args[1];

                        ArgumentType now = ArgumentType.Value;
                        for (int i = 2; i < args.Length; i++)
                        {
                            switch (args[i])
                            {
                                case "&v":
                                    now = ArgumentType.Value;
                                    break;
                                case "&i":
                                    now = ArgumentType.Identifier;
                                    break;
                                case "&s":
                                    now = ArgumentType.Selectable;
                                    break;
                                default:
                                    header.arguments.Add(new Argument(now, args[i]));
                                    break;
                            }
                        }
                    }
                    else if (args[0] == "/require")
                    {
                        RequireType now = RequireType.TempIdentifier;
                        for (int i = 2; i < args.Length; i++)
                        {
                            switch (args[i])
                            {
                                case "&ti":
                                    now = RequireType.TempIdentifier;
                                    break;
                                default:
                                    header.requires.Add(new Require(now, args[i]));
                                    break;
                            }
                        }
                    }
                    else if (args[0] == "/type")
                    {
                        switch (args[1])
                        {
                            case "block":
                                header.macroType = MacroType.Block;
                                break;
                            case "action":
                                header.macroType = MacroType.Action;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (args[0] == "/end")
                    {
                        headers.Add(header);
                    }
                }
                else
                {
                    header.template += line + "\n";
                }
            }

            return headers;
        }
    }

    class Header
    {
        public string name;

        public MacroType macroType;
        public List<Argument> arguments = new List<Argument>();
        public List<Require> requires = new List<Require>();

        public string template;

        public string render()
        {
            return string.Empty;
        }
    }

    class Argument
    {
        public ArgumentType argumentType;
        public string name;

        public Argument(ArgumentType type, string name)
        {
            this.argumentType = type;
            this.name = name;
        }
    }

    class Require
    {
        public RequireType requireType;
        public string name;

        public Require(RequireType type, string name)
        {
            this.requireType = type;
            this.name = name;
        }
    }

    enum MacroType : int
    {
        Block = 1,
        Action = 2
    }

    enum ArgumentType : int
    {
        Value = 1,
        Identifier = 2,
        Selectable = 3
    }

    enum RequireType : int
    {
        TempIdentifier = 1,

    }
}