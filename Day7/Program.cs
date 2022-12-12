
using Day7;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;

/*
 * Find all of the directories with a total size of at most 100000. What is the sum of the total sizes of those directories?
 * 
 * Result exercise 1: 1118405
 * 
 * Find the smallest directory that, if deleted, would free up enough space on the filesystem to run the update. What is the total size of that directory?
 * 
 * Result exercise 2: 12545514
 * 
 * Path =  /abc/def/hij/file_name
 * Size 
 */

Console.WriteLine("Advent of Code - Day 7");

var commands = File.ReadAllLines(@"..\..\..\data.txt").ToList();
Console.WriteLine(commands.Count);

Dictionary<string, int> Directories = new Dictionary<string, int>();
//Dictionary<string, int> Files = new Dictionary<string, int>();
string CurDir = "";

commands.ForEach(command =>
{
    var cmd = command.Split(' ');
    if (cmd[0] == "$" && cmd[1] == "cd" && cmd[2] == "/")
    {
        CurDir = "";
    }
    else if (cmd[0] == "$" && cmd[1] == "cd" && cmd[2] == "..")
    {
        var l = CurDir.Split("/");
        CurDir = string.Join('/', l.Except(l.TakeLast(1)).ToArray());
    }
    else if (cmd[0] == "$" && cmd[1] == "cd")
    {
        CurDir += $"/{cmd[2]}";
    }
    else if (cmd[0] == "dir")
    {
        Directories.Add($"{CurDir}/{cmd[1]}", 0);
    }
    else if (int.TryParse(cmd[0], out int fSize))
    {

    }


    //    (command.Split(' ') switch
    //{
    //    ["$", "cd", "/"] => new Action(() => CurDir = ""),
    //    ["$", "cd", ".."] => new Action(() =>
    //    {
    //        var l = CurDir.Split("/");
    //        CurDir = string.Join('/', l.Except(l.TakeLast(1)).ToArray());
    //    }),
    //    ["$", "cd", var dirName] => new Action(() =>
    //    {
    //        var directoryName = dirName;
    //        CurDir += $"/{dirName}";
    //    }),
    //    ["$", "ls"] => () => { }
    //    ,
    //    ["dir", var dirName] => () =>
    //    {
    //        var directoryName = dirName;
    //        Directories.Add($"{CurDir}/{dirName}", 0);
    //    }
    //    ,
    //    [var fileSize, var fileName] => new Action(() =>
    //    {
    //        int fSize = int.Parse(fileSize);
    //        //Files.Add($"{CurDir}/{fileName}", fSize);

    //        //var l = CurDir.Split("/");
    //        //for (int x = 0; x < l.Length; x++)
    //        //{
    //        //    var key = string.Join("/", l.Take(l.Length - x).ToArray());
    //        //    Console.WriteLine($"key: {key}");
    //        //    if (!string.IsNullOrEmpty(key))
    //        //    {
    //        //        Directories[key] += fSize;
    //        //    }
    //        //}
    //    }),
    //    _ => () => { }
    //})();
});

foreach (var file in Directories.OrderBy(x => x.Key))
{
    Console.WriteLine($"{file.Key}  {file.Value}");
}

var total = Directories.Where(x => x.Value < 100000).Sum(x => x.Value);
Console.WriteLine($"Result exercise 1: {total}");

//TreeInfo treeRoot = new TreeInfo(FileType.Directory, "root", 0, null);

//TreeInfo current = treeRoot;

//commands.ForEach(command =>
//{
//    var cmd = command.Split(' ');

//    if (cmd[0] == "$" && cmd[1] == "cd")
//    {
//        if (cmd[2] == "/")
//        {
//            current = treeRoot;
//        }
//        else if (cmd[2] == "..")
//        {
//            current = current.Parent is not null ? current.Parent : throw new Exception("current.Parent is null");
//        }
//        else
//        {
//            var node = current.Nodes?.Find(x => x.Name == cmd[2]);
//            current = current.Nodes is not null && node is not null ? node : throw new Exception($"Node {cmd[2]} not found.");
//        }
//    }
//    else if (cmd[0] == "dir")
//    {
//        current.Nodes?.Add(new TreeInfo(FileType.Directory, cmd[1], 0, current));
//    }
//    else if (int.TryParse(cmd[0], out int size))
//    {
//        current.Nodes?.Add(new TreeInfo(FileType.File, cmd[1], size, current));
//    }
//});

//Console.WriteLine($"Result exercise 1: {treeRoot.DirSizeLowerOrEquealThan(100000)}\n");

//long unusedSpace = 70000000 - treeRoot.Size;
//long requiredSpace = 30000000 - unusedSpace;

//Console.WriteLine($"Unused: {unusedSpace}   Required: {requiredSpace}");

//// Find lower level directories
//List<TreeInfo> list = new List<TreeInfo>();
//list.Add(treeRoot);
//Tools.FindDirectories(list, treeRoot);

//var ordList = list.OrderBy(x => x.Size);

//foreach (var item in ordList)
//{
//    if (item.Size > requiredSpace)
//    {
//        Console.WriteLine($"Result exercice 2: {item.Size}");
//        break;
//    }
//}