using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain.Interfaces;

namespace VirtualFileSystem.Domain.Models
{
    public class RootDirectory : IDirectory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Directory> Directories { get; set; }
        public List<File> Files { get; set; }

        public RootDirectory()
        {
            Directories = new List<Directory>();
            Files = new List<File>();
        }
    }
}
