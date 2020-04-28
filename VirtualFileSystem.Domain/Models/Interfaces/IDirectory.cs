using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualFileSystem.Domain.Models.Interfaces
{
    public interface IDirectory
    {
        int Id { get; set; }
        string Name { get; set; }
        List<Directory> Directories { get; set; }
        List<File> Files { get; set; }
        int ParentDirectoryId { get; set; }
    }
}
