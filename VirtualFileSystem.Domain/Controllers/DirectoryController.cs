using System;
using System.Collections.Generic;
using System.Text;
using VirtualFileSystem.Domain.Services;

namespace VirtualFileSystem.Domain.Controllers
{
    class DirectoryController
    {
        private readonly DirectoryService _ds;

        public DirectoryController(DirectoryService ds)
        {
            _ds = ds;
        }

    }
}
