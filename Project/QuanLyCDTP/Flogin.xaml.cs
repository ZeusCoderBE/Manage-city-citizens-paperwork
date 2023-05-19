using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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


namespace QuanLyCDTP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Flogin : Window
    {
        NguoiQuanLyDao dnD= new NguoiQuanLyDao();
        public static string Manv = "";
        public Flogin()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            NguoiQuanLy dn = new NguoiQuanLy(txtUser.Text, txtPassword.Password.ToString());
            if (dnD.DangNhap(dn) != null)
            {
                FGiaoDien giaodien = new FGiaoDien();
                giaodien.Show();
                Manv = txtUser.Text;
                try
                {
                    DataRow dr = dnD.LoadTK(dn, 2)[0];
                    giaodien.tennv.Text = dr[0].ToString();
                }
                catch (Exception)
                {

                }
                Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!");
            }
        }
        private void imgAn_MouseDown(object sender, MouseButtonEventArgs e)
        {
       
        }
    }
}
