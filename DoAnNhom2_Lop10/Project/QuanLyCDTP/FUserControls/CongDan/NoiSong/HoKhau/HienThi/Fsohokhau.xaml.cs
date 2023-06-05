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
    /// Interaction logic for Fsohokhau.xaml
    /// </summary>
    public partial class Fsohokhau : UserControl
    {
        SoHoKhauDao shkDao = new SoHoKhauDao();
        DataRowCollection dr;
        int slthanhvien = 0;
        public Fsohokhau()
        {
            InitializeComponent();
        }
        FsohokhauForm1 form1 = new FsohokhauForm1();
        FsohokhauForm2 form2 = new FsohokhauForm2();
        public void LamSachUS()
        {
            TimKiemHK.textBox.Text = "";
            gridhienthi.Children.Clear();
        }
        private void ClickTimKiem(object sender, RoutedEventArgs e)
        {
            try {
                dr = shkDao.TimKiem(TimKiemHK.textBox.Text,"",1);
                slthanhvien = dr.Count;
                form1.MSHoKhau.Text = (string)dr[0][0];
                form1.HoVaTen.Text = (string)dr[0][1];
                form1.CuTru.Text = (string)dr[0][2];
                form1.Ngay.Text = dr[0][3].ToString();
                form1.Thang.Text = dr[0][4].ToString();
                form1.Nam.Text = dr[0][5].ToString();
                form1.NguoiDangKy.Text = (string)dr[0][7];
                form1.SoDangKy.Text = (string)dr[0][8];
                gridhienthi.Children.Clear();
                gridhienthi.Children.Add(form1);
            }
            catch
            {
                MessageBox.Show("Khong tim thay so ho khau. Vui long kiem tra lai");
            }
            
        }
        int check = 0;
        void Display()
        {
            form2.HoVaTen.Text = dr[check][1].ToString();
            form2.NgayThangNamSinh.Text = dr[check][11].ToString();
            form2.GioiTinh.Text = dr[check][12].ToString();
            form2.QueQuan.Text = dr[check][2].ToString();
            form2.Ngay.Text = dr[check][3].ToString();
            form2.Thang.Text = dr[check][4].ToString();
            form2.Nam.Text = dr[check][5].ToString();
            form2.TenCanBo.Text = dr[check][7].ToString();
            
        }
        private void btnNext_click(object sender, RoutedEventArgs e)
        {
            
            if (check < slthanhvien)
            {
                Display();
                gridhienthi.Children.Clear();
                gridhienthi.Children.Add(form2);
                check++;
            }
           
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            gridhienthi.Children.Clear();
            gridhienthi.Children.Add(form1);
            check = 0;
        }

        
    }
}
