using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            registration registration=new registration();
            registration.Show();
            this.Hide();
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {
            var log = loginBox.Text;

            var pass = passwordBox.Text;

            var context = new AppDbContext();

            var user = context.Users.FirstOrDefault(x => x.Login == log);



            if (user is null)
            {
                MessageBox.Show("Неправильный логин или пароль!");
                return;
            }
            

                MessageBox.Show("Вы успешно вошли в аккаунт!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mail mail  =new mail();
            mail.Show();
            this.Hide();
        }
    }
}