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
            Messages.Add("\n LS        Lists files in current working directory.");
            Messages.Add(" MKDIR     Creates a directory.");
            Messages.Add(" MD        Creates a directory.");
            Messages.Add(" RMDIR     Deletes a directory.");
            Messages.Add(" RD        Deletes a directory.");
            Messages.Add(" TOUCH     Creates a file without any content.");
            Messages.Add(" RM        Deletes a file.");
            return Messages;
        }

        internal List<string> Ls(IEnumerable<Directory> dirs, IEnumerable<File> files)
        {
            foreach (var dir in dirs)
            {
                Messages.Add("\n "+dir.Name);
            }
            foreach(var file in files)
            {
                Messages.Add(" "+file.Name);
            }
            return Messages;
        }
    }
}
