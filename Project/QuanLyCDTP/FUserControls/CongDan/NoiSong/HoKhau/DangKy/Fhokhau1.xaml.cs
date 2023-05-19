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
    /// Interaction logic for Fhokhau1.xaml
    /// </summary>
    public partial class Fhokhau1 : UserControl
    {
        SoHoKhauDao shkDao = new SoHoKhauDao();
        CongDanDAO cdD = new CongDanDAO();
        KhaiSinhDao ksD = new KhaiSinhDao();
        TruyVanChungDao tvc = new TruyVanChungDao();
        SoHoKhau shk;
        Check ch = new Check();
        public Fhokhau1()
        {
            InitializeComponent();
        }
        public bool KiemTraTonTaiCD(string cccd)
        {
            try
            {
                if (tvc.GetValue("CongDan","*", "cccd",cccd,2) !=null)
                {

                    return true;
                }
                return false;
            }
            catch
            {

            }
            return false;
        }
        public bool KiemTraTonTaiSoHoKhau(string shk)
        {
            try
            {
                if (tvc.GetValue("SoHoKhau", "*", "MsHoKhau", shk, 2) != null)
                {

                    return false;
                }
            }
            catch
            {

            }
            return true;
        }
        private void BTThemThanhVien(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (KiemTraTonTaiCD(FHoKhauBoTro2.CCCDCanBo.textBox.Text) == true && KiemTraTonTaiSoHoKhau(HoKhau.textBox.Text)==false)
                {
                    if (!ch.NotContains(HoKhau.textBox.Text.Trim(), "MsHoKhau", "SoHoKhau") || !ch.NotContains(infocard.Text.Trim(), "cccd", "SoHoKhau"))
                    {
                        MessageBox.Show("Khong the dang ky");
                        return;
                    }
                    
                    MessageBox.Show(infocard.Text.Trim());
                    shk = new SoHoKhau(HoKhau.textBox.Text, 0, infocard.Text, 1, Convert.ToInt32(FHoKhauBoTro2.Ngay.textBox.Text), Convert.ToInt32(FHoKhauBoTro2.Thang.textBox.Text), Convert.ToInt32(FHoKhauBoTro2.Nam.textBox.Text), Convert.ToInt32(FHoKhauBoTro2.CCCDCanBo.textBox.Text), sodk.textBox.Text, DatO.textBox.Text,FHoKhauBoTro2.noidangky.textBox.Text);
                    if (ch.CheckNotNull(shk,new List<string>() { "MaSoTo" }))
                    {
                        shkDao.Them(shk);
                        MessageBox.Show("Thanh cong dang ki thanh vien");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không thể đăng ký");
                }
                return;
            }
            catch
            {

            }
            MessageBox.Show("That bai dang ki thanh vien");
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
                    CongDan cdn = new CongDan(cd[0].ToString(), cd[1].ToString(), cd[2].ToString(),Convert.ToDateTime(cd[3]), cd[4].ToString(), cd[5].ToString(), cd[6].ToString(), cd[7].ToString()
                    , cd[8].ToString(), cd[9].ToString(), cd[10].ToString(),float.Parse(cd[11].ToString()), cd[12].ToString());
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

        private void BTLamSach(object sender, RoutedEventArgs e)
        {
            LamSach ls = new LamSach();
            ls.LamSachGiaTri(GridDKHK, null, 1);
            FHoKhauBoTro2.Clear();
            infocard.Clear();

        }
    }
}
