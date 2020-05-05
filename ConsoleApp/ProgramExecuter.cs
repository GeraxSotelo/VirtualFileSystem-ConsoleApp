using ConsoleApp.Controllers;
using System;
using VirtualFileSystem.Domain;
using VirtualFileSystem.Domain.Models;

namespace ConsoleApp
{
    public class ProgramExecuter
    {
        private bool _running = true;
        private Directory _root;
        private CommandParser _cp = new CommandParser();
        private readonly FileSystem _vfs;
        private readonly UtilitiesController _uc = new UtilitiesController();
        private readonly DirectoriesController _dc = new DirectoriesController();
        private readonly FilesController _fc = new FilesController();

        public ProgramExecuter()
        {
            _root = GetRootDirectory();
            _vfs = new FileSystem(_root);
        }

        public Directory GetRootDirectory()
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

        public void GetUserInput()
        {
            string input = Console.ReadLine() + " ";
            AnalyzeInput(input);
        }

        public UserInput AnalyzeInput(string input)
        {
            UserInput parsedInput = new UserInput();
            parsedInput = _cp.ParseInput(input);
            int currDirId = _vfs.CurrentDirectory.Id;

            switch(parsedInput.Command)
            {
                case "q":
                case "e":
                    _running = false;
                    break;
                case "help":
                case "ls":
                    _uc.AnalyzeInput(parsedInput.Command, currDirId);
                    break;
                case "cd":
                    var dir = _dc.AnalyzeInput(parsedInput, currDirId);
                    _vfs.CurrentDirectory = dir;
                    break;
                case "mkdir":
                case "md":
                case "rmdir":
                case "rd":
                    _dc.AnalyzeInput(parsedInput, currDirId);
                    break;
                case "touch":
                case "rm":
                    _fc.AnalyzeInput(parsedInput, currDirId);
                    break;
                default:
                    parsedInput.Command = "---Invalid Command---";
                    Console.WriteLine(parsedInput.Command);
                    break;
            }
            return parsedInput;
        }
    }
}
