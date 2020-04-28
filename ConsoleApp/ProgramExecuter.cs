using ConsoleApp.Controllers;
using System;
using VirtualFileSystem.Domain;
using VirtualFileSystem.Domain.Models;

namespace ConsoleApp
{
    class ProgramExecuter
    {
        private bool _running = true;
        private Directory _root;
        private CommandParser _cp = new CommandParser();
        private readonly UtilityController _uc = new UtilityController();
        private readonly DirectoryController _dc = new DirectoryController();
        private readonly FileSystem _vfs;

        public ProgramExecuter()
        {
            _root = GetRootDirectory();
            _vfs = new FileSystem(_root);
        }

        private Directory GetRootDirectory()
        {
            return _dc.GetRootDirectory();
        }

        public void Run()
        {
            while (_running)
            {
                Console.WriteLine("\nType a command. 'help' for information. 'q' or 'e' to exit.\n");
                Console.Write($"{_vfs.CurrentDirectory.Name}: $ ");
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
            UserInput parsedInput = new UserInput();
            parsedInput = _cp.ParseInput(input);

            switch(parsedInput.Command)
            {
                case "q":
                case "e":
                    _running = false;
                    break;
                case "help":
                    _uc.Help();
                    break;
                case "ls":
                    _uc.Ls(_vfs.CurrentDirectory.Id);
                    break;
                case "mkdir":
                    _dc.Mkdir(parsedInput.Option, _vfs.CurrentDirectory.Id);
                    break;
                default:
                    parsedInput.Command = "Invalid input";
                    break;
            }
            return parsedInput;
        }
    }
}
