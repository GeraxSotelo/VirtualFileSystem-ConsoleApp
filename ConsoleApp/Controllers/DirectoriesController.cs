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
                case "cd":
                    return Cd(parsedInput.Option, currDirId);
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

        internal Directory Cd(string name, int currDirId)
        {
            try
            {
                var dir = _ds.GetByNameAndDirectoryId(name, currDirId);
                return dir;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
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
