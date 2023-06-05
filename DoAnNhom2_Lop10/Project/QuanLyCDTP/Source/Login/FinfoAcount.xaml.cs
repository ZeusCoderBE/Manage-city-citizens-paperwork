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
    /// Interaction logic for FinfoAcount.xaml
    /// </summary>
    public partial class FinfoAcount : UserControl
    {
        //FAccount acc = new FAccount();
        Check item=new Check();
        public FinfoAcount()
        {

            InitializeComponent();
        }
        NguoiQuanLyDao ngqld=new NguoiQuanLyDao();
        void ThongTin(NguoiQuanLy nql)
        {
            List<Object> ltk = new List<Object>()
            {
                nql.Manv,nql.Hoten,nql.Chinhanh,nql.Sdt,nql.Loaitk
            };
            List<ForderAccount> properties = new List<ForderAccount>()
            {
              manv,hoten,chinhanh,sodienthoai,loaitk
            };
            for (int i = 0; i < properties.Count; i++)
            {
                properties[i].Desc = ltk[i].ToString();
            }

        }

        private void btnXem_Click(object sender, RoutedEventArgs e)
        {
            DataRow cd;

            try
            {
                NguoiQuanLy ql = new NguoiQuanLy(Flogin.Manv);
                cd = ngqld.LoadTK(ql, 1)[0];
            }
            catch
            {
                MessageBox.Show("Thất Bại!", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                return;
            }
            NguoiQuanLy nql = new NguoiQuanLy(cd[0].ToString(), cd[1].ToString(), cd[2].ToString(),
                cd[3].ToString(), cd[4].ToString(), cd[5].ToString());
            ThongTin(nql);
        }
        private void btncapnhat_Click(object sender, RoutedEventArgs e)
        {
            NguoiQuanLy nql = new NguoiQuanLy(manv.Desc,hoten.Desc,chinhanh.Desc,sodienthoai.Desc,loaitk.Desc);

            if (ngqld.SetThongTin(nql) != null)
            {
                MessageBox.Show("Thành Công !", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
        }
    }
}
