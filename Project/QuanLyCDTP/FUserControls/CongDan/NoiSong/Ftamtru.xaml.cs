using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
using static System.Net.Mime.MediaTypeNames;

namespace QuanLyCDTP
{
    /// <summary>
    /// Interaction logic for Ftamtru.xaml
    /// </summary>
    public partial class Ftamtru : UserControl
    {
        TamTruDao ttD = new TamTruDao();
        Check item= new Check();    
        CongDanDAO cdD=new CongDanDAO();
        public Ftamtru()
        {
            InitializeComponent();
        }
        void Clear()
        {
            List<InfoCard> linf = new List<InfoCard>()
            {
                txtcmnd,txtName,txtHoKhau,txtNguoiDangKy,txtMaSoTo,
                txtTamTru,txtNoiDangKy,txtNoiDangKy2,txtTenCanBo
            };
            foreach (InfoCard txt in linf)
            {
                txt.textBox.Clear();
            }
            txtNgaySinh.SelectedDate = null;
            txtngayketthuc.SelectedDate = null;
        }
        void ThongTin(TamTru tamtru)
        {
            List<InfoCard> linfo = new List<InfoCard>()
            {
                txtcmnd,txtName,txtHoKhau,txtNguoiDangKy,txtMaSoTo
                ,txtTamTru,txtNoiDangKy,txtNoiDangKy2,txtLyDo,txtTenCanBo
            };
            Object[] item = new Object[] {tamtru.Cmnd,tamtru.Hoten,tamtru.Thuongtru
            ,tamtru.Hoten,tamtru.Masoto,tamtru.Tamtru,tamtru.Noidangky,
                tamtru.Noidangky,tamtru.Lydo,tamtru.Tencanbo};
            
            for (int i = 0; i < item.Length; i++)
            {
                linfo[i].textBox.Text = item[i].ToString();
            }
            txtNgaySinh.SelectedDate = tamtru.Ngaysinh;
            txtngayketthuc.SelectedDate = tamtru.Ngayketthuc;
        }
        void ThongTinCongDan(CongDan cd)
        {
            List<Object> lproperties = new List<Object>()
            {
                cd.CCCD,cd.HoTen,cd.ThuongTru,cd.NgaySinh
            };
            List<InfoCard> linfor = new List<InfoCard>()
            {
                txtcmnd,txtName,txtHoKhau
            };
            for(int i = 0; i<linfor.Count;i++)
            {
                linfor[i].textBox.Text = lproperties[i].ToString();
            }
            txtNgaySinh.SelectedDate = Convert.ToDateTime(cd.NgaySinh).Date;

        }

        private void BTN_Add_TamTru(object sender, RoutedEventArgs e)
        {
            try
            {
                TamTru tamtru = new TamTru(txtMaSoTo.textBox.Text, txtName.textBox.Text, txtNgaySinh.SelectedDate.Value,
                    txtHoKhau.textBox.Text
                    , txtTamTru.textBox.Text, txtcmnd.textBox.Text, txtLyDo.textBox.Text,
                    txtTenCanBo.textBox.Text, txtNoiDangKy.textBox.Text,
                    DateTime.Now.Date, txtngayketthuc.SelectedDate.Value);
                bool checktt = item.CheckNotNull(tamtru);
                if (checktt == true)
                {
                    if (ttD.ThemTamTru(tamtru))
                        MessageBox.Show("Thành Công", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Thông Tin Không Được Bỏ Trống", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }

        }

        private void BTN_Xoa_TamTru(object sender, RoutedEventArgs e)
        {
            if(txtMaSoTo.textBox.Text.Trim()=="")
            {
                MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                return;
            }    
            TamTru tamtru = new TamTru(txtMaSoTo.textBox.Text);
            if (ttD.AddLSTamTru(tamtru)&& ttD.XoaTamTru(tamtru))
            {
                MessageBox.Show("Thành Công", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Có Lỗi", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }

        }
        private void txtMaSoTo_KeyDown(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                DataRow cd;
                TamTru tamtru = new TamTru(txtMaSoTo.textBox.Text);
                try
                {
                    cd = ttD.TimKiem(tamtru,"",2, "TamTru")[0];
                }
                catch
                {
                    MessageBox.Show("Khong tim thay trong co so du lieu", "thông Báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    return;
                }
                ThongTin(new TamTru(cd[0].ToString(), cd[1].ToString(), Convert.ToDateTime(cd[2]),
                    cd[3].ToString(), cd[4].ToString(), cd[5].ToString(), cd[6].ToString(), cd[7].ToString()
                    ,cd[8].ToString(),Convert.ToDateTime(cd[9]), Convert.ToDateTime(cd[10])));
            }
        }
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TamTru tamtru = new TamTru(txtMaSoTo.textBox.Text, txtName.textBox.Text,
                    txtNgaySinh.SelectedDate.Value,
                    txtHoKhau.textBox.Text
                    , txtTamTru.textBox.Text, txtcmnd.textBox.Text, txtLyDo.textBox.Text,
                    txtTenCanBo.textBox.Text, txtNoiDangKy.textBox.Text,
                    DateTime.Now.Date, txtngayketthuc.SelectedDate.Value);
                bool checktt = item.CheckNotNull(tamtru);
                if (checktt == true)
                {
                    if(ttD.SuaTamTru(tamtru))
                        MessageBox.Show("Thanh Cong", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Thông Tin Không Được Bỏ Trống", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
        private void btnXoaNoiDung_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void txtcmnd_KeyDown(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                DataRow cd;
                CongDan congdan = new CongDan(txtcmnd.textBox.Text);
                try
                {
                    cd = cdD.TimKiem(congdan, "", "", 2)[0];
                }
                catch
                {
                    MessageBox.Show("Khong tim thay trong co so du lieu", "thông Báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    return;
                }
                ThongTinCongDan(new CongDan(cd[0].ToString(), cd[1].ToString(), 
                    Convert.ToDateTime(cd[3]),  cd[5].ToString()));
            }
        }
    }
}
