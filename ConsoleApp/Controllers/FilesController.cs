using ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Controllers
{
    class FilesController
    {
        private readonly FilesService _fs = new FilesService();

        internal void Touch(string option, int id)
        {
            try
            {
                _fs.Touch(option, id);
                Console.WriteLine($"\nSuccessfully created file '{option}'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
