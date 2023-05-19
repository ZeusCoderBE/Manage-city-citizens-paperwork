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
    /// Interaction logic for FThueShow.xaml
    /// </summary>
    public partial class FThueShow : UserControl
    {
        public FThueShow()
        {
            InitializeComponent();
        }
        HoaDonThueDao hdtD=new HoaDonThueDao();
        
        private List<Thue> ConvertDataRowToList(DataRow dataRow)
        {
            List<Thue> items = new List<Thue>();

            foreach (DataRow row in dataRow.Table.Rows)
            {
                Thue item = new Thue(Convert.ToInt32(row[0]), row[1].ToString(),row[2].ToString(),
                            row[3].ToString(), Convert.ToInt32(row[4]), row[5].ToString(),float.Parse(row[6].ToString()),
                            Convert.ToDateTime(row[7]), float.Parse(row[8].ToString()));
                items.Add(item);
            }

            return items;
        }
        private void btnHienThi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRow hd = hdtD.TimKiem("",1)[0]; ;
                if (hd.Table.Rows.Count > 0)
                {
                    List<Thue> Items = ConvertDataRowToList(hd);
                    lvthue.ItemsSource = Items;
                }
                else
                {
                    MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }

        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DanhSach ds = new DanhSach();
                IEnumerable<Thue> thue = lvthue.ItemsSource.Cast<Thue>(); // lấy dữ liệu từ listview hiện tại
                ds.ExportToExcel(thue, "Danh Sách Quản Lý Thuế"); // xuất file excel
            }
            catch (Exception)
            {
                MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }

        private void btnsxtang_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRow dataTable = hdtD.TimKiem("",2)[0];
                if (dataTable.Table.Rows.Count > 0)
                {
                    List<Thue> items = ConvertDataRowToList(dataTable);
                    lvthue.ItemsSource = items;
                }
                else
                {
                    MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có Lỗi Khi Tải Dữ Liệu", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }

        private void btnsxgiam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRow dataTable = hdtD.TimKiem("",3)[0];
                if (dataTable.Table.Rows.Count > 0)
                {
                    List<Thue> items = ConvertDataRowToList(dataTable);
                    lvthue.ItemsSource = items;
                }
                else
                {
                    MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có Lỗi Khi Tải Dữ Liệu", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
        void FilterAdd(string fill)
        {
            try
            {
                DataRow dataTable = hdtD.TimKiem(fill,4)[0];
                if (dataTable.Table.Rows.Count > 0)
                {
                    List<Thue> items = ConvertDataRowToList(dataTable);
                    lvthue.ItemsSource = items;
                }
                else
                {
                    MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có Lỗi Khi Tải Dữ Liệu", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
        int check = 1;
        InfoCard box = new InfoCard();
        int checker = 0;
        private void btnLocDiaDiem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (check == 1)
                {
                    box.Visibility = Visibility.Visible;
                    box.hint = "Mời Bạn Nhập";
                    box.Height = 45;
                    box.Width = 150;
                    if (checker == 0)
                    {
                        hienthi.Children.Add(box);
                        checker++;
                    }
                    check = 0;
                }
                else
                {
                    FilterAdd(box.textBox.Text);
                    box.Visibility = Visibility.Hidden;
                    check = 1;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }
    }
}
