using EmployeeVerificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVerificationSystem.Interface
{
    public interface IEducational
    {
        bool AddEducational(EducationalBackground educational);
        bool DeleteEducational(int EduId);
        List<EducationalBackground> GetEducationalList();
        EducationalBackground GetEducationalById(int EduId);
        Task<bool> UpdateEDucational(EducationalBackground educational);
    }
}
