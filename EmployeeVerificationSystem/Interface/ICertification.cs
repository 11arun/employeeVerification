using EmployeeVerificationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVerificationSystem.Interface
{
    public interface ICertification
    {
        string AddCertification(Certification cn);
        List<Certification> GetCertificationByEmployeeId(int eid);
        bool DeleteCertifaction(int cid);
        Task<int> UpdateCertification(Certification certification);
    }
}
