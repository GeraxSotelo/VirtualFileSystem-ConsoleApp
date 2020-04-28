using System;
using System.Linq;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;

namespace ConsoleApp
{
    class Program
    {
        private static FileSystemContext _context = new FileSystemContext();
        static void Main(string[] args)
        {
            ProgramExecuter pe = new ProgramExecuter();
            pe.Run();
            //GetDirectories("After Add: ");
        }

        private static void GetDirectories(string text)
        {
            var directories = _context.Directories.ToList(); //failing. looking for rootdirectory column
            Console.WriteLine($"{text}: Directory count is {directories.Count}");
            foreach (var directory in directories)
            {
                Console.WriteLine(directory.Name);
            }
        }
    }
}
