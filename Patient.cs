using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst_WpfDemo
{
    public class Patient
    {
        [Key]
        public int PatientNo { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}
