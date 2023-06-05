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
    /// Interaction logic for KhaiSinh.xaml
    /// </summary>
    public partial class FKhaiSinh : UserControl
    {
         KhaiSinhDao ksd=new KhaiSinhDao();
        public FKhaiSinh()
        {
            InitializeComponent();
        }
        private List<KhaiSinh> ConvertDataRowToList(DataRow dataRow)
        {
            List<KhaiSinh> items = new List<KhaiSinh>();

            foreach (DataRow row in dataRow.Table.Rows)
            {
                 KhaiSinh item = new  KhaiSinh(Int32.Parse(row[0].ToString()), row[1].ToString(), row[2].ToString(),
                            Convert.ToDateTime(row[3]).Date, row[4].ToString(), row[5].ToString(), row[6].ToString(),
                            row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString(),
                            row[11].ToString(), row[12].ToString(), row[13].ToString(), row[14].ToString(), row[15].ToString(), Convert.ToDateTime(row[16].ToString()), row[17].ToString());
               items.Add(item);
            }
            return items;
        }
        private void btnHienThi_Click(object sender, RoutedEventArgs e)
        {
            DataRow cd = ksd.TimKiem(null,"","",0)[0];
            try
            {
                if (cd.Table.Rows.Count > 0)
                {
                    List<KhaiSinh> Items = ConvertDataRowToList(cd);
                    lvKhaiSinh.ItemsSource = Items;
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
                IEnumerable<KhaiSinh> khaisinh = lvKhaiSinh.ItemsSource.Cast<KhaiSinh>(); // lấy dữ liệu từ listview hiện tại
                ds.ExportToExcel(khaisinh, "Danh Sách Khai Sinh"); // xuất file excel
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
                DataRow datatable = ksd.TimKiem(null,"", "HovaTen",4)[0];
                if (datatable.Table.Rows.Count > 0)
                {
                    List<KhaiSinh> lhc = ConvertDataRowToList(datatable);
                    lvKhaiSinh.ItemsSource = lhc;
                }
                else
                {
                    MessageBox.Show("Danh Sách Không Có Người Nào ", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
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
                DataRow datatable = ksd.TimKiem(null, "", "HovaTen Desc", 4)[0];
                if (datatable.Table.Rows.Count > 0)
                {
                    List<KhaiSinh> lhc = ConvertDataRowToList(datatable);
                    lvKhaiSinh.ItemsSource = lhc;
                }
                else
                {
                    MessageBox.Show("Danh Sách Không Có Người Nào ", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Có Lỗi Khi Tải Dữ Liệu", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
        void FillterAdd(string filter)
        {
            try
            {
                DataRow dataTable = ksd.TimKiem(null,"",filter,5)[0];
                if (dataTable.Table.Rows.Count > 0)
                {
                    List<KhaiSinh> items = ConvertDataRowToList(dataTable);
                    lvKhaiSinh.ItemsSource = items;
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
                    FillterAdd(box.textBox.Text);
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
