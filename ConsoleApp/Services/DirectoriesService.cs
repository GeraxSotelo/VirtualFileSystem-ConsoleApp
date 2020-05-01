using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using VirtualFileSystem.Domain;

namespace ConsoleApp
{
    public class DirectoriesService
    {
        private readonly DirectoriesRepository _repo = new DirectoriesRepository();
        public DirectoriesService()
        {
        }

        internal Directory GetRootDirectory()
        {
            var found = _repo.GetRootDirectory();
            if (found == null)
            {
                Directory root = new Directory { Name = "root", DirectoryId = null };
                return _repo.CreateRootDirectory(root);
            }
            else
            {
                return found;
            }
        }

        internal IEnumerable<Directory> GetDirectoriesByDirectoryId(int id)
        {
            return _repo.GetDirectoriesByDirectoryId(id);
        }

        internal void MkDir(string option, int directoryId)
        {
            var exists = _repo.DirectoryExists(option, directoryId);
            if (exists)
            {
                throw new Exception($"\nDirectory '{option}' already exists in this location.");
            }

            Directory dir = new Directory { Name = option, DirectoryId = directoryId };
            _repo.MkDir(dir);
        }

        internal void RmDir(string name, int directoryId)
        {
            var found = _repo.GetByNameAndDirectoryId(name, directoryId);
            if(found == null) { throw new Exception("\nInvalid Directory Name"); }

            _repo.RmDir(found);
        }

        private void ValidFileName(string name)
        {
            string pattern = @"^[A-Za-z0-9 _]*$";
            if (name == "" || !Regex.IsMatch(name, pattern))
            {
                throw new Exception("\nPlease enter a valid directory name.");
            }
        }
    }
}
