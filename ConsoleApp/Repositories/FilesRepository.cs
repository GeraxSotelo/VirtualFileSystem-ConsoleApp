using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;

namespace ConsoleApp.Repositories
{
    public class FilesRepository
    {
        private static FileSystemContext _context = new FileSystemContext();

        internal bool FileExists(string name, int directoryId)
        {
            return _context.Files.Any(f => f.Name == name && f.DirectoryId == directoryId);
        }

        internal void Touch(File file)
        {
            _context.Files.Add(file);
            _context.SaveChanges();
        }
    }
}
