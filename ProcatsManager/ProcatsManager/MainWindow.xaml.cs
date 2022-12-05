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
using ProcatsManager.Entities;
using ProcatsManager.Pages;

namespace ProcatsManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow(int IdUser, bool UserClient)
        {
            InitializeComponent();
            App.mainWindow = this;
            if (UserClient)
            {
              MainFraim.NavigationService.Navigate(new PageProfileClient(IdUser));
            }
            else
            {
                DBProcatsEntities dBProcatsEntities = new DBProcatsEntities();
                Emploees emploees = dBProcatsEntities.Emploees.Where(b => b.IDEmploee == IdUser).FirstOrDefault();
                emploees.LastEntrance = DateTime.Now;
                dBProcatsEntities.SaveChanges();
                MainFraim.NavigationService.Navigate(new PageProfileEmploees(IdUser));
            }  
        }
       
       
    }
}
