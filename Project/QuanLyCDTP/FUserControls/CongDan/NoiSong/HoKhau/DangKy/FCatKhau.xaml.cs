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
    public partial class FCatKhau : UserControl
    {
        SoHoKhauDao shkDao = new SoHoKhauDao();
        CongDanDAO cdD = new CongDanDAO();
        KhaiSinhDao ksD = new KhaiSinhDao();
        Check ch = new Check();
        
        public FCatKhau()
        {
            InitializeComponent();
        }
        int check = 0;
        private void Enter(object sender, KeyEventArgs e)
        {
            check = 0;
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                try
                {
                    if (infocard.Text != "")
                    {
                        DataRowCollection cd = shkDao.TimKiem("", infocard.Text, 2);
                        Display(cd[0]);
                        check = 1;
                        return;
                    }

                }
                catch
                {

                }
                MessageBox.Show("Khong tim thay thong tin");
            }
        }
        void Display(DataRow cd)
        {
            HoKhau.textBox.Text = cd[0].ToString();
            HoVaTen.textBox.Text = cd[1].ToString();
            date.textBox.Text = cd[2].ToString();
            gioitinh.textBox.Text = cd[3].ToString();
            quequan.textBox.Text = cd[4].ToString();
            dantoc.textBox.Text = cd[5].ToString();
            thuongtru.textBox.Text = cd[6].ToString();
            QuocTich.Text = cd[7].ToString();
            FHoKhauBoTro.noidangky.textBox.Text = cd[12].ToString();
            FHoKhauBoTro.Ngay.textBox.Text = cd[8].ToString();
            FHoKhauBoTro.Thang.textBox.Text = cd[9].ToString();
            FHoKhauBoTro.Nam.textBox.Text = cd[10].ToString();
            FHoKhauBoTro.CCCDCanBo.textBox.Text = cd[11].ToString();
            FHoKhauBoTro.TimKiem();
        }
        private void BTXoaThanhVien(object sender, RoutedEventArgs e)
        {
            if (check == 1)
            {
                shkDao.Xoa(HoKhau.textBox.Text, infocard.Text);
                MessageBox.Show("Cắt Hộ Khẩu Thành Công.");
            }
            else
            {
                MessageBox.Show("Không tồn tại công dân để xóa.");
            }
        }

        private void BTLamSach(object sender, RoutedEventArgs e)
        {
            LamSach ls = new LamSach();
            ls.LamSachGiaTri(FHKDangKy, null, 1);
            infocard.Clear();
            FHoKhauBoTro.Clear();
        }
    }
}
