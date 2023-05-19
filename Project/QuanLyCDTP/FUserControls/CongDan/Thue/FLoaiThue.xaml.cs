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
    /// Interaction logic for FLoaiThue.xaml
    /// </summary>
    public partial class FLoaiThue : UserControl
    {
        LoaiThueDao ltD=new LoaiThueDao();
        Check item=new Check();
        public FLoaiThue()
        {
            InitializeComponent();
        }

        private void btnxoaloaithue_Click(object sender, RoutedEventArgs e)
        {
            item = new Check(txtmalt.textBox.Text);
            if (item.checkID())
            {
                LoaiThue lt = new LoaiThue(Convert.ToInt32(txtmalt.textBox.Text));
                if (ltD.Xoa(lt) == null)
                {
                    MessageBox.Show("Bạn Vui Lòng Xoá Hoá Đơn Thế trước rồi hãy quay lại thao tác này !"
                        , "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }   
        }

        private void btnaddloaithue_Click(object sender, RoutedEventArgs e)
        {
            item = new Check(txtmalt.textBox.Text);
            if (item.checkID())
            {
                LoaiThue lt = new LoaiThue(Convert.ToInt32(txtmalt.textBox.Text), txtname.textBox.Text, float.Parse(txtmucthue.textBox.Text), FBoTro.Date().ToString(), FBoTro.noidangky.textBox.Text, FBoTro.CCCDCanBo.textBox.Text);
                bool checklt = item.CheckNotNull(lt);
                if (checklt == true)
                {
                    ltD.Add(lt);
                    MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }

        private void btnsualoaithue_Click(object sender, RoutedEventArgs e)
        {
            item = new Check(txtmalt.textBox.Text);
            if (item.checkID())
            {

                LoaiThue lt = new LoaiThue(Convert.ToInt32(txtmalt.textBox.Text), txtname.textBox.Text, float.Parse(txtmucthue.textBox.Text), FBoTro.Date().ToString(), FBoTro.noidangky.textBox.Text, FBoTro.CCCDCanBo.textBox.Text);
                bool checklt = item.CheckNotNull(lt);
                if (checklt == true)
                {
                    ltD.Sua(lt);
                    MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void btnXoaNoiDung_Click(object sender, RoutedEventArgs e)
        {
            List<InfoCard> infor = new List<InfoCard>()
            {
               txtmalt,txtname, txtmucthue
            };
            foreach(InfoCard card in infor) 
            {
                card.textBox.Clear();
            }
        }
        void ThongTinLT(LoaiThue lt,DateTime date, string noidk,string cccdcb)
        {
            List<Object> lst = new List<Object>()
            {
                lt.Maloaithue, lt.Tenloaithue,lt.Mucthue
            };
            List<InfoCard> infor = new List<InfoCard>
            {
                txtmalt,txtname,txtmucthue
            };
            for (int i = 0; i < lst.Count; i++) 
            {
                infor[i].textBox.Text = lst[i].ToString();
            }
            FBoTro.DisplayDate(date);
            FBoTro.CCCDCanBo.textBox.Text = cccdcb;
            FBoTro.TimKiem();
            FBoTro.noidangky.textBox.Text = noidk;
        }
        private void txtMaSoTo_KeyDown(object sender, KeyEventArgs e)
        {
            string etr = e.Key.ToString();
            if (etr == "Return")
            {
                item = new Check(txtmalt.textBox.Text);
                if (item.checkID())
                {
                    DataRow cd;
                    LoaiThue lt = new LoaiThue(Convert.ToInt32(txtmalt.textBox.Text));
                    try
                    {
                        cd = ltD.Search(lt)[0];

                    }
                    catch
                    {
                        MessageBox.Show("Khong tim thay trong co so du lieu");
                        return;
                    }
                    ThongTinLT(new LoaiThue(Convert.ToInt32(cd[0].ToString()), cd[1].ToString(), float.Parse(cd[2].ToString()), FBoTro.Date().ToString(), FBoTro.noidangky.textBox.Text, FBoTro.CCCDCanBo.textBox.Text), Convert.ToDateTime(cd[3].ToString()), cd[4].ToString(), cd[5].ToString());
                }
                else
                {
                    MessageBox.Show("Thất Bại", "Thông Báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }    
            }
        }
    }
}
