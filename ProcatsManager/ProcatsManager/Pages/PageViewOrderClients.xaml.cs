using ProcatsManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Логика взаимодействия для PageViewOrderClients.xaml
    /// </summary>
    public partial class PageViewOrderClients : Page
    {
        int idUser = 0;
        DBProcatsEntities DBProcatsEntities = new DBProcatsEntities();
        Orders orders;

        public PageViewOrderClients(int IdUser, int IdAction)
        {
            InitializeComponent();
            idUser = IdUser;
            switch (IdAction)
            {
                case 0:
                    var query = (from Orders in DBProcatsEntities.Orders
                                 from OrderStatus in DBProcatsEntities.OrderStatus
                                 from Clients in DBProcatsEntities.Clients
                                 where Clients.IDClient == idUser &&
                                 Orders.CodeClient == idUser &&
                                 Orders.Status == OrderStatus.IDOrderStatus
                                 select new
                                 {
                                     ДатаСоздания = Orders.DataCrate + " / " + Orders.TimeOrder,
                                     ВремяАренды = Orders.TimeRental,
                                     Статус = OrderStatus.Name
                                 }).Distinct().ToList();
                    dgOrders.ItemsSource = query;
                    break;
                case 1:
                    createDataGridOrder(3);
                    break;
                case 2:
                   createDataGridOrder(1);
                    Grid.SetRowSpan(dgOrders, 1);
                    btCreateOrder.Visibility = Visibility.Visible;
                    break;
                case 3:
                    createDataGridOrder(2);
                    Grid.SetRowSpan(dgOrders, 1);
                    btCloseOrder.Visibility = Visibility.Visible;
                    break;
                case 4:
                    Grid.SetRowSpan(dgOrders, 1);
                    spActionAdmin.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }  

        }

        private void btCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrders.SelectedItems != null)
            {
                string[] massElements = ConvertDataFromDataGrid(dgOrders);
                string curentElement = massElements[2];
                orders = DBProcatsEntities.Orders.Where(b => b.CodeOrder == curentElement).FirstOrDefault();
                orders.Status = 2;
                DBProcatsEntities.SaveChanges();
                createDataGridOrder(1);
                MessageBox.Show("Заказ принят.");
            }
        }

        public void createDataGridOrder(int IdStatus)
        {
            switch (IdStatus)
            {
                case 3:
                    var queryOrderStatus3 = (from Orders in DBProcatsEntities.Orders
                                             from OrderStatus in DBProcatsEntities.OrderStatus
                                             from Clients in DBProcatsEntities.Clients
                                             where Orders.CodeClient == Clients.IDClient &&
                                             Orders.Status == OrderStatus.IDOrderStatus &&
                                             Orders.Status == IdStatus
                                             select new
                                             {
                                                 Клиент = Clients.Surname + " " + Clients.Name + " " + Clients.Patronimic,
                                                 НомерКлиента = Clients.IDClient,
                                                 НомерЗаказа = Orders.CodeOrder,
                                                 ДатаСоздания = Orders.DataCrate + " / " + Orders.TimeOrder,
                                                 ДатаЗакрытия = Orders.DataClosing,
                                                 ВремяАренды = Orders.TimeRental,
                                                 Статус = OrderStatus.Name
                                             }).Distinct().ToList();
                    dgOrders.ItemsSource = queryOrderStatus3;
                    break;
                default:
                    var queryOrderStatus = (from Orders in DBProcatsEntities.Orders
                                             from OrderStatus in DBProcatsEntities.OrderStatus
                                             from Clients in DBProcatsEntities.Clients
                                             where Orders.CodeClient == Clients.IDClient &&
                                             Orders.Status == OrderStatus.IDOrderStatus &&
                                             Orders.Status == IdStatus
                                            select new
                                             {
                                                 Клиент = Clients.Surname + " " + Clients.Name + " " + Clients.Patronimic,
                                                 НомерКлиента = Clients.IDClient,
                                                 НомерЗаказа = Orders.CodeOrder,
                                                 ДатаСоздания = Orders.DataCrate + " / " + Orders.TimeOrder,
                                                 ВремяАренды = Orders.TimeRental,
                                                 Статус = OrderStatus.Name
                                             }).Distinct().ToList();
                    dgOrders.ItemsSource = queryOrderStatus;
                    break;
            }
        }

        private void btCloseOrder_Click(object sender, RoutedEventArgs e)
        {
            if (dgOrders.SelectedItems != null)
            {
                string[] massElements = ConvertDataFromDataGrid(dgOrders);
                string curentElement = massElements[2];
                orders = DBProcatsEntities.Orders.Where(b => b.CodeOrder == curentElement).FirstOrDefault();
                orders.Status = 3;
                DateTime dateTime = DateTime.Now;
                orders.DataClosing = dateTime.Date;
                DBProcatsEntities.SaveChanges();
                createDataGridOrder(2);
                MessageBox.Show("Заказ закрыт.");
            }
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

        private void btNotAcceptedOrders_Click(object sender, RoutedEventArgs e)
        {
            createDataGridOrder(1);
        }

        private void btCloseOrders_Click(object sender, RoutedEventArgs e)
        {
            createDataGridOrder(3);
        }

        private void btOrdersInRental_Click(object sender, RoutedEventArgs e)
        {
            createDataGridOrder(2);
        }
    }
}
