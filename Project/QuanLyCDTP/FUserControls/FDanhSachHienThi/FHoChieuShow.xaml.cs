using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace QuanLyCDTP
{
    /// <summary>
    /// Interaction logic for FHoChieuShow.xaml
    /// </summary>
    public partial class FHoChieuShow : UserControl
    {
        public FHoChieuShow()
        {
            InitializeComponent();
        }
        HoChieuDao hcD=new HoChieuDao();
        private List<HoChieu> ConvertDataRowToList(DataRow dataRow)
        {
            List<HoChieu> items = new List<HoChieu>();

            foreach (DataRow row in dataRow.Table.Rows)
            {
                HoChieu item = new HoChieu(Convert.ToInt32(row[0]), row[1].ToString(), Convert.ToDateTime(row[2]),
                            row[3].ToString(), row[4].ToString(), row[5].ToString());
                items.Add(item);
            }

            return items;
        }
        private void btnHienThi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRow cd = hcD.LayDSHC()[0]; ;
                if (cd.Table.Rows.Count > 0)
                {
                    List<HoChieu> Items = ConvertDataRowToList(cd);
                    lvhochieu.ItemsSource = Items;
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
                IEnumerable<HoChieu> hochieu = lvhochieu.ItemsSource.Cast<HoChieu>(); // lấy dữ liệu từ listview hiện tại
                ds.ExportToExcel(hochieu, "Danh Sách  Hộ Chiếu"); // xuất file excel
            }
            catch (Exception)
            {
                MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
    }
}
