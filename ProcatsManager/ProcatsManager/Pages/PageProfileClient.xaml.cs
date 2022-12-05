using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
using ProcatsManager.Windows;

namespace ProcatsManager.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProfileClient.xaml
    /// </summary>
    public partial class PageProfileClient : Page
    {
        int idUser = 0;
        DBProcatsEntities DBProcatsEntities = new DBProcatsEntities();
        Clients clients;
        int indexPage = 0;
        public PageProfileClient(int IdUser)
        {
            InitializeComponent();
            idUser = IdUser;
            clients = DBProcatsEntities.Clients.Where(b => b.IDClient == idUser).FirstOrDefault();
            tbkNameUser.Text = clients.Surname + " " + clients.Name + " " + clients.Patronimic;
        }
       
        private void btViewOrder_Click(object sender, RoutedEventArgs e)
        {
            FramePageClient.NavigationService.Navigate(new PageViewOrderClients(idUser, 0));
            indexPage = 1;
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            WindowAuthorization windowAuthorization = new WindowAuthorization(clients.Email);
            windowAuthorization.Show();
            App.mainWindow.Close();
        }

        private void btCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            FramePageClient.NavigationService.Navigate(new PageClientCreateOrder(idUser));
            indexPage = 2;
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            switch (indexPage)
            {
                case 1:
                    FramePageClient.NavigationService.Navigate(new PageViewOrderClients(idUser, 0));
                    break;
                case 2:
                    FramePageClient.NavigationService.Navigate(new PageClientCreateOrder(idUser));
                    break;
                case 3:
                    FramePageClient.NavigationService.Navigate(new PageViewServices(true));
                    break;
                default:
                    break;
            }
        }

        private void btViewServices_Click(object sender, RoutedEventArgs e)
        {
            FramePageClient.NavigationService.Navigate(new PageViewServices(true));
            indexPage = 3;
        }
    }
}
