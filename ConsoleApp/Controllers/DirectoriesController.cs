using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain;
using VirtualFileSystem.Domain.Models;

namespace ConsoleApp
{
    public class DirectoriesController
    {
        private readonly DirectoriesService _ds = new DirectoriesService();

        public DirectoriesController()
        {
        }

        internal Directory GetRootDirectory()
        {
            try
            {
                return _ds.GetRootDirectory();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        internal dynamic AnalyzeInput(UserInput parsedInput, int currDirId)
        {
            switch (parsedInput.Command)
            {
                case "chdir":
                case "cd":
                    return ChDir(parsedInput.Option, currDirId);
                case "mkdir":
                case "md":
                    MkDir(parsedInput.Option, currDirId);
                    return "Completed";
                case "rmdir":
                case "rd":
                    RmDir(parsedInput.Option, currDirId);
                    return "Completed";
                default:
                    return "Completed";
            }
        }

        private Directory GetParentDirectory(int currDirId)
        {
            try
            {
                var dir = _ds.GetDirectoryById(currDirId);
                int parentId = dir.DirectoryId ?? default(int);
                if(parentId == 0)
                {
                    return dir;
                }
                return _ds.GetDirectoryById(parentId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        internal Directory ChDir(string name, int currDirId)
        {
            try
            {
                if (name == "..")
                {
                    return GetParentDirectory(currDirId);
                }
                else
                {
                    return _ds.GetByNameAndDirectoryId(name, currDirId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return _ds.GetDirectoryById(currDirId);
            }
        }

        internal void MkDir(string name, int directoryId)
        {
            try
            {
                _ds.MkDir(name, directoryId);
                Console.WriteLine($"\n---Successfully created directory '{name}.'---");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        internal void RmDir(string name, int directoryId)
        {
            try
            {
                _ds.RmDir(name, directoryId);
                Console.WriteLine($"\n---Succesfully deleted file '{name}.'---");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
