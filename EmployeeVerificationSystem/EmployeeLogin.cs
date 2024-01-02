using EmployeeVerificationSystem.Interface;
using EmployeeVerificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVerificationSystem
{
    public class EmployeeLogin : IEmployeeLogin
    {

        readonly EmployeeContext _context;

        public EmployeeLogin(EmployeeContext context)
        {
            _context = context;
        }

        public bool AuthenticateEmployee(string Email, string Password)
        {
            try
            {
                Password = EmployeeInformation.EncryptPassword(Password);
                var info = _context.EmployeeInfos.Where(x => x.Email == Email && x.Password==Password).FirstOrDefault();
                if (info != null)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
