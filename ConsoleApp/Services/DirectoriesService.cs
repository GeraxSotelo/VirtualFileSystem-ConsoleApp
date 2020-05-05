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

        internal Directory GetDirectoryById(int id)
        {
            var found = _repo.GetDirectoryById(id);
            if (found == null) { throw new Exception("\n---Invalid Directory Id.---"); }
            return found;
        }

        internal Directory GetByNameAndDirectoryId(string name, int directoryId)
        {
            var found = _repo.GetByNameAndDirectoryId(name, directoryId);
            if (found == null) { throw new Exception("\n---Invalid Directory Name.---"); }
            return found;
        }

        internal IEnumerable<Directory> GetDirectoriesByDirectoryId(int id)
        {
            return _repo.GetDirectoriesByDirectoryId(id);
        }

        public void MkDir(string name, int directoryId)
        {
            ValidName(name);
            AlreadyExists(name, directoryId);

            Directory dir = new Directory { Name = name, DirectoryId = directoryId };
            _repo.MkDir(dir);
        }

        internal void RmDir(string name, int directoryId)
        {
            var found = _repo.GetByNameAndDirectoryId(name, directoryId);
            if(found == null) { throw new Exception("\n---Invalid Directory Name.---"); }

            _repo.RmDir(found);
        }

        internal void ValidName(string name)
        {
            string pattern = @"^[A-Za-z0-9 _]*$";
            if (name == "" || !Regex.IsMatch(name, pattern))
            {
                throw new Exception("\n---Please enter a valid directory name.---");
            }
        }

        public void AlreadyExists(string name, int directoryId)
        {
            var exists = _repo.GetByNameAndDirectoryId(name, directoryId);
            if (exists != null) { throw new Exception($"\n---Directory '{exists.Name}' already exists in this location.---"); }
        }

    }
}
