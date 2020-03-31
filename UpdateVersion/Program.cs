using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            string previous = args[0];
            string current = args[1];
            string previousVer = $"[assembly: AssemblyVersion(\"{previous}\")]";
            string currentVer = $"[assembly: AssemblyVersion(\"{current}\")]";
            string path= @"..\..\..\WpfApp11\Properties\AssemblyInfo.cs";
            if (File.Exists(path))
            {
                string assebmlyVer = File.ReadAllText(path);
                var newAssemblyInfo = assebmlyVer.Replace(previousVer, currentVer);
                File.WriteAllText(path, newAssemblyInfo);
            }
        }
    }
}
