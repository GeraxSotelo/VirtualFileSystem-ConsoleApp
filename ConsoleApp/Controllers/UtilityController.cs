using ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp.Controllers
{
    public class UtilityController
    {
        public List<string> Messages { get; set; }
        private readonly UtilityService _us = new UtilityService();
        private readonly DirectoryService _ds = new DirectoryService();
        public UtilityController()
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
                Messages = _us.Ls(dirs);
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
