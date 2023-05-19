using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Flichsu.xaml
    /// </summary>
    public partial class Flichsu : UserControl
    {
        public Flichsu()
        {
            InitializeComponent();
            Change(gridhienthi, fThong, info, "THÔNG TIN CHUNG");
        }
        FThongTin fThong =new FThongTin();
        FKhaiSinh khaisinh = new FKhaiSinh();
        FHonNhanShow HonNhan = new FHonNhanShow();
        FHoKhauShow hokhau = new FHoKhauShow();
        FTamTruShow tamtru = new FTamTruShow();
        FLichSuTamTru lstTru = new FLichSuTamTru();
        FHoChieuShow fhcs = new FHoChieuShow();
        FLSHoChieu fhc = new FLSHoChieu();
        FThueShow fthue=  new FThueShow();
        private void btnTraCuu_Click(object sender, RoutedEventArgs e)
        {
            ThongTinCaNhan ftracuu = new ThongTinCaNhan();
            gridhienthi.Children.Add(ftracuu.tracuu);
        }
        void Change(Grid hienthi,UIElement item,TextBlock inf,string name)
        {
            hienthi.Children.Clear();
            hienthi.Children.Add(item);
            inf.Text = name;
        }

        private void btnKhaiSinh_Click(object sender, RoutedEventArgs e)
        {
            Change(gridhienthi, khaisinh, info, "KHAI SINH");
        }
        private void btnHonNhan_Click(object sender, RoutedEventArgs e)
        {
            Change(gridhienthi, HonNhan, info, "HÔN NHÂN");
        }
        private void btnthongtin_Click(object sender, RoutedEventArgs e)
        {
            Change(gridhienthi, fThong, info, "THÔNG TIN CHUNG");
        }
        private void btnHoKhau_Click(object sender, RoutedEventArgs e)
        {
            Change(gridhienthi, hokhau, info, "HỘ KHẨU");
        }
        private void btnTamTru_Click(object sender, RoutedEventArgs e)
        {
            Change(gridhienthi, tamtru, info, "TẠM TRÚ");
        }
        private void btnLSTamTru_Click(object sender, RoutedEventArgs e)
        {
            Change(gridhienthi, lstTru, info, "LỊCH SỬ TẠM TRÚ");
        }
        private void btnHoChieu_Click(object sender, RoutedEventArgs e)
        {
            Change(gridhienthi, fhcs, info, "HỘ CHIẾU");
        }
        private void btnLSDiLai_Click(object sender, RoutedEventArgs e)
        {
            Change(gridhienthi, fhc, info, "LỊCH SỬ ĐI LẠI");
        }

        private void btnThue_Click(object sender, RoutedEventArgs e)
        {
            Change(gridhienthi, fthue, info, "Quản Lý Thuế");
        }
    }   
}
