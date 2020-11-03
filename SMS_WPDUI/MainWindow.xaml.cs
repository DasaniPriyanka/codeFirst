using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using SMS_BL;
using SMS_Entitie;
using SMS_Exception;

namespace SMS_WPDUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentBL sbl;
        Student sobj;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sbl = new StudentBL();
                sobj = new Student();
                sobj.RollNo = Int32.Parse(txtRollNo.Text);
                sobj.Name = txtName.Text;
                sobj.Addr = txtAddress.Text;
                bool res = sbl.AddStudent(sobj);
                if (res)
                    System.Windows.Forms.MessageBox.Show("Record Added");
            }
            catch(SMSException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message,"Student Management System");
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message, "Student Management System");
            }
        }

        private void btnAlter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sbl = new StudentBL();
                sobj = new Student();
                sobj.RollNo = Int32.Parse(txtRollNo.Text);
                sobj.Name = txtName.Text;
                sobj.Addr = txtAddress.Text;
                bool res = sbl.UpdateStudent(sobj);
                if (res)
                    System.Windows.Forms.MessageBox.Show("Record Updated");
            }
            catch (SMSException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message, "Student Management System");
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message, "Student Management System");
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sbl = new StudentBL();
                sobj = new Student();
                sobj.RollNo = Int32.Parse(txtRollNo.Text);
                //sobj.Name = txtName.Text;
                //sobj.Addr = txtAddress.Text;
                List<Student> res = sbl.SearchStudentByID(sobj.RollNo);
                dataGrid.ItemsSource = res;
            }
            catch (SMSException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message, "Student Management System");
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message, "Student Management System");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sbl = new StudentBL();
                sobj = new Student();
                sobj.RollNo = Int32.Parse(txtRollNo.Text);
                //sobj.Name = txtName.Text;
                //sobj.Addr = txtAddress.Text;
                bool res = sbl.DropStudent(sobj.RollNo);
                if (res)
                    System.Windows.Forms.MessageBox.Show("Record Deleted");
            }
            catch (SMSException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message, "Student Management System");
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message, "Student Management System");
            }
        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sbl = new StudentBL();
                sobj = new Student();
                //sobj.RollNo = Int32.Parse(txtRollNo.Text);
                //sobj.Name = txtName.Text;
                //sobj.Addr = txtAddress.Text;
                List<Student> res = sbl.ShowAllStudent();
                dataGrid.ItemsSource = res;
                
            }
            catch (SMSException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message, "Student Management System");
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message, "Student Management System");
            }
        }

    }
}
