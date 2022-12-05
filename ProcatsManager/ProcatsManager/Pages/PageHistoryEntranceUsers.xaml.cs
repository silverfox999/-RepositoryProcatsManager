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
    /// Логика взаимодействия для PageHistoryEntranceUsers.xaml
    /// </summary>
    public partial class PageHistoryEntranceUsers : Page
    {
        DBProcatsEntities dbProcatsEntities = new DBProcatsEntities();
        public PageHistoryEntranceUsers()
        {
            InitializeComponent();
            var query = (from Emploees in dbProcatsEntities.Emploees
                         from JobTitle in dbProcatsEntities.JobTitle
                         where Emploees.JobTitle == JobTitle.IDJobTitle
                         select new {
                             Сотрудник = Emploees.Surname + " " + Emploees.Name + " " + Emploees.Patronimic,
                             Должность = JobTitle.Name,
                             Почта = Emploees.E_mail,
                             ПоследнийВход = Emploees.LastEntrance
                         }).Distinct().ToList();
            dgUsers.ItemsSource = query;
        }

        private void SortUser()
        {
            var query = (from Emploees in dbProcatsEntities.Emploees
                         from JobTitle in dbProcatsEntities.JobTitle
                         where Emploees.JobTitle == JobTitle.IDJobTitle &&
                         Emploees.E_mail.Contains(tbxFilter.Text)
                         select new
                         {
                             Сотрудник = Emploees.Surname + " " + Emploees.Name + " " + Emploees.Patronimic,
                             Должность = JobTitle.Name,
                             Почта = Emploees.E_mail,
                             ПоследнийВход = Emploees.LastEntrance
                         }).Distinct().ToList();
            dgUsers.ItemsSource = query;
            if (cbSort.SelectedIndex != null)
            {
                switch (cbSort.SelectedIndex)
                {
                    case 0:
                        var querySortEmail = (from queryElement in query
                                              orderby queryElement.Почта ascending
                                              select new
                                              {
                                                  queryElement.Сотрудник,
                                                  queryElement.Должность,
                                                  queryElement.Почта,
                                                  queryElement.ПоследнийВход
                                              }).Distinct().ToList();
                        dgUsers.ItemsSource = querySortEmail;
                        break;
                    case 1:
                        var querySortLastEntrance = (from queryElement in query
                                                     orderby queryElement.ПоследнийВход ascending
                                                     select new
                                                     {
                                                         queryElement.Сотрудник,
                                                         queryElement.Должность,
                                                         queryElement.Почта,
                                                         queryElement.ПоследнийВход
                                                     }).Distinct().ToList();
                        dgUsers.ItemsSource = querySortLastEntrance;
                        break;
                    case 2:
                        var querySortSurname = (from queryElement in query
                                                orderby queryElement.Сотрудник ascending
                                                select new
                                                {
                                                    queryElement.Сотрудник,
                                                    queryElement.Должность,
                                                    queryElement.Почта,
                                                    queryElement.ПоследнийВход
                                                }).Distinct().ToList();
                        dgUsers.ItemsSource = querySortSurname;
                        break;
                    default:
                        break;
                }
            }
        }

        private void btSortUser_Click(object sender, RoutedEventArgs e)
        {
            if (cbSort.Text != "")
            {
                SortUser();
            }
            else
            {
                MessageBox.Show("Выберите категорию фильтрации.");
            }
        }

        private void tbxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            SortUser();

        }
    }
}
