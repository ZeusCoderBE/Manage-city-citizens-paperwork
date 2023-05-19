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
    /// Interaction logic for FDangKy.xaml
    /// </summary>
    public partial class FDangKy : UserControl
    {
        FHoChieu fHo = new FHoChieu();
        Ftamtru ttru = new Ftamtru();
        Fhokhau2 hokhau1 = new Fhokhau2();
        Fcccd ccd = new Fcccd();
        FDKHonNhan fhn=new FDKHonNhan();
        Fkhaisinh ks = new Fkhaisinh();
        FKhaiTu kt = new FKhaiTu();
        FLoaiThue flt=new FLoaiThue();
        FHoaDonThue fhd=new FHoaDonThue();
        FBackGroundDK fbd = new FBackGroundDK();
        public FDangKy()
        {
            InitializeComponent();
        }
        
        void ChangeButton(Button kethon, Button lyhon)
        {
            kethon.Visibility = Visibility.Visible;
            lyhon.Visibility = Visibility.Hidden;
        }
        void ChangeForm(Grid hienthi,UIElement item)
        {
            hienthi.Children.Clear();
            hienthi.Children.Add(item);
        }

        SolidColorBrush myBrush;
        private void MouseLyhon(object sender, RoutedEventArgs e)
        {
            
            fhn.btnLyHon.Visibility = Visibility.Visible;
            fhn.btnKetHon.Visibility = Visibility.Hidden;
            fbd.NhapUserControl(fhn);
            ChangeForm(gkhaisinh,fbd);
        }
        private void Mosuekethon(object sender, RoutedEventArgs e)
        {
            fhn.btnLyHon.Visibility = Visibility.Hidden;
            fhn.btnKetHon.Visibility = Visibility.Visible; 
            fbd.NhapUserControl(fhn);
            ChangeForm(gkhaisinh, fbd);
        }
        private void Mousekhaisinh(object sender, RoutedEventArgs e)
        {
            fbd.NhapUserControl(ks);
            ChangeForm(gkhaisinh, fbd);
        }
        private void Mousetamtru(object sender, RoutedEventArgs e)
        {
            fbd.NhapUserControl(ttru);
            ChangeForm(gkhaisinh, fbd);
            SetCurrentDate(ttru);

        }
        private void SetCurrentDate(UIElement form)
        {
            var day = DateTime.Now.Day.ToString();
            var month = DateTime.Now.Month.ToString();
            var year = DateTime.Now.Year.ToString();

            /*if ( form is FLoaiThue)
            {
                flt.txblday.Text = day;
                flt.txblmonth.Text = month;
                flt.txblYears.Text = year;
            }*/
            if (form is FHoaDonThue)
            {
                fhd.txblday.Text = day;
                fhd.txblmonth.Text = month;
                fhd.txblYears.Text = year;
            }
            else if (form is Ftamtru)
            {
                ttru.txblday.Text = DateTime.Now.Day.ToString();
                ttru.txblmonth.Text = DateTime.Now.Month.ToString();
                ttru.txblYears.Text = DateTime.Now.Year.ToString();
            }    
        }
        private void Mousehokhau(object sender, RoutedEventArgs e)
        {
            fbd.NhapUserControl(hokhau1);
            ChangeForm(gkhaisinh, fbd);
        }
        private void Mousehochieu(object sender, RoutedEventArgs e)
        {
            fbd.NhapUserControl(fHo);
            ChangeForm(gkhaisinh, fbd);
        }
        private void cccd_Click(object sender, RoutedEventArgs e)
        {
            fbd.NhapUserControl(ccd);
            ChangeForm(gkhaisinh, fbd);
        }

        private void KhaiTu_Click(object sender, RoutedEventArgs e)
        {
            fbd.NhapUserControl(kt);
            ChangeForm(gkhaisinh, fbd);
        }
        private void loaithue_Click(object sender, RoutedEventArgs e)
        {
            fbd.NhapUserControl(flt);
            ChangeForm(gkhaisinh, fbd);
            SetCurrentDate(flt);
        }

        private void hoadonthue_Click(object sender, RoutedEventArgs e)
        {
            fbd.NhapUserControl(fhd);
            ChangeForm(gkhaisinh,fbd);
            SetCurrentDate(fhd);
        }
    }
}
  
