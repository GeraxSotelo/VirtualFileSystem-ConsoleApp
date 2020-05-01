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

        internal void AnalyzeInput(UserInput parsedInput, int currDirId)
        {
            switch (parsedInput.Command)
            {
                case "mkdir":
                case "md":
                    MkDir(parsedInput.Option, currDirId);
                    break;
                case "rmdir":
                case "rd":
                    RmDir(parsedInput.Option, currDirId);
                    break;
            }
        }

        internal void MkDir(string name, int directoryId)
        {
            try
            {
                _ds.MkDir(name, directoryId);
                Console.WriteLine($"\n--Successfully created directory '{name}'--");
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
                Console.WriteLine($"\n--Succesfully deleted file '{name}'--");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
