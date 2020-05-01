using ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Controllers
{
    public class FilesController
    {
        private readonly FilesService _fs = new FilesService();

        internal void Touch(string name, int id)
        {
            try
            {
                _fs.Touch(name, id);
                Console.WriteLine($"\nSuccessfully created file '{name}'");
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
                Console.WriteLine($"\nSuccessfully deleted file '{name}'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
