using EmployeeVerificationSystem.Interface;
using EmployeeVerificationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVerificationSystem
{
    public class WokExperience : IWorkExp
    {
        readonly EmployeeContext _context;
        public WokExperience(EmployeeContext context) {
            _context = context;
        }
        public bool AddWorkExp(WorkExperience workExperience)
        {

            try
            {
                _context.WorkExperiences.Add(workExperience);
                _context.SaveChanges();
                return true;
            }catch {
                throw;
            }
        }

        public bool DeleteWorkExp(int CId)
        {
            try
            {
                var info = _context.WorkExperiences.Where(x => x.Cid == CId).FirstOrDefault();
                if (info != null)
                {
                    info.IsActive = false;
                    // _context.WorkExperiences.Remove(info);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { throw; }
        }

        public List<WorkExperience> GetWorkExpByEmpId(int EmpId)
        {
            try
            {
                return _context.WorkExperiences.Where(x => x.EmpId == EmpId && x.IsActive == true).ToList();
            }
            catch { throw; }
        }

        public List<WorkExperience> GetWorkExpList()
        {
            try
            {
                return _context.WorkExperiences.Where(e => e.IsActive == true).ToList();
            }
            catch { throw; }
        }

        public async Task<int> UpdateWorkExp(WorkExperience workExperience)
        {
            try
            {
                var recordexist = _context.WorkExperiences.Any(x => x.Cid == workExperience.Cid);
                if (recordexist)
                {
                    _context.Entry(workExperience).State = EntityState.Modified;
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
