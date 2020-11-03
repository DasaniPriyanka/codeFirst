using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SMS_Entitie;
using SMS_Exception;


namespace SMS_DAL
{
    public class StudentDAO
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;
        List<Student> myStudents = null;
        DataTable mydt = null;
        public StudentDAO()
        {
            con = new SqlConnection();
            con.ConnectionString = "Server=.;Integrated Security=true;Database=Student";

        }
        public List<Student> ShowAllStudent() {
            //write logic here
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "select * from student_info";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                sdr = cmd.ExecuteReader();
                mydt = new DataTable();
                mydt.Load(sdr);
                if (mydt.Rows.Count > 0)
                {
                    myStudents = new List<Student>();
                    foreach(DataRow rw in mydt.Rows)
                    {
                        Student s1 = new Student();
                        s1.RollNo =Int32.Parse(rw[0].ToString());
                        s1.Name = rw[1].ToString();
                        s1.Addr = rw[2].ToString();
                        myStudents.Add(s1);

                    }
                }
            }
            catch (SqlException se)
            {
                throw new SMSException(se.Message);
            }
            catch(Exception e)
            {
                throw new SMSException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return myStudents;
        }
        public List<String> ShowAllNames()
        {
            List<string> myStudentsName=null;
            //write logic here
            try
            {
                
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "select Name from student_info";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                sdr = cmd.ExecuteReader();
                mydt = new DataTable();
                mydt.Load(sdr);
                if (mydt.Rows.Count > 0)
                {
                    myStudentsName = new List<String>();
                    foreach (DataRow rw in mydt.Rows)
                    {
                        //Student s1 = new Student();
                        //s1.RollNo = Int32.Parse(rw[0].ToString());
                        //s1.Name = rw[1].ToString();
                        //s1.Addr = rw[2].ToString();
                        string s1 = rw[0].ToString();
                        myStudentsName.Add(s1);

                    }
                }
            }
            catch (SqlException se)
            {
                throw new SMSException(se.Message);
            }
            catch (Exception e)
            {
                throw new SMSException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return myStudentsName;
        }
        public List<Student> SearchStudentByID(int id)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                SqlParameter p1 = new SqlParameter("@rno", id);
                cmd.CommandText = "select * from student_info where RollNo=@rno";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add(p1);
                sdr = cmd.ExecuteReader();
                mydt = new DataTable();
                mydt.Load(sdr);
                if (mydt.Rows.Count > 0)
                {
                    myStudents = new List<Student>();
                    foreach (DataRow rw in mydt.Rows)
                    {
                        Student s1 = new Student();
                        s1.RollNo = Int32.Parse(rw[0].ToString());
                        s1.Name = rw[1].ToString();
                        s1.Addr = rw[2].ToString();
                        myStudents.Add(s1);

                    }
                }
                else
                {
                    throw new SMSException("Roll No. doesn't exist.");
                }
            }
            catch (SqlException se)
            {
                throw new SMSException(se.Message);
            }
            catch (Exception e)
            {
                throw new SMSException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return myStudents;
        }
        public bool AddStudent(Student s1)
        {
            bool b=false;
            try
            {
                con.Open();
                cmd = new SqlCommand();
                SqlParameter p1 = new SqlParameter("@rno", s1.RollNo);
                SqlParameter p2 = new SqlParameter("@name", s1.Name);
                SqlParameter p3 = new SqlParameter("@addr", s1.Addr);
                cmd.CommandText = "insert into student_info(RollNo,Name,Address) values(@rno,@name,@addr)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                int r=cmd.ExecuteNonQuery();
                if (r > 0)
                    b = true;
                else
                    b = false;
            }
            catch (SqlException se)
            {
                throw new SMSException(se.Message);
            }
            catch (Exception e)
            {
                throw new SMSException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return b;
        }
        public bool UpdateStudent(Student s1)
        {
            bool b = false;
            try
            {
                con.Open();
                cmd = new SqlCommand();
                SqlParameter p1 = new SqlParameter("@rno", s1.RollNo);
                SqlParameter p2 = new SqlParameter("@name", s1.Name);
                SqlParameter p3 = new SqlParameter("@addr", s1.Addr);
                cmd.CommandText = "update table student_info set Name=@name,Address=@addr where RollN0=@rno";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    b = true;
                else
                    b = false;
            }
            catch (SqlException se)
            {
                throw new SMSException(se.Message);
            }
            catch (Exception e)
            {
                throw new SMSException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return b;
        }
        public bool DropStudent(int id)
        {
            bool b = false;
            try
            {
                con.Open();
                cmd = new SqlCommand();
                SqlParameter p1 = new SqlParameter("@rno", id);
                cmd.CommandText = "delete from student_info where RollNo=@rno";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add(p1);
                int r = cmd.ExecuteNonQuery();
                if (r>0)
                {
                    b = true;
                }
                else
                {
                    throw new SMSException("Roll No. doesn't exist.");
                }
            }
            catch (SqlException se)
            {
                throw new SMSException(se.Message);
            }
            catch (Exception e)
            {
                throw new SMSException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return b;
        }
    }
}
