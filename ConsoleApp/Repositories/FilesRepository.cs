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

        internal IEnumerable<File> GetFilesByDirectoryId(int id)
        {
            return _context.Files.Where(f => f.DirectoryId == id).ToList();
        }

        internal File GetByNameAndDirectoryId(string name, int directoryId)
        {
            var file = _context.Files.Where(f => f.Name == name && f.DirectoryId == directoryId).FirstOrDefault();
            return file;
        }

        internal void Touch(File file)
        {
            _context.Files.Add(file);
            _context.SaveChanges();
        }

        internal void Rm(File found)
        {
            _context.Files.Remove(found);
            _context.SaveChanges();
        }

    }
}
