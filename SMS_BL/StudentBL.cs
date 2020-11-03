using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS_Entitie;
using SMS_Exception;
using SMS_BL;
using SMS_DAL;

namespace SMS_BL
{
    public class StudentBL
    {
        //cloning
        StudentDAO sDao = null;
        public StudentBL()
        {
            sDao = new StudentDAO();
        }
        public List<Student> ShowAllStudent()
        {
            //write logic here
            return sDao.ShowAllStudent();
        }
        public List<String> ShowAllNames()
        {
            return sDao.ShowAllNames();
        }
        public List<Student> SearchStudentByID(int id)
        {
            return sDao.SearchStudentByID(id);
        }
        public bool AddStudent(Student s1)
        {
            return sDao.AddStudent(s1);
        }
        public bool UpdateStudent(Student s1)
        {
            return sDao.UpdateStudent(s1);
        }
        public bool DropStudent(int id)
        {
            return sDao.DropStudent(id);
        }
    }
}
