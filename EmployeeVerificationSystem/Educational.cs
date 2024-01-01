using EmployeeVerificationSystem.Interface;
using EmployeeVerificationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVerificationSystem
{
    public class Educational: IEducational

    {
        readonly EmployeeContext _context;

        public Educational(EmployeeContext context)
        {
            _context = context;
        }

        public bool AddEducational(EducationalBackground educational)
        {
            try
            {
                _context.EducationalBackgrounds.Add(educational);
                _context.SaveChanges();
                return true;
            }
            catch { throw; }
        }



        public bool DeleteEducational(int EduId)
        {
            try
            {
                var info = _context.EducationalBackgrounds.Where(x => x.EduId == EduId).FirstOrDefault();
                if (info != null)
                {
                    info.IsActive = false;
                    
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { throw; }
        }

        public EducationalBackground GetEducationalById(int EduId)
        {
            try
            {
                return _context.EducationalBackgrounds.Where(x => x.EduId == EduId && x.IsActive == true).FirstOrDefault();
            }
            catch { throw; }
        }


        public List<EducationalBackground> GetEducationalList()
        {
            try
            {
                return _context.EducationalBackgrounds.Where(e=>e.IsActive==true).ToList();
            }
            catch { throw; }
        }

        public async Task<bool> UpdateEDucational(EducationalBackground educational)
        {
            try
            {
                var recordexist = _context.EducationalBackgrounds.Any(x => x.EduId == educational.EduId && x.IsActive==true);
                if (recordexist)
                {
                    //_context.Entry(educational).State = EntityState.Modified;
                    var res = await _context.SaveChangesAsync();
                    return res!=default(int) ? true : false;
                }
                else
                    return false;
            }
            catch { throw; }
        }
    }

    }

