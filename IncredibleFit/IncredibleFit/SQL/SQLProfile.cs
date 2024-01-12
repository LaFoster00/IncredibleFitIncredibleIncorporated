using IncredibleFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncredibleFit.SQL.Entities;

namespace IncredibleFit.SQL
{
    public class SQLProfile
    {
        private User _currentUser = null;

        public SQLProfile()
        {
            //Get User fron Database
            _currentUser = new User("maxmustermann@test.de","Mustermann","Max", 100.5f, 1.87f, 15.4f, 4302);
        }
        public User getUser()
        {
            return _currentUser;
        }

    }
}