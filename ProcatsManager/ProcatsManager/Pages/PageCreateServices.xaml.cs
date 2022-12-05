using ProcatsManager.Entities;
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

namespace ProcatsManager.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageCreateServices.xaml
    /// </summary>
    public partial class PageCreateServices : Page
    {
        public PageCreateServices()
        {
            InitializeComponent();
        }
        DBProcatsEntities DBProcatsEntities = new DBProcatsEntities();
        Services services;
        bool EditMod = false;
        public PageCreateServices(int IdService)
        {
            InitializeComponent();
            services = DBProcatsEntities.Services.Where(b=> b.IDService == IdService).FirstOrDefault();
            tbxNameService.Text = services.Name;
            tbxCostService.Text = Convert.ToString(services.СostPerHour);
            EditMod = true;
            btCreateOrEditService.Content = "Редактировать";
        }

        private void btCreateOrEditService_Click(object sender, RoutedEventArgs e)
        {
            string textError = "";
            if (tbxNameService.Text == "" || tbxCostService.Text == "")
            {
                textError = "Не все поля заполнены.";
            }

            try
            {
                double test = Convert.ToDouble(tbxCostService.Text);
            }
            catch (Exception)
            {
                textError = "Не корректно введена цена.";
            }

            if (textError == "")
            {
                if (EditMod)
                {
                    services.Name = tbxNameService.Text;
                    services.СostPerHour = Convert.ToDouble(tbxCostService.Text);
                    DBProcatsEntities.SaveChanges();
                    MessageBox.Show("Услуга отредактирована.");
                }
                else
                {
                    string codeForService = "";

                    do {
                        string abc = "qwertyuiopasdfghjklzxcvbnm123456789";
                        abc += abc.ToUpper();
                        Random rnd = new Random();
                        for (int i = 0; i < 8; i++)
                            codeForService += abc[rnd.Next(abc.Length)];        
                    }
                    while ( null == DBProcatsEntities.Services.Where(b => b.CodeServices == codeForService).FirstOrDefault());

                    services = new Services();
                    services.Name = tbxNameService.Text;
                    services.СostPerHour = Convert.ToDouble(tbxCostService.Text);
                    services.CodeServices = codeForService;
                    DBProcatsEntities.Services.Add(services);
                    DBProcatsEntities.SaveChanges();
                    MessageBox.Show("Услуга добавлена.");
                }
            }
            else
            {
                MessageBox.Show(textError);
            }
        }
    }
}
