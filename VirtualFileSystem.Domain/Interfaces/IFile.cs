﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualFileSystem.Domain.Interfaces
{
    interface IFile
    {
        int Id { get; set; }
        string Name { get; set; }
        int DirectoryId { get; set; }
    }
}
