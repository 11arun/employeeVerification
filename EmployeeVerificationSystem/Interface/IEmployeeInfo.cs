using EmployeeVerificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVerificationSystem.Interface
{
    public interface IEmployeeInfo
    {
        bool AddEmplyee(EmployeeInfo emp);
        bool DeleteEmplyee(int eid);
        List<EmployeeInfo> GetEmplyeeList();
        EmployeeInfo GetEmployeeById(int eid);
        Task<int> UpdateEmployee(EmployeeInfo emp);
        public bool ResetPassword(string email, string password);
        bool SendEmail(string toEmail);
    }
}
