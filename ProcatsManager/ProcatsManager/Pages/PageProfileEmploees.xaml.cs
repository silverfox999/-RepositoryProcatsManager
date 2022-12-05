using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using ProcatsManager.Entities;
using ProcatsManager.Windows;

namespace ProcatsManager.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageProfileEmploees.xaml
    /// </summary>
    public partial class PageProfileEmploees : Page
    {
        int idUser = 0;
        int idJobTitle = 0;
        DBProcatsEntities DBProcatsEntities = new DBProcatsEntities();
        Emploees emploees;
        int indexPage = 0;

        public PageProfileEmploees(int IdUser)
        {
            InitializeComponent();
            idUser = IdUser;

            emploees = DBProcatsEntities.Emploees.Where(b => b.IDEmploee == idUser).FirstOrDefault();
            idJobTitle = (int)emploees.JobTitle;
            MemoryStream ms = new MemoryStream();
            ms.Write(emploees.Photo, 0, emploees.Photo.Length);
            ms.Seek(0, SeekOrigin.Begin);
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.StreamSource = ms;
            bmp.EndInit();
            imgPhoto.Source = bmp;
            switch (idJobTitle)
            {
                case 1:
                    tbkNameUser.Text = "Продваец\n";
                    btViewAndCreateOrder.Visibility = Visibility.Visible;
                    btViewOrder.Visibility = Visibility.Visible;
                    break;
                case 2:
                    tbkNameUser.Text = "Старший смены\n";
                    btViewAndCreateOrder.Visibility = Visibility.Visible;
                    btViewOrder.Visibility = Visibility.Visible;
                    btCloseOrder.Visibility = Visibility.Visible;
                    break;
                case 3:
                    tbkNameUser.Text = "Администратор\n";
                    spActionAdmin.Visibility = Visibility.Visible;
                    break;
                default:
                    break; 
            }
            tbkNameUser.Text += emploees.Surname + " " + emploees.Name + " " + emploees.Patronimic;
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        DispatcherTimer timer = new DispatcherTimer();
        int s = 0, m = 10, h = 0;

        private void timer_Tick(object sender, EventArgs e)
        {
            s--;
            if (s < 1)
            {
                m--;
                s = 59;
                //if (m == 4 && s == 59)
                //{
                //    MessageBox.Show("До завершения сеанса осталось 5 минут.");
                //}
                if (m <= 0 && s <= 0)
                {
                    s = 0;
                    m = 0;
                    timer.Stop();
                    MessageBox.Show("Сеанс завершён.");
                    App.mainWindow.Close();
                }         
                if (m < 1)
                {
                    m = 59;
                    h--;
                }
            }
            tbkTime.Text = $"{h}:{m}:{s}";
        }
    

    private void btViewOrder_Click(object sender, RoutedEventArgs e)
        {
            FramePageEmploee.NavigationService.Navigate(new PageViewOrderClients(idUser, 1));
            indexPage = 1;
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            WindowAuthorization windowAuthorization = new WindowAuthorization(emploees.E_mail);
            windowAuthorization.Show();
            App.mainWindow.Close();
        }

        private void btViewAndCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            FramePageEmploee.NavigationService.Navigate(new PageViewOrderClients(idUser, 2));
            indexPage = 2;
        }

        private void btReset_Click(object sender, RoutedEventArgs e)
        {
            switch (indexPage)
            {
                case 1:
                    btViewOrder_Click(sender, e);
                    break;
                case 2:
                    btViewAndCreateOrder_Click(sender, e);
                    break;
                case 3:
                    btCloseOrder_Click(sender, e);
                    break;
                case 4:
                    btEditServices_Click(sender, e);
                    break;
                case 5:
                    btHistoryUsers_Click(sender, e);
                    break;
                case 6:
                    btViewOrders_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void btCloseOrder_Click(object sender, RoutedEventArgs e)
        {
            FramePageEmploee.NavigationService.Navigate(new PageViewOrderClients(idUser, 3));
            indexPage = 3;
        }

        private void btViewOrders_Click(object sender, RoutedEventArgs e)
        {
            FramePageEmploee.NavigationService.Navigate(new PageViewOrderClients(idUser, 4));
            indexPage = 6;
        }

        private void btEditServices_Click(object sender, RoutedEventArgs e)
        {
            FramePageEmploee.NavigationService.Navigate(new PageViewServices(false));
            indexPage = 4;
        }

        private void btHistoryUsers_Click(object sender, RoutedEventArgs e)
        {
            FramePageEmploee.NavigationService.Navigate(new PageHistoryEntranceUsers());
            indexPage = 5;
        }
    }
}
