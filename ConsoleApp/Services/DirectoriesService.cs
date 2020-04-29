using System;
using System.Collections.Generic;
using System.Text;
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

        internal void Mkdir(string option, int id)
        {
            var exists = _repo.DirectoryExists(option, id);
            if (exists)
            {
                throw new Exception($"\nDirectory '{option}' already exists in this location.");
            }

            Directory dir = new Directory { Name = option, DirectoryId = id };
            _repo.Mkdir(dir);
        }

    }
}
