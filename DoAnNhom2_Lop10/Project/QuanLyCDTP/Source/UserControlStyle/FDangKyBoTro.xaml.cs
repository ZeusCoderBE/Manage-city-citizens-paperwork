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
    /// Interaction logic for FDangKyBoTro.xaml
    /// </summary>
    public partial class FDangKyBoTro : UserControl
    {
        CongDanDAO cdD = new CongDanDAO();
        DataRowCollection dr;
        DateTime date;
        public FDangKyBoTro()
        {
            InitializeComponent();
        }
        public void Clear()
        {
            Ngay.textBox.Text="";
            Thang.textBox.Text = "";
            Nam.textBox.Text = "";
            CCCDCanBo.textBox.Text = "";
            noidangky.textBox.Text = "";
            TenCanBo.textBox.Text = "";
        }
        public bool Check(List<InfoCard> uc)
        {
            foreach(var u in uc)
            {
                if (u.textBox.Text == "")
                {
                    return false;
                }
            }
            return true;
        }

        private void KhoiTao(object sender, RoutedEventArgs e)
        {
            date = DateTime.Now;
            Ngay.textBox.Text = date.Day.ToString();
            Thang.textBox.Text = date.Month.ToString();
            Nam.textBox.Text = date.Year.ToString();
        }
        public DateTime Date()
        {
            try
            {
                return date;
            }
            catch
            {
                MessageBox.Show("Khong the chuyen doi thoi gian");
            }
            return DateTime.MinValue;
        }
        public void DisplayDate(DateTime date2)
        {
            Ngay.textBox.Text = date2.Day.ToString();
            Thang.textBox.Text = date2.Month.ToString();
            Nam.textBox.Text = date2.Year.ToString();
        }
        public void TimKiem (){
            try
            {
                if (CCCDCanBo.textBox.Text != "")
                {
                    dr = cdD.TimKiem(null, CCCDCanBo.textBox.Text, "", 1);
                    TenCanBo.textBox.Text = dr[0][1].ToString();
                }
                else
                {
                    MessageBox.Show("Khong de truong thong tin bi trong.");
                }
            }
            catch
            {

            }
            
        }
        private void Enter(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                try
                {
                    TimKiem();
                }
                catch
                {
                    MessageBox.Show("Bi loi trong qua trinh tim kiem");
                }
            }
        }
        
    }
}
