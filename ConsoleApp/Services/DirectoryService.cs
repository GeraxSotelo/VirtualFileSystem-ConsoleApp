using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain;
using VirtualFileSystem.Domain.Models;

namespace ConsoleApp
{
    class DirectoryService
    {
        private readonly DirectoryRepository _repo;
        public DirectoryService(DirectoryRepository repo)
        {
            _repo = repo;
        }

        internal void Mkdir(string option, int id)
        {
            Directory dir = new Directory { Name = option, DirectoryId = id };
            _repo.Mkdir(dir);
        }

        internal RootDirectory GetRootDirectory()
        {
            var found = _repo.GetRootDirectory();
            if (found == null)
            {
                RootDirectory root = _repo.CreateRootDirectory(root);
            }
        }
    }
}
