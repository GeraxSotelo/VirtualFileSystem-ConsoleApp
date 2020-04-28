using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain;

namespace ConsoleApp.Services
{
    public class UtilitiesService
    {
        public List<string> Messages { get; set; } = new List<string>();
        
        internal List<string> Help()
        {
            Messages.Add("\nmkdir     Creates a directory.");
            Messages.Add("ls        Lists files in current working directory");
            Messages.Add("touch     Create a file without any content");
            Messages.Add("rm        Remove a file");
            return Messages;
        }

        internal List<string> Ls(IEnumerable<Directory> dirs, IEnumerable<File> files)
        {
            foreach (var dir in dirs)
            {
                Messages.Add(dir.Name);
            }
            foreach(var file in files)
            {
                Messages.Add(file.Name);
            }
            return Messages;
        }
    }
}
