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

        internal void MkDir(string option, int directoryId)
        {
            try
            {
                _ds.MkDir(option, directoryId);
                Console.WriteLine($"\nSuccessfully created directory '{option}'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        internal void RmDir(string option, int directoryId)
        {
            try
            {
                _ds.RmDir(option, directoryId);
                Console.WriteLine($"\nSuccesfully deleted file '{option}'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
