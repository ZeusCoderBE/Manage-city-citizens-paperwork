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

namespace QuanLyCDTP.FUserControls.TraCuu
{
    /// <summary>
    /// Interaction logic for FSKhaiSinh.xaml
    /// </summary>
    public partial class FSKhaiSinh : UserControl
    {
        public FSKhaiSinh()
        {
            InitializeComponent();
        }

        KhaiSinhDao ksd = new KhaiSinhDao();
        Check check = new Check();

        void ThongTinKS(KhaiSinh ks)
        {
            List<InfoCard> infor = new List<InfoCard>()
            {
                maso,name,dantoc,quoctich,noisinh,namecha,dantoccha, quoctichcha,
                nameme, dantocme,quoctichme,namedk,cccdchong,cccdvo
            };
            Object[] properties = new Object[] {ks.Id,ks.Hoten
            ,ks.Dantoc,ks.Quoctich,ks.Noisinh,ks.Hotencha,ks.Dantoccha,ks.Quoctichcha,ks.Hotenme,ks.Dantocme,ks.Quoctichme
            ,ks.Nguoidangky,ks.CCCDCha,ks.CCCDMe};
            for (int i = 0; i < infor.Count; i++)
            {
                infor[i].textBox.Text = properties[i].ToString();
            }
            gioitinh.Text = ks.Gioitinh.ToString();
            dateSinh.SelectedDate = ks.NgayThangNamSinh;
            datedk.SelectedDate = ks.NgayThangNamDK;
        }

        private void ClickTimKiem(object sender, RoutedEventArgs e)
        {
            check = new Check(infocard.Text);
            if (check.checkID() == true)
            {
                DataRow cd;
                try
                {
                    cd = ksd.TimKiem(null, infocard.Text, "", 1)[0];
                }
                catch
                {
                    MessageBox.Show("Khong tim thay trong co so du lieu");
                    return;
                }
                KhaiSinh ks = new KhaiSinh(Int32.Parse(cd[0].ToString()), cd[1].ToString(), cd[2].ToString(),
                   Convert.ToDateTime(cd[3]).Date, cd[4].ToString(), cd[5].ToString(), cd[6].ToString(), cd[7].ToString(), cd[8].ToString(),
                   cd[9].ToString(), cd[10].ToString(), cd[11].ToString(), cd[12].ToString(), cd[13].ToString(),
                   cd[14].ToString(), cd[15].ToString(), Convert.ToDateTime(cd[16].ToString()), cd[17].ToString());
                ThongTinKS(ks);
            }
            else
            {
                MessageBox.Show("Lỗi Định Dạng!", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }

        }

        private void ClickClear(object sender, RoutedEventArgs e)
        {
            List<InfoCard> infor = new List<InfoCard>()
            {
                maso, name, dantoc, quoctich, noisinh, namecha, dantoccha, quoctichcha,
                nameme, dantocme, quoctichme, namedk, cccdchong, cccdvo
            };
            foreach(InfoCard card in infor) 
            {
                card.textBox.Clear();
            }
            gioitinh.Items.Clear();
            datedk.SelectedDate = null;
            dateSinh.SelectedDate = null;
        }
    }
}
