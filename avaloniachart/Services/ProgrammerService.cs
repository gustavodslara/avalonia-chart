using avaloniachart;
using avaloniachart.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xamarinchart.Models;

namespace xamarinchart.Services
{
    public class ProgrammerService
    {


        public ProgrammerService()
        {
        }

        private DatabaseContext GetContext()
        {
            return App.DatabaseContext;
        }

        public List<Programmer> GetAllProgrammers()
        {
            var _dbContext = GetContext();
            var res = _dbContext.Programmers.ToList();
            return res;
        } 
        public void SaveProgrammers(Programmer programmer)
        {
            var _dbContext = GetContext();
            _dbContext.Programmers.Add(programmer);
        }
    }
}
