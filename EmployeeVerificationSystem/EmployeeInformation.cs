﻿using EmployeeVerificationSystem.Interface;
using EmployeeVerificationSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
        public EmployeeInformation() { }

        public bool AddEmplyee(EmployeeInfo emp)
        {
            try
            {
                if (!(_context.EmployeeInfos.Any(x => x.Email == emp.Email || x.MobNo == emp.MobNo)))
                {
                    emp.Password = EncryptPassword(emp.Password);
                    _context.EmployeeInfos.Add(emp);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }

            catch { throw; }
        }

        public bool DeleteEmplyee(int eid)
        {
            try
            {
                var info = _context.EmployeeInfos.Where(x => x.EmpId == eid).FirstOrDefault();
                if (info != null)
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
                return _context.EmployeeInfos.Where(e => e.IsActive == true).ToList();
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
                var recordexist = _context.EmployeeInfos.Where(x => x.EmpId == emp.EmpId).FirstOrDefault();
                if (recordexist != null)
                {
                    recordexist.MobNo = emp.MobNo;
                    recordexist.Email = emp.Email;
                    recordexist.Name = emp.Name;
                    _context.EmployeeInfos.Update(recordexist);
                    var res = await _context.SaveChangesAsync();
                    return res;
                }
                else
                    return 0;
            }
            catch { throw; }
        }

        public bool ResetPassword(string email, string password)
        {
            try
            {
                var res = _context.EmployeeInfos.Where(x => x.Email == email).FirstOrDefault();
                if (res != null)
                {
                    res.Password = EncryptPassword(password);
                    _context.EmployeeInfos.Update(res);
                    _context.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
            catch { throw; }
        }

        public static string EncryptPassword(string password)
        {
            if (password == null)
                throw new ArgumentNullException("Plain Text");
            var encdata = Encoding.UTF8.GetBytes(password);
            string encodepwd = Convert.ToBase64String(encdata);
            return encodepwd;
        }
        public bool SendEmail(string toEmail)
        {
            SmtpClient smtpClient = new SmtpClient("DomainName.com", 25);

            smtpClient.Credentials = new System.Net.NetworkCredential("sendEmail@test.com", "password");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.Subject = "Password Reset";
            //Setting From , To and CC
            mail.From = new MailAddress("anuragverma@tavant.com", "Anurag Verma");
            mail.To.Add(new MailAddress(toEmail));
            smtpClient.Send(mail);
            return true;
        }

    }
}
