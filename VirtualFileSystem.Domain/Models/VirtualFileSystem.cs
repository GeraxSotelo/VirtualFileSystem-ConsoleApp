using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain.Interfaces;

namespace VirtualFileSystem.Domain.Models
{
    class VirtualFileSystem
    {
        public RootDirectory Root { get; set; }
        public IDirectory CurrentDirectory { get; set; }

        public VirtualFileSystem(RootDirectory root)
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
