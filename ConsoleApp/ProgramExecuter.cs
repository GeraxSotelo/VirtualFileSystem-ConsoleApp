using System;
using VirtualFileSystem.Domain.Models;

namespace ConsoleApp
{
    class ProgramExecuter
    {
        private bool _running = true;
        private RootDirectory _root;
        private CommandParser _cp = new CommandParser();
        private DirectoryController _dc;

        public ProgramExecuter()
        {
        }
        public ProgramExecuter(DirectoryController dc)
        {
            _root = GetRootDirectory();
            _dc = dc;
        }

        private RootDirectory GetRootDirectory()
        {
            return _dc.GetRootDirectory();
        }

        public void Run()
        {
            while (_running)
            {
                Console.WriteLine("\nType a command. 'help' for information. 'q' or 'e' to exit.\n");
                GetUserInput();
            }
        }

        private void GetUserInput()
        {
            string input = Console.ReadLine() + " ";
            AnalyzeInput(input);
        }

        private UserInput AnalyzeInput(string input)
        {
            UserInput parsedInput = _cp.ParseInput(input);

            switch(parsedInput.Command)
            {
                case "q":
                case "e":
                    _running = false;
                    break;
                case "mkdir":
                    _dc.Mkdir(parsedInput.Option, 5);
                    break;
                default:
                    parsedInput.Command = "Invalid input";
                    break;
            }
            return parsedInput;
        }
    }
}
