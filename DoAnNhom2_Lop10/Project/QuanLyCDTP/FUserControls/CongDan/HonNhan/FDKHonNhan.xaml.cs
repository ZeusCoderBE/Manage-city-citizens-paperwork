using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyCDTP
{
    /// <summary>
    /// Interaction logic for FHonNhan.xaml
    /// </summary>
    public partial class FDKHonNhan : UserControl
    {
        public FDKHonNhan()
        {
            InitializeComponent();
            
        }
        CongDanDAO cdd = new CongDanDAO();
        HonNhanDao hnd = new HonNhanDao();

        void ThongTin(CongDan congDan, List<InfoCard> linfor)
        {
            string namecha = "";
            string nameme = "";
            try
            {
                namecha = (cdd.TimKiem(null, congDan.CccdCha, "", 1)[0][1]).ToString();
            }
            catch
            {
                namecha = "";
            }
            try
            {
                nameme = (cdd.TimKiem(null, congDan.Cccdme, "", 1)[0][1]).ToString();
            }
            catch
            {
                nameme = "";
            }
            List<Object> properties = new List<Object>
                {
                    congDan.HoTen,namecha.ToString(),congDan.CCCD,congDan.QueQuan,
                    nameme, congDan.HonNhan,congDan.CccdCha,congDan.Cccdme
                };
            for (int i = 0; i < properties.Count; i++)
            {
                try
                {
                    linfor[i].textBox.Text = properties[i].ToString();
                }
                catch
                {

                }
            }
        }
        void ThongTinNam(CongDan cdnam)
        {
            List<InfoCard> linfor = new List<InfoCard>
            {
                nameNam,namefnam,cccdNam,quequanNam,namemnam,honnhanNam,namefcnam,namecmnam
            };
            ThongTin(cdnam, linfor);
        }

        void ThongTinNu(CongDan cdnu)
        {
            List<InfoCard> linfor = new List<InfoCard>
            {
                nameNu,namefNu,cccdNu,quequanNu,namemNu,honhanNu,namecfNu,namecmNu
            };
            ThongTin(cdnu, linfor);
        }
        private void TimKiemCongDan(string cccd, Action<CongDan> ThongTin)
        {
            CongDan congdan = new CongDan(cccd);
            DataRow cd;

            try
            {
                cd = cdd.TimKiem(congdan, "", "", 2)[0];

                CongDan congdans = new CongDan(cd[0].ToString(), cd[1].ToString(), cd[2].ToString(), Convert.ToDateTime(cd[3]),
                    cd[4].ToString(), cd[5].ToString(), cd[6].ToString(), cd[7].ToString(), cd[8].ToString(), cd[9].ToString(), cd[10].ToString(),
                    float.Parse(cd[11].ToString()), cd[12].ToString());
                
                ThongTin(congdans);
            }
            catch
            {
                MessageBox.Show("Khong tim thay cong dan trong co so du lieu", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                return;
            }

        }
        private void btnLyHon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HonNhan kethon = new HonNhan(honnhanNam.textBox.Text, cccdNam.textBox.Text, honhanNu.textBox.Text,
                cccdNu.textBox.Text, FBoTro.Date(), FBoTro.noidangky.textBox.Text,FBoTro.CCCDCanBo.textBox.Text);

                if (kethon.checkLH() == true)
                {
                    if (hnd.XoaHN(kethon))
                    {
                        MessageBox.Show("Thanh Cong");
                    }
                    else
                    {
                        MessageBox.Show("That Bai");
                    }
                }
                else
                {
                    MessageBox.Show("Hai người chưa đăng ký kết hôn!", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể thực hiện việc đăng ký ly hôn", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
        void Clear()
        {
            List<InfoCard> infos = new List<InfoCard>()
            {
                nameNam,namefnam,cccdNam,quequanNam,namemnam,honnhanNam,namefcnam, namecmnam, namecfNu, namecmNu
                ,nameNu,namefNu,cccdNu,quequanNu,nameNu,honhanNu,FBoTro.noidangky,FBoTro.Ngay,FBoTro.Thang,FBoTro.Nam,FBoTro.CCCDCanBo,FBoTro.TenCanBo,namemNu
            };
            foreach (InfoCard info in infos)
            {
                info.textBox.Clear();
            }
        }
        private void btnKetHon_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                HonNhan kethon = new HonNhan(honnhanNam.textBox.Text, cccdNam.textBox.Text, honhanNu.textBox.Text,
                    cccdNu.textBox.Text, FBoTro.Date(), FBoTro.noidangky.textBox.Text,FBoTro.CCCDCanBo.textBox.Text);
                if (kethon.checkKH() == true)
                {
                    if (hnd.ThemHN(kethon))
                        MessageBox.Show("Thành Công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("That Bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Người này đã kết hôn rồi !", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng năm, tháng ,ngày: YYYY-MM-DD !", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
        public string toString(DataRow cd,int index)
        {
            try
            {
                string thongtin = cd[index].ToString();
                return thongtin;
            }
            catch
            {

            }
            return "";
        }
        
        private void EnterKey(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                DataRowCollection dbc = hnd.TimKiemThongTinKS(null, cccdNam.textBox.Text, cccdNu.textBox.Text, 2);
                if (dbc.Count != 0)
                {
                    try
                    {
                        TimKiemCongDan(dbc[0][0].ToString(), ThongTinNam);
                        TimKiemCongDan(dbc[0][1].ToString(), ThongTinNu);
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    try
                    {
                        TimKiemCongDan(cccdNam.textBox.Text, ThongTinNam);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void EnterKeyNu(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                DataRowCollection dbc = hnd.TimKiemThongTinKS(null, cccdNam.textBox.Text, cccdNu.textBox.Text, 2);
                if (dbc.Count != 0)
                {
                    try
                    {
                        TimKiemCongDan(dbc[0][1].ToString(), ThongTinNu);
                        TimKiemCongDan(dbc[0][0].ToString(), ThongTinNam);
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    try
                    {
                        TimKiemCongDan(cccdNu.textBox.Text, ThongTinNu);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
        private void btnClearT_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

       
    }
}
