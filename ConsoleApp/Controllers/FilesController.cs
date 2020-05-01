using ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain.Models;

namespace ConsoleApp.Controllers
{
    public class FilesController
    {
        private readonly FilesService _fs = new FilesService();

        internal void AnalyzeInput(UserInput parsedInput, int currDirId)
        {
            switch (parsedInput.Command)
            {
                case "touch":
                    Touch(parsedInput.Option, currDirId);
                    break;
                case "rm":
                    Rm(parsedInput.Option, currDirId);
                    break;
            }
        }

        internal void Touch(string name, int id)
        {
            try
            {
                _fs.Touch(name, id);
                Console.WriteLine($"\n--Successfully created file '{name}'--");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        internal void Rm(string name, int directoryId)
        {
            try
            {
                _fs.Rm(name, directoryId);
                Console.WriteLine($"\n--Successfully deleted file '{name}'--");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
