﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualFileSystem.Domain
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentDirectoryId { get; set; }
    }
}
