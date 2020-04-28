using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain;


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

        internal void Mkdir(string option, int id)
        {
            try
            {
                _ds.Mkdir(option, id);
                Console.WriteLine($"\nSuccessfully Created directory '{option}'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
