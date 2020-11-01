using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_WpfDemo
{
    class DonorContext : DbContext
    {
        public DonorContext() : base()
        {

        }
        public DonorContext(string conStr) : base(conStr)
        {

        }
        public DbSet<Donor> Donors { get; set; }
    }
    class PatientContext : DbContext
    {
        public PatientContext() : base()
        {

        }
        public PatientContext(string conStr):base(conStr)
        {

        }
        public DbSet<Patient> Patients { get; set; }
    }
}
