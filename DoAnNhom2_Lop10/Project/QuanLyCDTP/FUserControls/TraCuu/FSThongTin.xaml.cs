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
    /// Interaction logic for thongtincn.xaml
    /// </summary>
    public partial class thongtincn : UserControl
    {
        CongDanDAO cdD = new CongDanDAO();
        TruyVanChungDao tvc = new TruyVanChungDao();
        KhaiTuDAO shk = new KhaiTuDAO();
        LamSach ls = new LamSach();
        public thongtincn()
        {
            InitializeComponent();
        }
        public void LamSachUS()
        {
            ClearTextBoxes();
            ClearInfoCards();
            ClearDatePickers();
            ResetGenderBackground();
        }

        private void ClearTextBoxes()
        {
            HoTen.Clear();
            CCCD.Clear();
            ThuongTru.Clear();
        }

        private void ClearInfoCards()
        {
            foreach (InfoCard infoCard in new InfoCard[] { cccdCha, cccdMe, HonNhan, TamTru, nameMe, nameCha })
            {
                infoCard.textBox.Clear();
            }
        }

        private void ClearDatePickers()
        {
            dateSinh.SelectedDate = null;
            dateMat.SelectedDate = null;
        }

        private void ResetGenderBackground()
        {
            Nam.Background = Brushes.White;
            Nu.Background = Brushes.White;
        }

        string name(string cccd)
        {
            try
            {

                return tvc.GetValue("CongDan", "hoten", "cccd", cccd, 2)[0][0].ToString();
            }
            catch
            {

            }
            return "";
        }
        void ThongTin(CongDan cd)
        {
            HoTen.Text = cd.HoTen;
            CCCD.Text = cd.CCCD;
            ThuongTru.Text = cd.ThuongTru;
            cccdCha.textBox.Text = cd.CccdCha;
            cccdMe.textBox.Text = cd.Cccdme;
            HonNhan.textBox.Text = cd.HonNhan;
            TamTru.textBox.Text = cd.TamTru;
            dateSinh.SelectedDate = cd.NgaySinh;
            nameMe.textBox.Text = cd.Cccdme == "" ? "" : name(cd.Cccdme);
            nameCha.textBox.Text = cd.CccdCha == "" ? "" : name(cd.CccdCha);
            Nam.Background = cd.GioiTinh == "Nam" ? Brushes.Red : Brushes.Transparent;
            Nu.Background = cd.GioiTinh == "Nam" ? Brushes.Transparent : Brushes.Pink;
            dateMat.SelectedDate = null;
            try
            {
                dateMat.SelectedDate = Convert.ToDateTime(shk.TimKiem(null, infocard.Text, 1)[0][1]);
            }
            catch(Exception)
            {

            }
        }


        private void ClickTimKiem(object sender, RoutedEventArgs e)
        {
            DataRow cd;
            CongDan dan = new CongDan(infocard.Text);
            try
            {
                cd = cdD.TimKiem(dan, "", "", 2)[0];
            }
            catch
            {
                MessageBox.Show("Có Lỗi Khi Tìm Kiếm !", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            CongDan cdn = new CongDan(cd[0].ToString(), cd[1].ToString(), cd[2].ToString(), Convert.ToDateTime(cd[3]), cd[4].ToString(), cd[5].ToString(), cd[6].ToString(), cd[7].ToString()
                        , cd[8].ToString(), cd[9].ToString(), cd[10].ToString(), float.Parse(cd[11].ToString()), cd[12].ToString());
            ThongTin(cdn);
        }

        private void ClickXoa(object sender, RoutedEventArgs e)
        {
            LamSachUS();
        }
    }
}
