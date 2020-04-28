using ConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain;

namespace ConsoleApp.Services
{
    public class FilesService
    {
        private readonly FilesRepository _repo = new FilesRepository();

        internal void Touch(string option, int id)
        {
            var exists = _repo.FileExists(option, id);
            if(exists)
            {
                throw new Exception($"\nFile '{option}' already exists in this location.");
            }

            File file = new File { Name = option, DirectoryId = id };
            _repo.Touch(file);
        }
    }
}
