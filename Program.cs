using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
                System.Console.WriteLine(arg);
                
            }

            // var path = string.Join(@"\", args[0], args[1]);

            // System.Console.WriteLine(path);

            List<string> list = SearchIn(path: args[0], name: args[1], word: args[2]);

            System.Console.WriteLine(string.Join("\n", list));
        }
        private static List<string> SearchIn(string path, string name, string word)
        {
            string fullPath = string.Join(@"\", path, name);
            var list = new List<string>();
            var text = ReadFrom(fullPath);
            var filter = Filter(word, text);
            DirectoryInfo dir = new DirectoryInfo(path);
            var directories = dir.GetDirectories();
            var files = dir.GetFiles();
            System.Console.WriteLine(String.Join("\n", filter));
            foreach (var item in files)
            {
                if (item.Name.Contains(name))
                    list.Add(item.Name);
                if (item.Extension.Contains(name))
                    list.Add(item.Name);
            }
            foreach (var item in directories)
            {
                list.AddRange(SearchIn(item.FullName, name, word));
            }
            return list;
            
        }
        static List<string> ReadFrom(string path)
        {
            List<string> result = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    result.Add(line!);
                }
            }
            return result;
        }
        static List<string> Filter (string word, List<string> text)
        {
            return text.Where(s => s.ToLower().Contains(word.ToLower())).Select(x => x.ToLower().Replace(word.ToLower(), word.ToUpper())).ToList();
        }
    }
}