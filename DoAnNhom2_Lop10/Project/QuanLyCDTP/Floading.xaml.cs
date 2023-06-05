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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyCDTP
{
    /// <summary>
    /// Interaction logic for loading.xaml
    /// </summary>
    public partial class loading : Window
    {
        public loading()
        {
            InitializeComponent();
           
        }
        void ChangeText()
        {
            text.Text = "Vui lòng chờ tí!";
            waiting.Text = "Successfully";
        }
        private async void hienthi_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue == 100)
            {
                ChangeText();
                await Task.Delay(TimeSpan.FromSeconds(3));
                Flogin flogin = new Flogin();
                flogin.Show();
                Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
