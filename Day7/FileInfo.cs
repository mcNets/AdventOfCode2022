using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Day7
{
    public enum FileType
    {
        Directory,
        File
    }

    public class TreeInfo
    {
        public TreeInfo(FileType type, string name, long size, TreeInfo? parent)
        {
            FType = type;
            Name = name;
            Size = size;
            Nodes = (type == FileType.Directory) ? new List<TreeInfo>() : null;
            Parent = parent;

            if (parent is not null)
            {
                _level = parent._level + 1;
            }

            if (FType == FileType.File)
            {
                AddSizeParentDirectories(size);
            }
        }

        public FileType FType;
        public string? Name;
        public long Size;
        public List<TreeInfo>? Nodes;
        public TreeInfo? Parent;

        private int _level = 0;

        private static long _sumSize = 0;

        public void AddSizeParentDirectories(long size)
        {
            if (Parent is null || Parent.FType is not FileType.Directory) return;

            Parent.Size += size;
            Parent.AddSizeParentDirectories(size);
        }

        public long DirSizeLowerOrEquealThan(long maxSize)
        {
            if (this.Name == "root")
            {
                _sumSize = 0;
            }

            if (Nodes is null) return 0;

            foreach (var node in Nodes)
            {
                if (node.FType == FileType.Directory)
                {
                    if (node.Size <= maxSize)
                    {
                        _sumSize += node.Size;
                    }
                    node.DirSizeLowerOrEquealThan(maxSize);
                }
            }
            return _sumSize;
        }

        public void Print()
        {
            if (Nodes is null) return;

            if (Name == "root")
            {
                Console.WriteLine($"{new string(' ', _level * 2)}{Name}  {Size}");
            }

            var dirs = Nodes.Where(x => x.FType == FileType.Directory);
            var files = Nodes.Where(x => x.FType == FileType.File);

            foreach (var dir in dirs)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{new string(' ', dir._level * 3)}{dir.Name}  {dir.Size}");
                dir.Print();
            }

            foreach (var file in files)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{new string(' ', file._level * 3)}{file.Name}  {file.Size}");
            }
        }

        public void Print2()
        {
            if (Name == "root")
            {
                _sumSize = 0;
            }

            var dirs = Nodes.Where(x => x.FType == FileType.Directory);

            foreach (var dir in dirs)
            {
                if (dir.Size <= 100000)
                {
                    _sumSize += dir.Size;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{dir.Name}  {dir.Size}  {_sumSize}");
                }
                dir.Print2();
            }
        }
    }

    public static class Tools
    {
        public static void FindDirectories(List<TreeInfo> list, TreeInfo node)
        {
            if (node.Nodes is null) return;

            foreach (var n in node.Nodes)
            {
                if (n.FType == FileType.Directory)
                {
                    list.Add(n);
                    FindDirectories(list, n);
                }
            }
        }
    }
}
