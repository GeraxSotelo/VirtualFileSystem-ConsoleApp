using ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp.Controllers
{
    public class UtilitiesController
    {
        public List<string> Messages { get; set; }
        private readonly UtilitiesService _us = new UtilitiesService();
        private readonly DirectoriesService _ds = new DirectoriesService();
        private readonly FilesService _fs = new FilesService();
        public UtilitiesController()
        {
            Messages = new List<string>();
        }

        internal void Help()
        {
            Messages = _us.Help();
            Print();
        }

        internal void Ls(int id)
        {
            try
            {
                var dirs = _ds.GetDirectoriesByDirectoryId(id);
                var files = _fs.GetFilesByDirectoryId(id);
                Messages = _us.Ls(dirs, files);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Print();
        }

        private void Print()
        {
            foreach (string msg in Messages)
            {
                Console.WriteLine(msg);
            }
            Messages.Clear();
        }
    }
}
