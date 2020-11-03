using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Entitie
{
    public class Student
    {
        #region Variable
        int rollNo;
        string name;
        string addr;

        #endregion
        #region Properties
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string Addr { get; set; }
        #endregion
        #region Constructors
        public Student()
        {

        }
        public Student(int rollNo, string name, string addr)
        {
            this.rollNo = rollNo;
            this.name = name;
            this.addr = addr;
        }
        #endregion
    }
}
