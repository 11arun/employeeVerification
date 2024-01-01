using EmployeeVerificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVerificationSystem.Interface
{
    public interface IWorkExp
    {
        List <WorkExperience>  GetWorkExpByEmpId(int EmpId);
        bool AddWorkExp(WorkExperience workExperience);
        List<WorkExperience> GetWorkExpList();
        bool DeleteWorkExp(int empId);
        Task<int> UpdateWorkExp(WorkExperience workExperience);




    }
}
