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

namespace QuanLyCDTP
{
    /// <summary>
    /// Interaction logic for Fkhaisinh.xaml
    /// </summary>
    public partial class Fkhaisinh : UserControl
    {
        KhaiSinhDao ksd = new KhaiSinhDao();
        Check check = new Check();
        HonNhanDao hnd = new HonNhanDao();
        CongDanDAO cdd = new CongDanDAO();

        public Fkhaisinh()
        {
            InitializeComponent();
        }
        void TimKiemCongDan(string cccdNam, string cccdNu)
        {


            DataRow cd;

            try
            {
                try
                {
                    cd = cdd.TimKiem(null, cccdNam, "", 1)[0];
                    cccdcha.textBox.Text = cd[0].ToString();
                    namecha.textBox.Text = cd[1].ToString();
                    dantoccha.textBox.Text = cd[7].ToString();
                    quoctichcha.textBox.Text = cd[12].ToString();
                }
                catch
                {

                }
                try
                {
                    cd = cdd.TimKiem(null, cccdNu, "", 1)[0];
                    cccdme.textBox.Text = cd[0].ToString();
                    nameme.textBox.Text = cd[1].ToString();
                    dantocme.textBox.Text = cd[7].ToString();
                    quoctichme.textBox.Text = cd[12].ToString();
                }
                catch
                {

                }
            }
            catch
            {
                MessageBox.Show("Khong tim thay trong co so du lieu");
                return;
            }
        }
        private void btnkhaisinh_Click(object sender, RoutedEventArgs e)
        {
            check = new Check(maso.textBox.Text);
            if (check.checkID() == true)
            {
                KhaiSinh khaisinh = new KhaiSinh(Int32.Parse(maso.textBox.Text), name.textBox.Text, gioitinh.Text, BoTroGKS.Date(), dantoc.textBox.Text
                    , quoctich.textBox.Text, noisinh.textBox.Text, namecha.textBox.Text, dantoccha.textBox.Text,
                    quoctichcha.textBox.Text, nameme.textBox.Text, dantocme.textBox.Text, quoctichme.textBox.Text,
                    BoTroGKS.CCCDCanBo.textBox.Text, cccdcha.textBox.Text, cccdme.textBox.Text, BoTroGKS.Date(), BoTroGKS.CCCDCanBo.textBox.Text);
                bool checkkhasinh = check.CheckNotNull(khaisinh);
                if (checkkhasinh == true)
                {
                    if (ksd.ThemKhaiSinh(khaisinh))
                        MessageBox.Show("Thành Công", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Thông Tin Không Được Bỏ Trống", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lỗi Định Dạng!", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }

        void ThongTinNam(KhaiSinh ks,DateTime date, string cccdcanbo)
        {
            List<InfoCard> infor = new List<InfoCard>()
            {
                maso,name,dantoc,quoctich,noisinh,namecha,dantoccha, quoctichcha,
                nameme, dantocme,quoctichme,cccdcha,cccdme
            };
            Object[] properties = new Object[] {ks.Id,ks.Hoten
            ,ks.Dantoc,ks.Quoctich,ks.Noisinh,ks.Hotencha,ks.Dantoccha,ks.Quoctichcha,ks.Hotenme,ks.Dantocme,ks.Quoctichme,ks.CCCDCha,ks.CCCDMe};
            for (int i = 0; i < infor.Count; i++)
            {
                infor[i].textBox.Text = properties[i].ToString();
            }
   
            gioitinh.Text = ks.Gioitinh.ToString();
            BoTroGKS.CCCDCanBo.textBox.Text = cccdcanbo;
            BoTroGKS.TimKiem();
            BoTroGKS.DisplayDate(date);
        }
        private void maso_KeyDown(object sender, KeyEventArgs e)
        {     
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                check = new Check(maso.textBox.Text);
                if (check.checkID() == true)
                {
                    DataRow cd;
                    try
                    {
                        cd = ksd.TimKiem(null, maso.textBox.Text, "", 1)[0];
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
                    ThongTinNam(ks, Convert.ToDateTime(cd[16].ToString()), cd[17].ToString());
                }
                else
                {
                    MessageBox.Show("Lỗi Định Dạng!", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
        }
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            check = new Check(maso.textBox.Text);
            if (check.checkID() == true)
            {
                KhaiSinh khaisinh = new KhaiSinh(Int32.Parse(maso.textBox.Text));
                if (ksd.XoaKS(khaisinh) == null)
                {
                    MessageBox.Show("Hãy Thử Lại", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Lỗi Định Dạng!", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }

        private void btnxoatext_Click(object sender, RoutedEventArgs e)
        {
           List<InfoCard> infor = new List<InfoCard>()
            {
                maso,name,dantoc, quoctich,noisinh, cccdcha,cccdme,namecha,nameme,dantoccha,dantocme,quoctichcha,quoctichme,
                namecha,dantoccha,quoctichcha,nameme,dantocme,quoctichme,BoTroGKS.TenCanBo
            };
            foreach (InfoCard card in infor)
            {
                card.textBox.Clear();
            }
            BoTroGKS.Clear();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            check = new Check(maso.textBox.Text);
            if (check.checkID() == true)
            {
                KhaiSinh khaisinh = new KhaiSinh(Int32.Parse(maso.textBox.Text), name.textBox.Text, gioitinh.Text
                    , BoTroGKS.Date(), dantoc.textBox.Text
                   , quoctich.textBox.Text, noisinh.textBox.Text, namecha.textBox.Text, dantoccha.textBox.Text,
                   quoctichcha.textBox.Text, nameme.textBox.Text, dantocme.textBox.Text, quoctichme.textBox.Text, BoTroGKS.CCCDCanBo.textBox.Text, cccdcha.textBox.Text, cccdme.textBox.Text, BoTroGKS.Date(), BoTroGKS.CCCDCanBo.textBox.Text);
                bool checkks = check.CheckNotNull(khaisinh);
                if (checkks == true)
                {
                    if (ksd.SuaKhaiSinh(khaisinh))
                        MessageBox.Show("Thanh Cong", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("That Bai", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Lỗi Định Dạng!", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }

        private void Enter(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                DataRowCollection dbc = hnd.TimKiemThongTinKS(null, cccdcha.textBox.Text, cccdme.textBox.Text, 2);
                if (dbc.Count != 0)
                {
                    try
                    {
                        TimKiemCongDan(dbc[0][0].ToString(), dbc[0][1].ToString());
                    }
                    catch
                    {

                    }
                }
            }
        }


        private void Enter2(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                DataRowCollection dbc = hnd.TimKiemThongTinKS(null, cccdcha.textBox.Text, cccdme.textBox.Text, 2);
                if (dbc.Count != 0)
                {
                    try
                    {
                        TimKiemCongDan(dbc[0][0].ToString(), dbc[0][1].ToString());
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
