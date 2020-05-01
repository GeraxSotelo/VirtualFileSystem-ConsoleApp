using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualFileSystem.Domain.Models
{
    public class CommandParser
    {
        UserInput Input = new UserInput();

        public UserInput ParseInput(string input)
        {
            Input.Command = input.Substring(0, input.IndexOf(" ")).ToLower();
            Input.Option = input.Substring(input.IndexOf(" ") + 1).Trim();
            return Input;
        }
    }
}

