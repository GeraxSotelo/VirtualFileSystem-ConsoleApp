using System;
using System.Linq;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;

namespace ConsoleApp
{
    public class Program
    {
        private static FileSystemContext _context = new FileSystemContext();
        static void Main(string[] args)
        {
            ProgramExecuter pe = new ProgramExecuter();
            pe.Run();
        }
    }
}
