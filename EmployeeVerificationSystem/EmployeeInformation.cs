using EmployeeVerificationSystem.Interface;
using EmployeeVerificationSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVerificationSystem
{
    public class EmployeeInformation : IEmployeeInfo
    {
        readonly EmployeeContext _context;

        public EmployeeInformation(EmployeeContext context)
        {
            _context = context;
        }

        public bool AddEmplyee(EmployeeInfo emp)
        {
            try
            {
                _context.EmployeeInfos.Add(emp);
                _context.SaveChanges();
                return true;
            }

            catch { throw; }
        }

        public bool DeleteEmplyee(int eid)
        {
            try
            {
                var info = _context.EmployeeInfos.Where(x => x.EmpId == eid).FirstOrDefault();
                if(info != null)
                {
                    info.IsActive = false;
                   // _context.EmployeeInfos.Remove(info);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { throw; }
        }

        public List<EmployeeInfo> GetEmplyeeList()
        {
            try
            {
                return _context.EmployeeInfos.Where(e=>e.IsActive==true).ToList();
            }
            catch { throw; }
        }

        public EmployeeInfo GetEmployeeById(int eid)
        {
            try
            {
                return _context.EmployeeInfos.Where(x => x.EmpId == eid && x.IsActive == true).FirstOrDefault();
            }
            catch { throw; }
        }

        public async Task<int> UpdateEmployee(EmployeeInfo emp)
        {
            try
            {
                var recordexist = _context.EmployeeInfos.Any(x => x.EmpId == emp.EmpId);
                if (recordexist)
                {
                    _context.Entry(emp).State = EntityState.Modified;
                    var res = await _context.SaveChangesAsync();
                    return res;

                }
                else
                    return 0;
            }
            catch { throw; }
        }

    }
}
