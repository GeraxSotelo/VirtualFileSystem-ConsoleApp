using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain.Interfaces;

namespace VirtualFileSystem.Domain
{
    public class File : IFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DirectoryId { get; set; }
    }
}
