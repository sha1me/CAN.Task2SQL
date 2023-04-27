using CAN.Task2SQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAN.Task2SQL.Core
{
    public static class DbModelContext
    {
        public static RegistrationEntities db = new RegistrationEntities();
    }
}
