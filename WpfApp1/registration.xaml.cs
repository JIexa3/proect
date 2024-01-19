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
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Window
    {
        public registration()
        {
            InitializeComponent();
        }

        private void reg(object sender, RoutedEventArgs e)
        {
            var log = Login.Text;
            var pass = Password.Text;
            var email = Email.Text;

            var role = "User";

            var context = new AppDbContext();

            var users_exists = context.Users.FirstOrDefault(x => x.Login == log);
            if (users_exists is not null)
            {
                Name.Text = "Такой пользователь уже существует!!!";
                return;
            }
            var user = new User() { Login = log, Password = pass, Email = email, Role = role };
            context.Users.Add(user);
            context.SaveChanges();
            Name.Text = "Вы успешно зарегистрировались!";


            if (!CheckLoginRepeat(user)) //проверка логина на повторение в файле
            {
                Name.Text = "Такой пользователь уже существует";
                return;
            }
            if (Password.Text.Length < 8)
            {
                Name.Text = ("Пароль менее 8 символов");
                return;
            }
            if (!Password.Text.Contains("%") & !Password.Text.Contains("$") & !Password.Text.Contains("+") & !Password.Text.Contains("%") &
                !Password.Text.Contains("*") & !Password.Text.Contains("-") & !Password.Text.Contains("!") & !Password.Text.Contains("/"))
            {
                Name.Text = ("Нет специальных символов в пароле");
                return;
            }
            if (Password.Text != loginnew.Text)
            {
                Name.Text = ("Пароли не совпадают");
                return;
            }

            Name.Text = ("Вы успешно создали нового пользователя");
        }
        private bool CheckLoginRepeat(User user) //метод для проверки логина пользователя
        {

            var users = new List<User>(); //создаем лист(массив) с пользователями

            {

            }
            return users.FirstOrDefault(u => u.Login == user.Login) is null; //сравниваем введенные данные в текстовое полеи значения в листе
                                                                             //при первом нахождении возвращаем ошибку
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }

}

