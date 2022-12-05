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
using System.Windows.Shapes;
using ProcatsManager.Entities;

namespace ProcatsManager.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowAuthorization.xaml
    /// </summary>
    public partial class WindowAuthorization : Window
    {
        public WindowAuthorization()
        {
            InitializeComponent();
            DBProcatsEntities dbProcatsEntities = new DBProcatsEntities();
        }
        public WindowAuthorization(string EmailUser)
        {
            InitializeComponent();
            tbxEmail.Text = EmailUser;
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            string textError = "";
            string passwordUser = "";
            if (tbxEmail.Text == "")
            {
                textError += "Введите E-mail.\n";
            }
            if (pbxPassword.Visibility == Visibility.Visible)
            {
                if (pbxPassword.Password == "")
                {
                    textError += "Введите пароль.\n";
                }
                else
                {
                    passwordUser = pbxPassword.Password;
                }
            }
            else
            {
                if (tbxPassword.Text == "")
                {
                    textError += "Введите пароль.\n";
                }
                else
                {
                    passwordUser = tbxPassword.Text;
                }
            }
           

            if (textError == "") // Проверка на то заполнены ли поля
            {
                DBProcatsEntities dbProcatsEntities = new DBProcatsEntities(); // Инициализация базы данных
                Emploees emploees; // Инициализация таблицы сотрудников
                // Проверка по почте и паролю на наличие в базе сотрудника
                emploees = dbProcatsEntities.Emploees.Where(b => b.E_mail == tbxEmail.Text.ToString() && b.Password == passwordUser).FirstOrDefault();
                if (emploees == null)
                {
                    Clients clients; // Инициализация таблицы клиентов
                    // Проверка по почте и паролю на наличие в базе клиента
                    clients = dbProcatsEntities.Clients.Where(b => b.Email == tbxEmail.Text.ToString() && b.Password == passwordUser).FirstOrDefault();
                    if (clients == null)
                    {
                        textError += "Не верный E-mail или пароль.";
                        MessageBox.Show(textError); // Вывод сообщения о неверности логина или пароля
                    }
                    else
                    {
                        MainWindow mainWindow = new MainWindow(clients.IDClient, true); // Открытие рабочего окна пользователя
                        mainWindow.Show();
                        Close(); // Закрытие окна авторизации
                    }
                }
                else
                {
                    MainWindow mainWindow = new MainWindow(emploees.IDEmploee, false);// Открытие рабочего окна пользователя
                    mainWindow.Show();
                    Close(); // Закрытие окна авторизации
                }
            }
            else
            {
                MessageBox.Show(textError);
            }
        }

        private void btPasswordNotView_Click(object sender, RoutedEventArgs e)
        {
            tbxPassword.Visibility = Visibility.Visible;
            pbxPassword.Visibility = Visibility.Hidden;
            btPasswordNotView.Visibility = Visibility.Hidden;
            tbxPassword.Text = pbxPassword.Password;
        }


        private void btPasswordView_Click(object sender, RoutedEventArgs e)
        {
            tbxPassword.Visibility = Visibility.Hidden;
            pbxPassword.Visibility = Visibility.Visible;
            btPasswordNotView.Visibility = Visibility.Visible;
            pbxPassword.Password = tbxPassword.Text;
        }
    }
}
