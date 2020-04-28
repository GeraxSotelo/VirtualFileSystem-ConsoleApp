using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain.Interfaces;

namespace VirtualFileSystem.Domain.Models
{
    public class FileSystem
    {
        public Directory Root { get; set; }
        public IDirectory CurrentDirectory { get; set; }

        public FileSystem(Directory root)
        {
            Root = root;
            Setup();
        }

        public void Setup()
        {
            CurrentDirectory = Root;
            Console.WriteLine("Welcome to the Virtual File System.\n");
        }
    }
}
