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
    /// Interaction logic for Fhokhau2.xaml
    /// </summary>
    public partial class Fhokhau2 : UserControl
    {

        public Fhokhau2()
        {
            InitializeComponent();
        }
        Fhokhau hokhau1 = new Fhokhau();
        Fhokhau1 hokhau2= new Fhokhau1();
        FCatKhau hokhau3 = new FCatKhau();
        private void BTN_update_ThanhVien(object sender, RoutedEventArgs e)
        {
            gridhienthi.Children.Clear();
            gridhienthi.Children.Add(hokhau1);
        }

        private void BTN_Add_ThanhVien(object sender, RoutedEventArgs e)
        {
            gridhienthi.Children.Clear();
            gridhienthi.Children.Add(hokhau2);
        }

        private void BTN_CatKhau(object sender, RoutedEventArgs e)
        {
            gridhienthi.Children.Clear();
            gridhienthi.Children.Add(hokhau3);
        }
    }
}
