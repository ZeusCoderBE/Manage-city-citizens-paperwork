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
    public partial class FHoKhauShow : UserControl
    {
        public FHoKhauShow()
        {
            InitializeComponent();
        }
        SoHoKhauDao hkD=new SoHoKhauDao();
        private List<SoHoKhau> ConvertDataRowToList(DataRowCollection dataRow)
        {
            List<SoHoKhau> items = new List<SoHoKhau>();

            foreach (DataRow row in dataRow)
            {
                SoHoKhau item = new SoHoKhau(row[0].ToString(), Convert.ToInt32(row[1]), row[2].ToString(),
                            Convert.ToInt32(row[3]), Convert.ToInt32(row[4]), Convert.ToInt32(row[5]), Convert.ToInt32(row[6]),
                            Convert.ToInt32(row[7]), row[8].ToString(), row[9].ToString(),row[10].ToString());
                items.Add(item);
            }

            return items;
        }
        private void btnHienThi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowCollection cd = hkD.TimKiem("","",3);
                if (cd.Count > 0)
                {
                    List<SoHoKhau> Items = ConvertDataRowToList(cd);
                    lvsohokhau.ItemsSource = Items;
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
                IEnumerable<SoHoKhau> hochieu = lvsohokhau.ItemsSource.Cast<SoHoKhau>(); // lấy dữ liệu từ listview hiện tại
                ds.ExportToExcel(hochieu, "Danh Sách  Hộ Chiếu"); // xuất file excel
            }
            catch (Exception)
            {
                MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
    }
}
