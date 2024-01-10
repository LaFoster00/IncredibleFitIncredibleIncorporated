using IncredibleFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncredibleFit.SQL
{
    public class SQLProfile
    {
        private User _currentUser = null;

        public SQLProfile() 
        {
            //Get User fron Database
            _currentUser = new User("Max Mustermann", 100.5, 1.87, 15.4, 4302, new Aim("Zunehmen", 110.0), "Fortgeschritten");
        }
        public User getUser()
        {
            return _currentUser;
        }

    }
}
