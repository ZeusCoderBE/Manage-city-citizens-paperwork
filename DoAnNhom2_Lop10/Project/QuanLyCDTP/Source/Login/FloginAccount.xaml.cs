using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
    /// Interaction logic for FloginAccount.xaml
    /// </summary>
    public partial class FloginAccount : UserControl
    {
        public FloginAccount()
        {
            InitializeComponent();
        }
     
        NguoiQuanLyDao ngqld = new NguoiQuanLyDao();
        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            NguoiQuanLy dn = new NguoiQuanLy(account.Text, password.Password.ToString());
            if (ngqld.DangNhap(dn) != null)
            {
                FGiaoDien giaodien = new FGiaoDien();
                giaodien.Show();
                Flogin.Manv = account.Text;
                try
                {
                    DataRow dr = ngqld.LoadTK(dn, 2)[0];
                    giaodien.tennv.Text = dr[0].ToString();
                }
                catch (Exception)
                {

                }
                Window.GetWindow(this).Close();
            }
            else
            {
                MessageBox.Show("Bạn Đã Chuyển Đổi Thất Bại Do Sai Tên Tài Khoản Hoặc Mật Khẩu","Thông Báo"
                    ,MessageBoxButton.OKCancel,MessageBoxImage.Warning);
            }
        }
    }
}
