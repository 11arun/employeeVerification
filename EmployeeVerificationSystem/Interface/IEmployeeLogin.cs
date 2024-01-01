using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVerificationSystem.Interface
{
    public interface IEmployeeLogin
    {
        bool AuthenticateEmployee(string Email, string password);
    }
}
