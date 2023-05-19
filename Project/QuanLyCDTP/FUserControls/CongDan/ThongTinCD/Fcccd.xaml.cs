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
    /// Interaction logic for Fcccd.xaml
    /// </summary>
    public partial class Fcccd : UserControl
    {

        CongDanDAO cdD = new CongDanDAO();
        Check ch = new Check();
        KhaiSinhDao ksd = new KhaiSinhDao();
        public Fcccd()
        {
            InitializeComponent();
        }
        void ThongTin(CongDan cd)
        {
            List<Object> properties = new List<Object>() { cd.CCCD, cd.HoTen, cd.GioiTinh, 
                 cd.QueQuan, cd.ThuongTru, cd.TamTru,
                cd.DanToc, cd.HonNhan, cd.CccdCha, cd.Cccdme,cd.Tienluong,cd.Quoctich };
            List<InfoCard> ltxt = new List<InfoCard>()
            {
               maso,name, gioitinh, quequan, thuongtru,
                tamtru, dantoc, honnhan, cccdcha, cccdme,tienluong,quoctich
            };
            for (int i = 0; i < ltxt.Count; i++)
            {
                ltxt[i].textBox.Text = properties[i].ToString();
            }
            Date.SelectedDate = Convert.ToDateTime(cd.NgaySinh);
        }
        void Clear()
        {
            List<InfoCard> ltxt = new List<InfoCard>()
            {
               maso,name, gioitinh, quequan, thuongtru,giaykhaisinh,
                tamtru, dantoc, honnhan, cccdcha, cccdme,tienluong,quoctich
            };
            foreach (InfoCard l in ltxt)
            {
                l.textBox.Clear();
            }
            Date.SelectedDate = null;
        }
        void ThongTinNam(KhaiSinh ks)
        {
            try
            {
                List<InfoCard> infor = new List<InfoCard>()
                {
                    giaykhaisinh,name,gioitinh,dantoc,quequan,thuongtru,tamtru,quoctich,cccdcha,cccdme
                };
                    Object[] properties = new Object[] {ks.Id,ks.Hoten,ks.Gioitinh
                ,ks.Dantoc,ks.Quoctich,ks.Noisinh,ks.Noisinh,ks.Quoctich,ks.CCCDCha,ks.CCCDMe};
                 for (int i = 0; i < infor.Count; i++)
                    {
                        infor[i].textBox.Text = properties[i].ToString();
                    }
                honnhan.textBox.Text = "Độc Thân";
                tienluong.textBox.Text = "0";
                Date.SelectedDate = ks.NgayThangNamSinh;
            }
            catch
            {
                MessageBox.Show("Co loi xay ra.");
            }
            
        }
        private void btndangky_Click(object sender, RoutedEventArgs e)
        {
            ch = new Check(tienluong.textBox.Text);
            if (ch.checkID() == true)
            {

                CongDan cd = new CongDan(maso.textBox.Text, name.textBox.Text, gioitinh.textBox.Text, Date.SelectedDate.Value
               , quequan.textBox.Text, thuongtru.textBox.Text, tamtru.textBox.Text, dantoc.textBox.Text
                , honnhan.textBox.Text, cccdcha.textBox.Text, cccdme.textBox.Text, float.Parse(tienluong.textBox.Text), quoctich.textBox.Text);
                bool dk = ch.CheckNotNull(cd, new List<string> { "NgayMat" });
                if (dk == true)
                {
                    if (cdD.Them(cd) == true)
                    {
                        MessageBox.Show("Thành Công !", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("That Bai");
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin không được bỏ trống tru o mat", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                }
            }
            else
            {
                MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }

        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            CongDan cd = new CongDan(maso.textBox.Text);
            if (cdD.Xoa(cd)==null)
            {
                MessageBox.Show("Bạn Vui Lòng Xoá Hoá Đơn Thuế của người này trước rồi hãy thực hiện lại thao tác này",
                    "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }    
            else
            {
                MessageBox.Show("Thành Công !", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }    
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            ch = new Check(tienluong.textBox.Text);
            if (ch.checkID() == true)
            {

                CongDan cd = new CongDan(maso.textBox.Text, name.textBox.Text, gioitinh.textBox.Text, Date.SelectedDate.Value
               , quequan.textBox.Text, thuongtru.textBox.Text, tamtru.textBox.Text, dantoc.textBox.Text
                , honnhan.textBox.Text, cccdcha.textBox.Text, cccdme.textBox.Text, float.Parse(tienluong.textBox.Text), quoctich.textBox.Text);
                bool dk = ch.CheckNotNull(cd, new List<string> { "NgayMat" });
                if (dk == true)
                {
                    if (cdD.Sua(cd) == true)
                    {
                        MessageBox.Show("Thành Công !", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("That Bai");
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin không được bỏ trống tru o mat", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                }
            }
            else
            {
                MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
        private void btnxoatext_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        private void maso_KeyDown(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                DataRow cd;
                CongDan dan = new CongDan(maso.textBox.Text);
                try
                {
                    cd = cdD.TimKiem(dan, "", "", 2)[0];
                }
                catch
                {
                    MessageBox.Show("Khong tim thay trong co so du lieu","thông Báo",MessageBoxButton.YesNo,MessageBoxImage.Warning);
                    return;
                }
                ThongTin(new CongDan(cd[0].ToString(), cd[1].ToString(), cd[2].ToString(), Convert.ToDateTime(cd[3]), cd[4].ToString(), cd[5].ToString(), cd[6].ToString(), cd[7].ToString()
                    , cd[8].ToString(), cd[9].ToString(), cd[10].ToString(),float.Parse(cd[11].ToString()), cd[12].ToString()));
            }
        }

        private void masokhaisinh(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                ch = new Check(giaykhaisinh.textBox.Text);
                if (ch.checkID())
                {
                    DataRow cd;
                    try
                    {
                        cd = ksd.TimKiem(null, giaykhaisinh.textBox.Text, "", 1)[0];
                    }
                    catch
                    {
                        MessageBox.Show("Khong tim thay trong co so du lieu", "thông Báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        return;
                    }

                    Random rnd = new Random();
                    maso.textBox.Text = rnd.Next().ToString();
                    ThongTinNam(new KhaiSinh(Int32.Parse(cd[0].ToString()), cd[1].ToString(), cd[2].ToString(),
                        Convert.ToDateTime(cd[3]).Date, cd[4].ToString(), cd[5].ToString(), cd[6].ToString(), cd[7].ToString()
                        , cd[8].ToString(), cd[9].ToString(), cd[10].ToString(), cd[11].ToString(), cd[12].ToString(), cd[13].ToString(), cd[14].ToString(), cd[15].ToString(), Convert.ToDateTime(cd[16].ToString()), cd[17].ToString()));
                }
                else
                {
                    MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }    
            }
        }
    }
}
