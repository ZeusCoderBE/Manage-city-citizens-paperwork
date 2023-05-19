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


namespace QuanLyCDTP
{
    /// <summary>
    /// Interaction logic for Fhokhau.xaml
    /// </summary>
    public partial class Fhokhau : UserControl
    {
        SoHoKhauDao shkDao = new SoHoKhauDao();
        DataRowCollection dr;
        CongDanDAO cdD = new CongDanDAO();
        KhaiSinhDao ksD = new KhaiSinhDao();
        SoHoKhau shk;
        Check ch = new Check();
        int douutien = 0;
        string sdk;
        string dato;
        
        public Fhokhau()
        {
            InitializeComponent();
        }
        
        private void BTThemThanhVien(object sender, RoutedEventArgs e)
        {
            try
            {
                int t = 0;
                if (Int32.TryParse(masoto.Text, out t) != true)
                {
                    t = 0;
                }
                string thongtin;
                try
                {
                    thongtin = infocard.Text;
                }
                catch
                {
                    thongtin = "";
                }

                if (!ch.NotContains(infocard.Text.Trim(), "cccd", "SoHoKhau"))
                {
                    MessageBox.Show("Khong the dang ky","Thông Báo",MessageBoxButton.OKCancel,MessageBoxImage.Warning);
                    return;
                }

                ch = new Check(sdk,dato);
                if(ch.Checknull()==true)
                {
                    MessageBox.Show("Khong the dang ky", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    return;
                }    
                shk = new SoHoKhau(HoKhau.textBox.Text, t, thongtin, douutien, Convert.ToInt32(FHoKhauBoTro.Ngay.textBox.Text), Convert.ToInt32(FHoKhauBoTro.Thang.textBox.Text), Convert.ToInt32(FHoKhauBoTro.Nam.textBox.Text), Convert.ToInt32(FHoKhauBoTro.CCCDCanBo.textBox.Text), sdk, dato, FHoKhauBoTro.noidangky.textBox.Text);

                if (ch.CheckNotNull(shk, new List<string>() { "MaSoTo", "MsHoKhau" }))
                {
                    if (shkDao.Them(shk) == true)
                        MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Khong the dang ky", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Khong the dang ky", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
                return;

            }
            catch
            {

            }
            MessageBox.Show("That bai dang ki thanh vien");
        }
        private void TimKiemSHK(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                try
                {
                    dr = shkDao.TimKiem(HoKhau.textBox.Text,"",1);
                    douutien = dr.Count + 1;
                    sdk = dr[0][8].ToString();
                    dato = dr[0][13].ToString();
                    FHoKhauBoTro.noidangky.textBox.Text = dr[0][14].ToString();
                    MessageBox.Show("Ton Tai So Ho Khau");
                }
                catch
                {
                    MessageBox.Show("Khong tim thay so ho khau");
                }
            }
        }

        

        private void Enter(object sender, KeyEventArgs e)
        {
            DataRow cd;

            try
            {
                string etr = e.Key.ToString();
                if (etr == "Return")
                {
                    cd = cdD.TimKiem(null, infocard.Text, "", 1)[0];
                    CongDan cdn = new CongDan(cd[0].ToString(), cd[1].ToString(), cd[2].ToString(), Convert.ToDateTime(cd[3]), cd[4].ToString(), cd[5].ToString(), cd[6].ToString(), cd[7].ToString()
                    , cd[8].ToString(), cd[9].ToString(), cd[10].ToString(), float.Parse(cd[11].ToString()), cd[12].ToString());
                    HoVaTen.textBox.Text = cdn.HoTen;
                    date.SelectedDate = Convert.ToDateTime(cdn.NgaySinh).Date;
                    quequan.textBox.Text = cdn.QueQuan;
                    gioitinh.textBox.Text = cdn.GioiTinh;
                    dantoc.textBox.Text = cdn.DanToc;
                    thuongtru.textBox.Text = cdn.ThuongTru;
                }
            }
            catch
            {
                MessageBox.Show("Khong tim thay thong tin nguoi dang ki trong co so du lieu");
                return;
            }
        }

        private void BTXoaThanhVien(object sender, RoutedEventArgs e)
        {
            if (shkDao.Xoa(infocard.Text, HoKhau.textBox.Text))
            {

            }
            else
            {
                MessageBox.Show("Khong The Xoa");

            }
        }

        private void Infocard_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Enter2(object sender, KeyEventArgs e)
        {
            DataRow cd;

            try
            {
                string etr = e.Key.ToString();
                if (etr == "Return")
                {
                    cd = ksD.TimKiem(null,masoto.Text,"",1)[0];
                    
                    CongDan cdn = new CongDan("0", cd[1].ToString(), cd[2].ToString(), Convert.ToDateTime(cd[3].ToString()), cd[6].ToString(), cd[6].ToString(), "", cd[4].ToString()
                    , "Độc Thân", cd[7].ToString(), cd[8].ToString(), 0, cd[5].ToString());
                    HoVaTen.textBox.Text = cdn.HoTen;
                    date.SelectedDate = Convert.ToDateTime(cdn.NgaySinh).Date;
                    quequan.textBox.Text = cdn.QueQuan;
                    gioitinh.textBox.Text = cdn.GioiTinh;
                    dantoc.textBox.Text = cdn.DanToc;
                    thuongtru.textBox.Text = cdn.ThuongTru;
                    infocard.Text = cdn.CCCD;
                }
            }
            catch
            {
                MessageBox.Show("Khong tim thay thong tin nguoi dang ki trong co so du lieu");
                return;
            }
        }

        private void BTLamSach(object sender, RoutedEventArgs e)
        {
            LamSach ls = new LamSach();
            ls.LamSachGiaTri(GridThemThanhVien, null,1);
            FHoKhauBoTro.Clear();
            infocard.Clear();
            masoto.Clear();
        }
    }
}
