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

namespace EF_CodeFirst_WpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddDonor_Click(object sender, RoutedEventArgs e)
        {
            //DonorContext dbCon = new DonorContext("server=.;Integrated Security=true;Database=Sept23");
            //Donor dObj = new Donor();
            //dObj.DonorID = 101;
            //dObj.Name = "Raman";
            //dObj.BloodGrp = "A+";
            //dObj.City = "Delhi";
            ////Adding data to the table
            //dbCon.Donors.Add(dObj);
            //Commiting changes
            PatientContext dbCon = new PatientContext("server=.;Integrated Security=true;Database=Sept23");
            Patient pObj = new Patient();
            pObj.PatientNo = 101;
            pObj.Name = "Alok";
            pObj.City = "Delhi";
            dbCon.Patients.Add(pObj);
            dbCon.SaveChanges();
            System.Windows.Forms.MessageBox.Show("Donor Table created\n 1 Record added");
        }
    }
}
