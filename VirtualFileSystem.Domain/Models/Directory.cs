using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain.Models;
using VirtualFileSystem.Domain.Interfaces;

namespace VirtualFileSystem.Domain
{
    public class Directory : IDirectory
    {
        public Directory()
        {
            Directories = new List<Directory>();
            Files = new List<File>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Directory> Directories { get; set; }
        public List<File> Files { get; set; }
        public int? DirectoryId { get; set; }

    }
}
