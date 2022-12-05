using ProcatsManager.Entities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ProcatsManager.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageClientCreateOrder.xaml
    /// </summary>
    public partial class PageClientCreateOrder : Page
    {
        int idUser = 0;
        int indexNameComboBoxs = 2;
        DBProcatsEntities DBProcatsEntities = new DBProcatsEntities();
        Clients clients;
        public PageClientCreateOrder(int IdUser)
        {
            InitializeComponent();
            idUser = IdUser;
            massComboBoxs[0] = cbService1;
            cbService1.ItemsSource = DBProcatsEntities.Services.ToList();
            cbService1.SelectedIndex = 0;
            clients = DBProcatsEntities.Clients.Where(b => b.IDClient == idUser).FirstOrDefault();
        }
        ComboBox[] massComboBoxs = new ComboBox[100];
        private void btPlusServices_Click(object sender, RoutedEventArgs e)
        {

            if (indexNameComboBoxs < DBProcatsEntities.Services.ToArray().Count())
            {
                ComboBox comboBox = new ComboBox();
                comboBox.Name = "cbService" + indexNameComboBoxs;
                indexNameComboBoxs++;
                comboBox.DisplayMemberPath = "Name";
                comboBox.Width = 240;
                comboBox.Height = 30;
                comboBox.FontSize = 22;
                comboBox.Margin = new Thickness(3, 3, 3, 3);
                comboBox.ItemsSource = DBProcatsEntities.Services.ToList();
                comboBox.SelectedIndex = 0;
                massComboBoxs[indexNameComboBoxs - 2] = comboBox;
                spServices.Children.Add(comboBox);
            }
            else
            {
                MessageBox.Show("Вы достигли лимита выбора услуг.");
            }
        }

        private void btCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            string textError = "";
            int countCBNullText = 0;
            for (int i = 0; i < indexNameComboBoxs - 1; i++)
            {
                if (massComboBoxs[i].Text == "")
                {
                    countCBNullText++;
                }
            }
            if (countCBNullText > 0)
            {
                textError += "Не все сервисы выбраны.\n";
            }
            if (tbxTimeRental.Text == "")
            {
                textError += "Не введено время аренды.\n";
            }
            try
            {
                int testTimeRental = Convert.ToInt32(tbxTimeRental.Text);
            }
            catch (Exception)
            {
                textError += "Не верно введено время аренды.\n";
            }

            if (textError == "")
            {
                DateTime dateTime = DateTime.Now;
                Orders orders = new Orders();
                orders.Status = 1;
                orders.DataCrate = dateTime.Date;
                orders.TimeOrder = dateTime.TimeOfDay;
                orders.CodeOrder = clients.IDClient.ToString() + "/" + dateTime.Date.ToString("dd.MM.yyyy");
                orders.CodeClient = clients.IDClient;
                orders.TimeRental = Convert.ToInt32(tbxTimeRental.Text);
                DBProcatsEntities.Orders.Add(orders);
                DBProcatsEntities.SaveChanges();
                Services services;
                ServicesOrder servicesOrder;
                string nameService;
                for (int i = 0; i < indexNameComboBoxs - 1; i++)
                {
                    nameService = massComboBoxs[i].Text;
                    services = DBProcatsEntities.Services.Where(b => b.Name == nameService).FirstOrDefault();
                    servicesOrder = new ServicesOrder();
                    servicesOrder.Service = services.IDService;
                    servicesOrder.Order = orders.IDOrder;
                    DBProcatsEntities.ServicesOrder.Add(servicesOrder);
                    DBProcatsEntities.SaveChanges();
                }
                MessageBox.Show("Заявка на аренду отправлена.");
                NavigationService.Navigate(null);

            }
        }
    }
}
