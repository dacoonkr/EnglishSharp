using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using EnglishSharp.utils;
using EnglishSharp.transpile;

namespace EnglishSharp.filesys
{
    class ConvertToCS
    {
        static List<string> require_package = new List<string>();

        public static void RequirePackage(string name)
        {
            require_package.Add(name);
        }

        //C#코드로 변환 후 저장
        public static ResultStatus convert(string source_file)
        {
            string target_file = $"target\\Program.cs";
            string source = File.ReadAllText(source_file, Encoding.UTF8);

            ResultStatus res = Transpile.transpile(CodeTree.treeify(source), 0);

            if (res.status == Status.Success)
            {
                foreach (var i in require_package)
                {
                    ResultStatus package = Package.Download(i);

                    if (package.status != Status.Success)
                        return package;
                }

                string ret = Renderer.render_mono(BasicData.templates["main_class"], res.content);

                if (!File.Exists(target_file))
                {
                    Directory.CreateDirectory("target");
                    File.Create(target_file);
                }
                File.WriteAllText(target_file, ret);

                return new ResultStatus(Status.Success, string.Empty);
            }
            else if (res.status == Status.TransfileError)
            {
                return new ResultStatus(Status.TransfileError, res.content);
            }

            return new ResultStatus(Status.Unknown, string.Empty);
        }
    }
}