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

namespace QuanLyCDTP
{
    /// <summary>
    /// Interaction logic for FchangePass.xaml
    /// </summary>
    public partial class FchangePass : UserControl
    {
        public FchangePass()
        {
            InitializeComponent();
        }
        NguoiQuanLyDao nqld = new NguoiQuanLyDao();
        private void btnDoiPass_Click(object sender, RoutedEventArgs e)
        {
            NguoiQuanLy nql = new NguoiQuanLy(password.Password.ToString(),newpass.Password.ToString(), confirmpass.Password.ToString());
            if(nql.checkpass()==true)
            {
                nqld.UpdatePass(nql);
                MessageBox.Show("Thành Công !", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }    
            else
            {
                MessageBox.Show("Thất Bại !", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }    
        }
        private void TogglePasswordVisibility(PasswordBox passwordBox, TextBox textBox)
        {
            if (passwordBox.Visibility == Visibility.Visible)
            {
                passwordBox.Visibility = Visibility.Hidden;
                textBox.Visibility = Visibility.Visible;
                textBox.Text = passwordBox.Password;
            }
            else
            {
                passwordBox.Visibility = Visibility.Visible;
                textBox.Visibility = Visibility.Hidden;
            }
        }
        private void Hienpass_Click(object sender, RoutedEventArgs e)
        {
            TogglePasswordVisibility(password, showpass);
            TogglePasswordVisibility(newpass, Shownewpass);
            TogglePasswordVisibility(confirmpass, Showconfpass);
        }
    }
}
