using EmployeeVerificationSystem.Interface;
using EmployeeVerificationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVerificationSystem
{
    public class CertificationBAL : ICertification
    {
        readonly EmployeeContext _context;

        public CertificationBAL(EmployeeContext context)
        {
            _context = context;
        }

        public string AddCertification(Certification cn)
        {
            try
            {
                _context.Certifications.Add(cn);
                var res = _context.SaveChanges();
                if (res > 0)
                    return "Certifications Added successfullly in database";
                else
                   return "Employee Not Added";
            }
            catch { throw; }

        }
        public List<Certification> GetCertificationByEmployeeId(int eid)
        {
            try
            {
               return _context.Certifications.Where(x=>x.IsActive && x.EmpId == eid).ToList();

            }
            catch { throw; }
        }

        public bool DeleteCertifaction(int cid)
        {
            try
            {
                var cdel = _context.Certifications.Where(x => x.Cid == cid && x.IsActive).FirstOrDefault();
                if (cdel != null)
                {
                    cdel.IsActive = false;
                    _context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch { throw; }

        }

        public async Task<int> UpdateCertification(Certification certification)
        {
            try
            {
                var recordexit = _context.Certifications.Where(x => x.Cid == certification.Cid).FirstOrDefault();
                if (recordexit != null)
                {
                    recordexit.Cname = certification.Cname;
                    _context.Certifications.Update(recordexit);
                    var res = await _context.SaveChangesAsync();
                    return res;
                }
                else
                    return 0;
            }
            catch { throw; };
        }
        
    }
}
