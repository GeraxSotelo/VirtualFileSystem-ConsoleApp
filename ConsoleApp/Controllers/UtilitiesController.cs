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

        internal void AnalyzeInput(string command, int currDirId)
        {
            switch (command)
            {
                case "help":
                    Help();
                    break;
                case "ls":
                    Ls(currDirId);
                    break;
            }
        }

        internal void Help()
        {
            Messages = _us.Help();
            Print();
        }

        internal void Ls(int directoryId)
        {
            try
            {
                var dirs = _ds.GetDirectoriesByDirectoryId(directoryId);
                var files = _fs.GetFilesByDirectoryId(directoryId);
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
