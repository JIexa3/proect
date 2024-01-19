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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для mail.xaml
    /// </summary>
    public partial class mail : Window
    {
        public mail()
        {
            InitializeComponent();
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void input_Click(object sender, RoutedEventArgs e)
        {
            var email = Email.Text;

            var pass = Password.Text;

            var context = new AppDbContext();

            var user = context.Users.FirstOrDefault(x => x.Email == email);



            if (user is null)
            {
                MessageBox.Show("Неправильный логин или пароль!");
                return;
            }

            MessageBox.Show("Вы успешно вошли в аккаунт!");
        }
        public int x = 1;
        private void knopka_Click(object sender, RoutedEventArgs e)
        {
            if ((x % 2) == 0)
            {
                x++;
                passwordPasswordBox.Password = Password.Text;

                passwordPasswordBox.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Collapsed;
            }
            else
            {
                x++;
                Password.Text = passwordPasswordBox.Password;
                passwordPasswordBox.Visibility = Visibility.Collapsed;
                Password.Visibility = Visibility.Visible;
            }
        }
    }
}
