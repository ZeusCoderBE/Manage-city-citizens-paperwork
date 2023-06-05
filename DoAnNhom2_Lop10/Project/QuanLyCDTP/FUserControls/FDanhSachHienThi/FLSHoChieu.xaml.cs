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
    /// Interaction logic for FLSHoChieu.xaml
    /// </summary>
    public partial class FLSHoChieu : UserControl
    {
        public FLSHoChieu()
        {
            InitializeComponent();
        }
        HoChieuDao hcD=new HoChieuDao();
        private List<HCVaNKDiLai> ConvertDataRowToList(DataRow dataRow)
        {
            List<HCVaNKDiLai> items = new List<HCVaNKDiLai>();

            foreach (DataRow row in dataRow.Table.Rows)
            {
                HCVaNKDiLai item = new HCVaNKDiLai(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), row[2].ToString(), Convert.ToDateTime(row[3]),
                            row[4].ToString(), row[5].ToString(), row[6].ToString(), Convert.ToDateTime(row[7]).Date,
                            row[8].ToString(), row[9].ToString(), row[10].ToString(), Convert.ToDateTime(row[11]).Date,
                            Convert.ToDateTime(row[12].ToString()).Date, row[13].ToString());
                items.Add(item);
            }

            return items;
        }
        private void btnHienThi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRow cd = hcD.TimKiem("",1)[0];
                if (cd.Table.Rows.Count > 0)
                {
                    List<HCVaNKDiLai> Items = ConvertDataRowToList(cd);

                    lvlsdilai.ItemsSource = Items;
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
                IEnumerable<HoChieu> hochieu = lvlsdilai.ItemsSource.Cast<HoChieu>(); // lấy dữ liệu từ listview hiện tại
                ds.ExportToExcel(hochieu, "Danh Sách  Hộ Chiếu"); // xuất file excel
            }
            catch (Exception)
            {
                MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
        void FillterAdd(string fill)
        {
            try
            {
                DataRow dataTable = hcD.TimKiem(fill,4)[0];
                if (dataTable.Table.Rows.Count > 0)
                {
                    List<HCVaNKDiLai> items = ConvertDataRowToList(dataTable);
                    lvlsdilai.ItemsSource = items;
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

        private void btnsxtang_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRow datatable = hcD.TimKiem("",2)[0];
                if (datatable.Table.Rows.Count>0)
                {
                    List<HCVaNKDiLai> lhc=ConvertDataRowToList(datatable);
                    lvlsdilai.ItemsSource = lhc;
                }   
                else
                {
                    MessageBox.Show("Danh Sách Không Có Người Nào ", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }    

            }
            catch( Exception )
            {
                MessageBox.Show("Có Lỗi Khi Tải Dữ Liệu", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }

        private void btnsxgiam_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRow datatable = hcD.TimKiem("",3)[0];
                if (datatable.Table.Rows.Count > 0)
                {
                    List<HCVaNKDiLai> lhc = ConvertDataRowToList(datatable);
                    lvlsdilai.ItemsSource = lhc;
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
    }
}
