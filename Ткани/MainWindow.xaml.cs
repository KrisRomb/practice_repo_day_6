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
using System.Windows.Threading;
using Ткани.Classes;

namespace Ткани
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            captchaCheckBttn.IsEnabled = false;
            captchaRefreshBttn.IsEnabled = false;
        }
        int errorCount = 0;
        int timeLeft = 10;
        TradeEntities entity = new TradeEntities();
        private void productbutton_Click(object sender, RoutedEventArgs e)
        {
            var productWndw = new ProductWindow();
            productWndw.Show();
            this.Close();
        }

        private void loginbutton_Click(object sender, RoutedEventArgs e)
        {

            if (loginTB.Text != "" && passwordTB.Text != "")
            {
                if (errorCount < 1)
                {

                    if (entity.User.Any(u => u.UserLogin == loginTB.Text) && entity.User.Any(u => u.UserPassword == passwordTB.Text))
                    {
                        User user = entity.User.First(x => x.UserLogin == loginTB.Text);
                        switch (user.UserRole)
                        {
                            case 1:
                                MessageBox.Show("Авторизация прошла успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                var adminWindow = new AdminWindow();
                                adminWindow.Show();
                               this.Close();
                                break;
                            case 2:
                                MessageBox.Show("Авторизация прошла успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                var clientWindow = new ClientWindow();
                               clientWindow.Show();
                                this.Close();
                                break;
                            case 3:
                                MessageBox.Show("Авторизация прошла успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                var managerWindow = new ManagerWindow();
                                managerWindow.Show();
                                this.Close();
                                break;

                        }
                    }
                    else
                    {
                        errorCount++;
                        MessageBox.Show("Пользователя не существует.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Введите каптчу!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                    captchaIMG.Source = Captcha.CreateImageHard(800, 800);
                    loginbutton.IsEnabled = false;
                    captchaCheckBttn.IsEnabled = true;
                    captchaRefreshBttn.IsEnabled = true;
                }
            }
            else
            {
                MessageBox.Show("Введите и логин, и пароль.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    

        private void captchaRefreshBttn_Click(object sender, RoutedEventArgs e)
        {
            captchaIMG.Source = Captcha.CreateImageHard(800, 800);
        }
        CapthaGenerator Captcha = new CapthaGenerator();
        private void captchaCheckBttn_Click(object sender, RoutedEventArgs e)
        {
            if (Captcha.CapthaChecker(captchaTB.Text))
                MessageBox.Show("Вы прошли капчу", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            else 
            {
                MessageBox.Show("Вы не прошли капчу!\nПопробуйте ещё раз через 10 секунд.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);              
                captchaRefreshBttn.IsEnabled = false;
                captchaCheckBttn.IsEnabled = false;
                loginbutton.IsEnabled=false;
                timeLeft = 10;
                timer();
            }
        }
        DispatcherTimer Timer = new DispatcherTimer();
        public void timer()
        {
            countDownTB.Visibility = Visibility.Visible;
            Timer.Interval = new TimeSpan(0, 0, 0, 1);
            Timer.Tick += DispatcherTimer_Tick;
            Timer.Start();
        }
        void DispatcherTimer_Tick(object sender, EventArgs e)
        {

            if (timeLeft > 0)
            {
                timeLeft--;
                countDownTB.Text = String.Format("0{0}:{1}", timeLeft / 60, timeLeft % 60);
            }
            else
            {
                Timer.Tick -= DispatcherTimer_Tick;
                Timer.Stop();
                captchaRefreshBttn.IsEnabled = true;
                captchaCheckBttn.IsEnabled = true;
                countDownTB.Visibility = Visibility.Hidden;
                ;
                errorCount = 0;
            }
        }
    }
}
