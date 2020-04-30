using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using VirtualFileSystem.Data;
using VirtualFileSystem.Domain;

namespace VirtualFileSystem.Tests
{
    public class BusinessDataLogic
    {
        private FileSystemContext _context;

        public BusinessDataLogic()
        {
            _context = new FileSystemContext();
        }
        public BusinessDataLogic(FileSystemContext context)
        {
            _context = context;
        }

        public int Mkdir(Directory directory)
        {
            _context.Directories.Add(directory);
            //returns number of rows affected
            var dbResult = _context.SaveChanges();
            return dbResult;
        }
    }
}
