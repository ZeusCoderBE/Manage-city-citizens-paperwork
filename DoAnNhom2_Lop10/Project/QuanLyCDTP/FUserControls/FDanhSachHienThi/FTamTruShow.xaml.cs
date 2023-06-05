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
    /// Interaction logic for FTamTruShow.xaml
    /// </summary>
    public partial class FTamTruShow : UserControl
    {
        public FTamTruShow()
        {
            InitializeComponent();
        }
        TamTruDao ttD = new TamTruDao();
        private List<TamTru> ConvertDataRowToList(DataRow dataRow)
        {
            List<TamTru> items = new List<TamTru>();

            foreach (DataRow row in dataRow.Table.Rows)
            {
                 TamTru item = new TamTru(row[0].ToString(), row[1].ToString(),
                            Convert.ToDateTime(row[2].ToString()).Date,
                            row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(),
                            row[7].ToString(), row[8].ToString(), Convert.ToDateTime(row[9]).Date, Convert.ToDateTime(row[10]).Date);
                items.Add(item);
            }

            return items;
        }
        void SortAZ()
        {
            try
            {
                DataRow dataTable = ttD.TimKiem(null,"hoten",4,"tamtru")[0];
                if (dataTable.Table.Rows.Count > 0)
                {
                    List<TamTru> items = ConvertDataRowToList(dataTable);
                    lvTamTru.ItemsSource = items;
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
        void SortZA()
        {
            try
            {
                DataRow dataTable = ttD.TimKiem(null, "hoten DESC", 4, "TamTru")[0];
                if (dataTable.Table.Rows.Count > 0)
                {
                    List<TamTru> items = ConvertDataRowToList(dataTable);
                    lvTamTru.ItemsSource = items;
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
                DataRow dataTable = ttD.TimKiem(null,fill,5, "TamTru")[0];
                if (dataTable.Table.Rows.Count > 0)
                {
                    List<TamTru> items = ConvertDataRowToList(dataTable);
                    lvTamTru.ItemsSource = items;
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

        private void btnsxgiam_Click(object sender, RoutedEventArgs e)
        {
            SortZA();
        }

        private void btnsxtang_Click(object sender, RoutedEventArgs e)
        {
            SortAZ();
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DanhSach ds = new DanhSach();
                IEnumerable<TamTru> congDans = lvTamTru.ItemsSource.Cast<TamTru>(); // lấy dữ liệu từ listview hiện tại
                ds.ExportToExcel(congDans, "Danh Sách Tạm Trú"); // xuất file excel
            }
            catch (Exception)
            {
                MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRow dataTable = ttD.TimKiem(null, "", 0, "TamTru")[0];
                if (dataTable.Table.Rows.Count > 0)
                {
                    List<TamTru> items = ConvertDataRowToList(dataTable);
                    lvTamTru.ItemsSource = items;
                }
                else
                {
                    MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có Lỗi Xảy Ra Khi Tải Dữ Liệu", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
    }
    }
