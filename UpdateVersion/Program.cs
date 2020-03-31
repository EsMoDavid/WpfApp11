using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UpdateVersion
{
    class Program
    {
        const string KeyAssembly = "AssemblyVersion(\"";
        static void Main(string[] args)
        {
            Console.WriteLine(args[0]);
            List<string> currentVer = args[0].Split('.').ToList();
            int nextVerIndex = int.Parse(currentVer.Last()) + 1;
            currentVer[currentVer.Count - 1] = nextVerIndex.ToString();
            string newVer = string.Join(".", currentVer);
            string path= @"WpfApp11\Properties\AssemblyInfo.cs";
            if (File.Exists(path))
            {
                string assebmlyVer = File.ReadAllText(path);
                int startIndex = assebmlyVer.LastIndexOf(KeyAssembly);
                int len = KeyAssembly.Length;
                int endIndex = assebmlyVer.IndexOf("\"", startIndex + len);
                string oldVer = assebmlyVer.Substring(startIndex + len, endIndex - startIndex - len);
                assebmlyVer = assebmlyVer.Replace(oldVer, newVer);
                File.WriteAllText(path, assebmlyVer);
            }
        }
    }
}
