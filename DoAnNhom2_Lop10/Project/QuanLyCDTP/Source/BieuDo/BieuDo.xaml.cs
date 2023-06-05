using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Data;
namespace QuanLyCDTP
{
    /// <summary>
    /// Interaction logic for BieuDo.xaml
    /// </summary>
    public partial class BieuDo : UserControl
    {
        subieudo sbd = new subieudo();
        FBackGroundBD fbg = new FBackGroundBD();
        public BieuDo()
        {
            InitializeComponent();
            fbg.NhapUserControl(sbd);
            BieuDoC.Children.Clear();
            BieuDoC.Children.Add(fbg);
            sbd.LayThongTin("Số Lượng Sinh Qua Các Năm", "substring(CAST(NgayThangNamSinh as varchar),1,4)", "KhaiSinh");

        }

        private void TamTru(object sender, RoutedEventArgs e)
        {
            sbd.LayThongTin("Số Lượng người Đăng Kí Tạm Trú Qua Các Năm", "substring(CAST(NgayDangKy as varchar),1,4)", "TamTru");

        }

        private void Tu(object sender, RoutedEventArgs e)
        {
            sbd.LayThongTin("Số Lượng Cong Dan Tu Qua Các Năm", "namdk", "CongDanTu");

        }

        private void Sinh(object sender, RoutedEventArgs e)
        {
            sbd.LayThongTin("Số Lượng Sinh Qua Các Năm", "substring(CAST(NgayThangNamSinh as varchar),1,4)", "KhaiSinh");
        }

        private void HoKhau(object sender, RoutedEventArgs e)
        {
            sbd.LayThongTin("Số Lượng Hộ Khẩu Qua Các Năm", "Nam", "SoHoKhau");
        }
    }
}
