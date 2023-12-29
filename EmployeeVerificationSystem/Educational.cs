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
    public class Educational

    {
        readonly EmployeeContext _context;

        public Educational(EmployeeContext context)
        {
            _context = context;
        }
    }

    }

