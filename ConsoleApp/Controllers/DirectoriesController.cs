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

        internal void MkDir(string name, int directoryId)
        {
            try
            {
                _ds.MkDir(name, directoryId);
                Console.WriteLine($"\nSuccessfully created directory '{name}'");
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
                Console.WriteLine($"\nSuccesfully deleted file '{name}'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
