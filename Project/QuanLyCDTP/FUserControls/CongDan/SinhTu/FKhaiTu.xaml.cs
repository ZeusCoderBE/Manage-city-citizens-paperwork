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
    /// Interaction logic for FKhaiTu.xaml
    /// </summary>
    public partial class FKhaiTu : UserControl
    {
        CongDanDAO cdD = new CongDanDAO();
        KhaiTuDAO ktD = new KhaiTuDAO();
        KhaiTu kt;
        Check ch = new Check();
        public FKhaiTu()
        {
            InitializeComponent();
        }
        string ToString(DataRowCollection dr, int i, int j)
        {
            try
            {
                return Convert.ToString(dr[i][j]);
            }
            catch
            {

            }
            return "";
        }
       
        private void BTThemThanhVien(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show(dateD.SelectedDate.Value.ToString());
                kt = new KhaiTu(cccd.textBox.Text, dateD.SelectedDate.Value.ToString().Substring(0,9), NguyenNhan.textBox.Text, BoTroGKT.Ngay.textBox.Text, BoTroGKT.Thang.textBox.Text, BoTroGKT.Nam.textBox.Text, BoTroGKT.CCCDCanBo.textBox.Text,BoTroGKT.noidangky.textBox.Text);
                if (ch.CheckNotNull(kt))
                {
                    if (ktD.Add(kt))
                        MessageBox.Show("Thanh cong ghi nhan");
                    else
                        MessageBox.Show("That bai ghi nhan");
                    return;
                }

            }
            catch
            {

            }
            MessageBox.Show("That bai ghi nhan");
        }

        private void Enter(object sender, KeyEventArgs e)
        {
            DataRow cd;

            try
            {
                string etr = e.Key.ToString();
                if (etr == "Return")
                {
                    cd = cdD.TimKiem(null,cccd.textBox.Text,"",1)[0];
                    //MessageBox.Show(cdD.ToString());
                    CongDan cdn = new CongDan(cd[0].ToString(), cd[1].ToString(), cd[2].ToString(), Convert.ToDateTime(cd[3]), cd[4].ToString(), cd[5].ToString(), cd[6].ToString(), cd[7].ToString()
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
            LamSach lc = new LamSach();
            lc.LamSachGiaTri(FKT,null,1);
            BoTroGKT.Clear();
        }
    }
}
