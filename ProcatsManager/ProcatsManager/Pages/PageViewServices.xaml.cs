using ProcatsManager.Entities;
using System;
using System.Collections.Generic;
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


namespace ProcatsManager.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageViewServices.xaml
    /// </summary>
    public partial class PageViewServices : Page
    {
        DBProcatsEntities dBProcatsEntities = new DBProcatsEntities();
        public PageViewServices(bool UserClient)
        {
            InitializeComponent();
            if (UserClient)
            {
                var query = (from Services in dBProcatsEntities.Services
                             select new
                             {
                                 Название = Services.Name,
                                 ЦенаВЧас = Services.СostPerHour
                             }).Distinct().ToList();

                dgServices.ItemsSource = query;
            }
            else
            {
                var query = (from Services in dBProcatsEntities.Services
                             select new
                             {
                                 Название = Services.Name,
                                 Код_услуги = Services.CodeServices,
                                 ЦенаВЧас = Services.СostPerHour
                             }).Distinct().ToList();

                dgServices.ItemsSource = query;
               spActionAdmin.Visibility = Visibility.Visible;
                Grid.SetRowSpan(dgServices, 1);
            }
        }

        private void btDeleteServices_Click(object sender, RoutedEventArgs e)
        {
            if (dgServices.SelectedItems != null)
            {
                try
                {
                    string[] massElements = ConvertDataFromDataGrid(dgServices);
                    string curentElement = massElements[1];
                    Services services;
                    services = dBProcatsEntities.Services.Where(b => b.Name == curentElement).FirstOrDefault();
                    ServicesOrder servicesOrder;
                    int countServicesInOrders = dBProcatsEntities.ServicesOrder.Where(b => b.Service == services.IDService).ToArray().Count();
                    for (int i = 0; i < countServicesInOrders; i++)
                    {
                        servicesOrder = dBProcatsEntities.ServicesOrder.Where(b => b.Service == services.IDService).ToArray().ElementAt(i);
                        dBProcatsEntities.ServicesOrder.Remove(servicesOrder);
                        dBProcatsEntities.SaveChanges();
                    }
                    dBProcatsEntities.Services.Remove(services);
                    dBProcatsEntities.SaveChanges();
                    MessageBox.Show("Услуга удалена.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Услуга не найдена.");
                }
            }
            else
            {
                MessageBox.Show("Выбурите услугу.");
            }

        }

        private void btEditServices_Click(object sender, RoutedEventArgs e)
        {
            if (dgServices.SelectedItems != null)
            {
                try
                {
                    string[] massElements = ConvertDataFromDataGrid(dgServices);
                    string curentElement = massElements[1];
                    Services services;
                    services = dBProcatsEntities.Services.Where(b => b.CodeServices == curentElement).FirstOrDefault();
                    if (services != null)
                    {
                        NavigationService.Navigate(new PageCreateServices(services.IDService));
                    }
                    else
                    {
                        MessageBox.Show("Услуга не найдена.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Услуга не найдена.");
                }
            }
            else
            {
                MessageBox.Show("Выбурите услугу.");
            }
           
        }

        private void btCreateServices_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageCreateServices());
        }

        public string[] ConvertDataFromDataGrid(DataGrid dataGrid)
        {
            string[] masElementDataGrtid = new String[dataGrid.Columns.Count()];
            string rowDataGrid = dataGrid.SelectedItem.ToString();
            bool reedRowDataGrid = false;
            int indexElementMas = 0;

            for (int i = 0; i < rowDataGrid.Length; i++)
            {
                if (rowDataGrid[i] == '=')
                {
                    reedRowDataGrid = true;
                    i++;
                }
                else
                {
                    if (rowDataGrid[i] == ',')
                    {
                        reedRowDataGrid = false;
                        indexElementMas++;
                    }
                    else
                    {
                        if (rowDataGrid[i] == '}')
                        {
                            reedRowDataGrid = false;
                        }
                        else
                        {
                            if (reedRowDataGrid)
                            {
                                masElementDataGrtid[indexElementMas] += rowDataGrid[i];
                            }
                        }
                    }
                }
            }
            return masElementDataGrtid;
        }
    }
}
