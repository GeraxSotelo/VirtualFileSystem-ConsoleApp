using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain;

namespace ConsoleApp
{
    class DirectoryService
    {
        private readonly DirectoryRepository _repo = new DirectoryRepository();
        public DirectoryService()
        {
        }

        internal void Mkdir(string option, int id)
        {
            Directory dir = new Directory { Name = option, DirectoryId = id };
            var exists = _repo.DirectoryExists(dir.Name, dir.DirectoryId);
            if (exists)
            {
                throw new Exception($"Directory {dir.Name} already exists in this location.");
            }
            _repo.Mkdir(dir);
        }

        internal Directory GetRootDirectory()
        {
            var found = _repo.GetRootDirectory();
            if (found == null)
            {
                Directory root = new Directory { Name = "root", DirectoryId = null };
                int id = _repo.CreateRootDirectory(root);
                root.Id = id;
                return root;
            }
            else
            {
                return found;
            }
        }
    }
}
