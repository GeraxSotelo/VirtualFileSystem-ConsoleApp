using ConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using VirtualFileSystem.Domain;

namespace ConsoleApp.Services
{
    public class FilesService
    {
        private readonly FilesRepository _repo = new FilesRepository();

        internal IEnumerable<File> GetFilesByDirectoryId(int id)
        {
            return _repo.GetFilesByDirectoryId(id);
        }

        internal void Touch(string name, int id)
        {
            ValidName(name);
            AlreadyExists(name, id);

            File file = new File { Name = name, DirectoryId = id };
            _repo.Touch(file);
        }

        internal void Rm(string name, int directoryId)
        {
            var found = _repo.GetByNameAndDirectoryId(name, directoryId);
            if(found == null) { throw new Exception("--Invalid File Name--"); }

            _repo.Rm(found);
        }

        internal void ValidName(string name)
        {
            string pattern = @"^[A-Za-z0-9 _]*$";
            if (name == "" || !Regex.IsMatch(name, pattern))
            {
                throw new Exception("\n--Please enter a valid file name.--");
            }
        }

        internal void AlreadyExists(string name, int id)
        {
            var exists = _repo.GetByNameAndDirectoryId(name, id);
            if (exists != null) { throw new Exception($"\n--File '{exists.Name}' already exists in this location.--"); }
        }

    }
}
