﻿using ConsoleApp.Repositories;
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
            ValidFileName(name);
            FileExists(name, id);

            File file = new File { Name = name, DirectoryId = id };
            _repo.Touch(file);
        }

        internal void ValidFileName(string name)
        {
            string pattern = @"^[A-Za-z0-9 _]*$";
            if (name == "" || !Regex.IsMatch(name, pattern))
            {
                throw new Exception("\nPlease enter a valid file name.");
            }
        }

        internal void FileExists(string name, int id)
        {
            var exists = _repo.FileExists(name, id);
            if (exists)
            {
                throw new Exception($"\nFile '{name}' already exists in this location.");
            }
        }

    }
}
