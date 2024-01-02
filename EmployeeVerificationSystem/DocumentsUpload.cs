using EmployeeVerificationSystem.Models;
using Microsoft.AspNetCore.Http;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using EmployeeVerificationSystem.Interface;
namespace EmployeeVerificationSystem
{
    public class DocumentsUpload : IDocumentsUpload
    {
        readonly EmployeeContext _employeeContext;
        public DocumentsUpload(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public async Task UploadFileToS3(IFormFile file)
        {
            using (var client = new AmazonS3Client("AKIA2S3Y3LOUCFEYYTN5", "6jvAlzvnxzFcU3FEby/oX5XIF+eGs9S3Frn52BNO", RegionEndpoint.USEast1))
            {
                using (var newMemoryStream = new MemoryStream())
                {
                    file.CopyTo(newMemoryStream);

                    var uploadRequest = new TransferUtilityUploadRequest
                    {
                        InputStream = newMemoryStream,
                        Key = file.FileName,
                        BucketName = "employeeverify",
                        CannedACL = S3CannedACL.PublicRead,
                        
                    };

                    var fileTransferUtility = new TransferUtility(client);
                    await fileTransferUtility.UploadAsync(uploadRequest);
                }
            }
        }
    }
    }



    
