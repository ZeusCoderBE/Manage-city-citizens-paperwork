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
using System.Data;
using QuanLyCDTP.FUserControls.TraCuu;
namespace QuanLyCDTP
{
    /// <summary>
    /// Interaction logic for ThongTinCaNhan.xaml
    /// </summary>
    public partial class ThongTinCaNhan : UserControl
    {
        
        thongtincn thc = new thongtincn();
        Fsohokhau hokhau = new Fsohokhau();
        FSKhaiSinh fsks=new FSKhaiSinh();

        //Bien lua chon de lam Lam Sach UserControl
        public ThongTinCaNhan()
        {
            InitializeComponent();
        }

        void ChangeForm(Border bohienthi, Grid hienthi, UIElement form)
        {
            bohienthi.Visibility = Visibility.Hidden;
            hienthi.Visibility = Visibility.Visible;
            hienthi.Children.Clear();
            hienthi.Children.Add(form);
        }
        private void btnHoKhau_Click(object sender, RoutedEventArgs e)
        {
            ChangeForm(boHienthi, gridhienthi, hokhau);
        }
        private void btn_cmnd_Click(object sender, RoutedEventArgs e)
        {
            ChangeForm(boHienthi, gridhienthi, thc);
        }
        private void btnKhaiSinh_Click(object sender, RoutedEventArgs e)
        {
            ChangeForm(boHienthi, gridhienthi, fsks);
        }
    }
 }

