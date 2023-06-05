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
using System.Reflection;

namespace QuanLyCDTP
{
    /// <summary>
    /// Interaction logic for FThue.xaml
    /// </summary>
    public partial class FHoaDonThue : UserControl
    {
        LoaiThueDao ltd=new LoaiThueDao();
        HoaDonThueDao hdtD=new HoaDonThueDao();
        TruyVanChungDao tvc = new TruyVanChungDao();
        Check item = new Check();
        public FHoaDonThue()
        {
            InitializeComponent();
        }
        void ThongTinHoaDon(HoaDonThue hd )
        {
            List<Object> lproperties = new List<Object>
            {
                hd.Mahoadon,hd.Macd,hd.Maloaithue,hd.Sotienthue
            };
            List<InfoCard> linf = new List<InfoCard>()
            {
                txtmahd,txtcccd,txtmaloaithue,txtsotien
            };
            for (int i = 0; i < lproperties.Count; i++) 
            {
                linf[i].textBox.Text= lproperties[i].ToString();
            }
            datengaylap.SelectedDate = hd.Ngaylaphoadon;
        }
        private void btnTinhToan_Click(object sender, RoutedEventArgs e)
        {
            item=new Check(txtmaloaithue.textBox.Text);
            if (item.checkID())
            {
                HoaDonThue hdt = new HoaDonThue(txtcccd.textBox.Text, Int32.Parse(txtmaloaithue.textBox.Text));
                if (hdtD.CheckItem(hdt,1).Count!=0 && hdtD.CheckItem(hdt, 2).Count!=0)
                {
                    try
                    {
                        CongDan cd = new CongDan(txtcccd.textBox.Text);
                        LoaiThue lt = new LoaiThue(Convert.ToInt32(txtmaloaithue.textBox.Text));
                        DataRow tienluong = (tvc.GetValue("CongDan", "TienLuong", "cccd", cd.CCCD, 2)[0]);
                        DataRow thuesuat = (ltd.TimKiemMucthue(lt)[0]);
                        float sotien = float.Parse(tienluong[0].ToString()) * float.Parse(thuesuat[0].ToString());
                        txtsotien.textBox.Text = sotien.ToString();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không tìm thấy hoặc có lỗi về định dạng", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Không Tồn Tại CCCD và Mã Loại Thuế", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }    
            }
            else
            {
                MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }    
        }

        private void btnaddthue_Click(object sender, RoutedEventArgs e)
        {
            item = new Check(txtmaloaithue.textBox.Text);
            if (item.checkID())
            {
                HoaDonThue hdt = new HoaDonThue(Convert.ToInt32(txtmahd.textBox.Text), txtcccd.textBox.Text,
                    Convert.ToInt32(txtmaloaithue.textBox.Text), datengaylap.SelectedDate.Value, float.Parse(txtsotien.textBox.Text));
                bool checkhd = item.CheckNotNull(hdt);
                if (checkhd == true)
                {
                    hdtD.Add(hdt);
                    MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }    
        }

        private void btndeletethue_Click(object sender, RoutedEventArgs e)
        {
            item = new Check(txtmaloaithue.textBox.Text);
            if (item.checkID())
            {
                HoaDonThue hdt = new HoaDonThue(Convert.ToInt32(txtmahd.textBox.Text));
                if (hdtD.Xoa(hdt) == null)
                {
                    MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }    
           
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HoaDonThue hdt = new HoaDonThue(Convert.ToInt32(txtmahd.textBox.Text), txtcccd.textBox.Text,
                  Convert.ToInt32(txtmaloaithue.textBox.Text), datengaylap.SelectedDate.Value, float.Parse(txtsotien.textBox.Text));
                bool checkhd = item.CheckNotNull(hdt);
                if (checkhd == true)
                {
                    hdtD.Sua(hdt);
                    MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
            
        }

        private void btnXoaNoiDung_Click(object sender, RoutedEventArgs e)
        {
            List<InfoCard> infor = new List<InfoCard>()
            {
                txtmaloaithue, txtsotien,txtmahd,txtcccd
            };
            foreach(InfoCard card in infor)
            {
                card.textBox.Clear();
            }
            datengaylap.SelectedDate = null;
        }

        private void txtMaSoTo_KeyDown(object sender, KeyEventArgs e)
        
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                DataRow cd;
                item = new Check(txtmahd.textBox.Text);
                if (item.checkID())
                {
                    HoaDonThue hdt = new HoaDonThue(Convert.ToInt32(txtmahd.textBox.Text));
                    try
                    {
                        cd = hdtD.Search(hdt)[0];
                    }
                    catch
                    {
                        MessageBox.Show("Khong tim thay trong co so du lieu");
                        return;
                    }
                    ThongTinHoaDon(new HoaDonThue(Convert.ToInt32(cd[0].ToString()), cd[1].ToString(),
                        Convert.ToInt32(cd[2]), Convert.ToDateTime(cd[3]), float.Parse(cd[4].ToString())));
                }
                else
                {
                    MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }

        }
    }
}
