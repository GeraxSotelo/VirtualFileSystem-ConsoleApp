using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ConsoleApp;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;
using VirtualFileSystem.Domain.Models;

namespace VirtualFileSystem.Tests
{
    public class GetUserInputTests
    {
        private readonly ProgramExecuter _pe;
        private readonly CommandParser _cp;

        public GetUserInputTests()
        {
            _pe = new ProgramExecuter();
            _cp = new CommandParser();
        }

        [Theory]
        [InlineData("MkDiR ", "mkdir")]
        [InlineData("haha ", "Invalid input")]
        [InlineData(" ", "Invalid input")]
        public void ValidUserInput(string userInput, string expected)
        {
            UserInput actual = _pe.AnalyzeInput(userInput);

            Assert.Equal(expected, actual.Command);
        }

        [Theory]
        [InlineData("MkDiR ", "mkdir")]
        [InlineData("HELP ", "help")]
        public void CommandParserValidCommandOutput(string userInput, string expected)
        {
            UserInput actual = _cp.ParseInput(userInput);

            Assert.Equal(expected, actual.Command);
        }
        
        [Theory]
        [InlineData("touch file", "file")]
        [InlineData("touch my new file", "my new file")]
        public void CommandParserValidOptionOutput(string userInput, string expected)
        {
            UserInput actual = _cp.ParseInput(userInput);

            Assert.Equal(expected, actual.Option);
        }
    }
}
