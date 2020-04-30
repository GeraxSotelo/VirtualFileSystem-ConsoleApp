using System;
using System.Linq;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramExecuter pe = new ProgramExecuter();
            pe.Run();
        }
    }
}
