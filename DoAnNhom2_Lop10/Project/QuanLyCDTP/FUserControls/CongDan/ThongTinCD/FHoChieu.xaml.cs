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
    /// Interaction logic for FHoChieu.xaml
    /// </summary>
    public partial class FHoChieu : UserControl
    {
        public FHoChieu()
        {
            InitializeComponent();
        }
        HoChieuDao hcD = new HoChieuDao();
        NhatKyDao nkD=new NhatKyDao();
        Check ck=new Check();
        void CLear()
        {
            List<InfoCard> lifor = new List<InfoCard>()
            {
                maso,sodienthoai,noicap,sohochieu,cccd
            };
            foreach (InfoCard card in lifor)
            {
                card.textBox.Clear();
            }
            ngaycap.SelectedDate = null;
        }
        void ClearAgaint()
        {
            List<InfoCard> lifor = new List<InfoCard>()
            {
                stt,id,noiden
            };
            foreach (InfoCard card in lifor)
            {
                card.textBox.Clear();
            }
            ngaydi.SelectedDate = null;
            ngayve.SelectedDate = null;
        }
        private void btnxoatext_Click(object sender, RoutedEventArgs e)
        {
            CLear();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            ck = new Check(maso.textBox.Text);
            if (ck.checkID() == true)
            {

                HoChieu hc = new HoChieu(Convert.ToInt32(maso.textBox.Text),sohochieu.textBox.Text,ngaycap.SelectedDate.Value,noicap.textBox.Text
                    ,sodienthoai.textBox.Text,cccd.textBox.Text);

                bool checkhc = ck.CheckNotNull(hc);
                if (checkhc == true)
                {
                    if (hcD.SuaHoChieu(hc) != null)
                    {
                        MessageBox.Show("Thanh Cong", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    }    
                }
                else
                {
                    MessageBox.Show("Thông tin không được bỏ trống", "Thông báo",
                              MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lỗi Định Dạng ID là một số nguyên", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }

        private void btnDKHoChieu_Click(object sender, RoutedEventArgs e)
        {
            ck = new Check(maso.textBox.Text);
            if (ck.checkID() == true)
            {

                HoChieu hc = new HoChieu(Convert.ToInt32(maso.textBox.Text), sohochieu.textBox.Text, ngaycap.SelectedDate.Value, noicap.textBox.Text
                    , sodienthoai.textBox.Text, cccd.textBox.Text);

                bool checkhc = ck.CheckNotNull(hc);
                if (checkhc == true)
                {
                    if (hcD.ThemHoChieu(hc) != null)
                    {
                        MessageBox.Show("Thanh Cong", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    }    
                }
                else
                {
                    MessageBox.Show("Thông Tin Không Được Bỏ Trống", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lỗi Định Dạng ID là một số nguyên", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            ck = new Check(maso.textBox.Text);
            if (ck.checkID() == true)
            {
                HoChieu hc = new HoChieu(Convert.ToInt32(maso.textBox.Text));
                if (hcD.XoaHC(hc) == null)
                {
                    MessageBox.Show("Bạn Vui Lòng Xoá Lịch Trình Đi Lại Của 1 Người " +
                       "Trong Hộ Chiếu Trước Rồi Hãy Thực Hiện Lại Thao Tác Này !", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Thành Công", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Lỗi Định Dạng STT là một số nguyên", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }

        }
        void ThongTin(HoChieu hc)
        {
            List<InfoCard> linfo = new List<InfoCard>()
            {
                maso,sohochieu,noicap,sodienthoai,cccd
            };
            Object[] hcproperties = new Object[] { hc.Id,hc.Sodoc
                ,hc.Noicap,hc.Sdt,hc.Cccd};
            for (int i = 0; i < linfo.Count; i++)
            {
                linfo[i].textBox.Text = hcproperties[i].ToString();
            }
            ngaycap.SelectedDate = hc.Ngaycap;
        }
        private void maso_KeyDown(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                DataRow cd;
                ck = new Check(maso.textBox.Text);
                if (ck.checkID() == true)
                {
                    HoChieu hochieu = new HoChieu(Convert.ToInt32(maso.textBox.Text));
                    try
                    {
                        cd = hcD.TimKiemHoChieu(hochieu.Id)[0];
                    }
                    catch
                    {
                        MessageBox.Show("Khong tim thay trong co so du lieu", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                        return;
                    }
                    HoChieu hc = new HoChieu(Convert.ToInt32(cd[0].ToString()), cd[1].ToString(), Convert.ToDateTime(cd[2].ToString()),
                        cd[3].ToString(), cd[4].ToString(), cd[5].ToString());
                   
                    ThongTin(hc);
                }
                else
                {
                    MessageBox.Show("Lỗi Định Dạng ID là một số nguyên", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
        }

        private void btnthemlt_Click(object sender, RoutedEventArgs e)
        {
            ck = new Check(stt.textBox.Text);
            if (ck.checkID() == true)
            {
                ck = new Check(id.textBox.Text);
                if (ck.checkID() == true)
                {
                    NhatKyDiLai nk = new NhatKyDiLai(Convert.ToInt32(stt.textBox.Text),Convert.ToInt32(id.textBox.Text),noiden.textBox.Text,
                        ngaydi.SelectedDate.Value,ngayve.SelectedDate.Value);
                    bool checkhc = ck.CheckNotNull(nk);
                    if (checkhc == true)
                    {
                        if (nkD.ThemLT(nk) != null)
                        {
                            MessageBox.Show("Thanh Cong", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                        }    
                    }
                    else
                    {
                        MessageBox.Show("Thông Tin Không Được Bỏ Trống", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi Định Dạng ID là một số nguyên", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lỗi Định Dạng STT là một số nguyên", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }

        private void btnXoate_Click(object sender, RoutedEventArgs e)
        {
            ClearAgaint();
        }

        private void btnsualt_Click(object sender, RoutedEventArgs e)
        {
            ck = new Check(stt.textBox.Text);
            if (ck.checkID() == true)
            {
                ck = new Check(id.textBox.Text);
                if (ck.checkID() == true)
                {
                    NhatKyDiLai nk = new NhatKyDiLai(Convert.ToInt32(stt.textBox.Text), Convert.ToInt32(id.textBox.Text), noiden.textBox.Text,
                        ngaydi.SelectedDate.Value, ngayve.SelectedDate.Value);
                    bool checkhc = ck.CheckNotNull(nk);
                    if (checkhc == true )
                    {
                        if (nkD.SuaLT(nk) != null)
                        {
                            MessageBox.Show("Thanh Cong", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                        }    
                    }
                    else
                    {
                        MessageBox.Show("Thông Tin Không Được Bỏ Trống", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi Định Dạng ID là một số nguyên", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lỗi Định Dạng STT là một số nguyên", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
        void ThongTinNhatKy(NhatKyDiLai nk)
        {
            List<InfoCard> linfo = new List<InfoCard>()
            {
                stt,id,noiden
            };
            Object[] hcproperties = new Object[] { nk.Stt, nk.Id, nk.Noiden };
            for (int i = 0; i < linfo.Count; i++)
            {
                linfo[i].textBox.Text = hcproperties[i].ToString();
            }
            ngaydi.SelectedDate = nk.Ngaydi;
            ngayve.SelectedDate = nk.Ngayden;

        }
        private void stt_KeyDown(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                DataRow cd;
                ck = new Check(stt.textBox.Text);
                if (ck.checkID() == true)
                {
                    NhatKyDiLai nk = new NhatKyDiLai(Convert.ToInt32(stt.textBox.Text));
                    try
                    {
                        cd = nkD.TimKiemLS(nk)[0];
                    }
                    catch
                    {
                        MessageBox.Show("Không Tồn Tại CCCD", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                        return;
                    }
                    NhatKyDiLai nkd = new NhatKyDiLai(Convert.ToInt32(cd[0]), Convert.ToInt32(cd[1]), cd[2].ToString(),
                        Convert.ToDateTime(cd[3]), Convert.ToDateTime(cd[4]));
                    ThongTinNhatKy(nkd);
                }
                else
                {
                    MessageBox.Show("Lỗi Định Dạng STT là một số nguyên", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
        }

        private void cccd_KeyDown(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                DataRow cd;
                HoChieu hc = new HoChieu(cccd.textBox.Text) ;
                try
                {
                    cd = hcD.Check(hc, 1, null)[0];
                    MessageBox.Show("Tồn Tại CCCD", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Không Tồn Tại CCCD", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
        }

        private void id_KeyDown(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                DataRow cd;
                ck = new Check(id.textBox.Text);
                if (ck.checkID() == true)
                {
                    NhatKyDiLai nk = new NhatKyDiLai(Convert.ToInt32(id.textBox.Text));
                    try
                    {
                        cd = hcD.Check(null, 2, nk)[0];
                        MessageBox.Show("Tồn Tại ID", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Không Tồn Tại ID", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi Định Dạng ID là một số nguyên", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
        }

        private void btnXoalt_Click(object sender, RoutedEventArgs e)
        {
            ck = new Check(stt.textBox.Text);
            if (ck.checkID() == true)
            {
                NhatKyDiLai hc = new NhatKyDiLai(Convert.ToInt32(stt.textBox.Text));
                if (nkD.XoaLT(hc) == null)
                {
                    MessageBox.Show("Thất Bại");
                }
                else
                {
                    MessageBox.Show("Thành Công", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Lỗi Định Dạng STT là một số nguyên", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
    }
}
