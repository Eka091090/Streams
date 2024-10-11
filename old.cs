
// using System.Reflection.Metadata.Ecma335;
// using System.Security.Cryptography;

// namespace task2
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             // foreach (string arg in args)
//             // {
//             //     System.Console.WriteLine(arg);
//             // }

//             List<string> list = SearchIn(path: args[0], name: args[1]);

//             System.Console.WriteLine(string.Join("\n", list));
        
//         }

//         private static List<string> SearchIn(string path, string name)
//         {
//             var list = new List<string>();
//             DirectoryInfo dir = new DirectoryInfo(path);
//             var directories = dir.GetDirectories();
//             var files = dir.GetFiles();
//             foreach (var item in files)
//             {
//                 if (item.Name.Contains(name))
//                     list.Add(item.Name);
//                 if (item.Extension.Contains(name))
//                     list.Add(item.Name);
//             }
//             foreach (var item in directories)
//             {
//                 list.AddRange(SearchIn(item.FullName, name));
//             }
//             return list;

//         }
//     }
// }