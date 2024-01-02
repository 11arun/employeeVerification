using EmployeeVerificationSystem.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeVerificationSystem.Interface
{
    public interface IDocumentsUpload
    {
        Task UploadFileToS3(IFormFile file);
    }
}
