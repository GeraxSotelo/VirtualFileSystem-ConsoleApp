using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain;


namespace ConsoleApp
{
    class DirectoryController
    {
        private readonly DirectoryService _ds = new DirectoryService();

        public DirectoryController()
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
                Console.WriteLine("Successfully Created");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
