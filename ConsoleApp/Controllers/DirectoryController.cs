using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain.Models;

namespace ConsoleApp
{
    class DirectoryController
    {
        private readonly DirectoryService _ds;

        public DirectoryController(DirectoryService ds)
        {
            _ds = ds;
        }

        internal RootDirectory GetRootDirectory()
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
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

    }
}
