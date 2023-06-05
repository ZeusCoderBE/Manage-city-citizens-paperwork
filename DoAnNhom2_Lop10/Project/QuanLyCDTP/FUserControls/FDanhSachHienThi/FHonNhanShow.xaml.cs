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
    public partial class FHonNhanShow : UserControl
    {
        public FHonNhanShow()
        {
            InitializeComponent();
        }
        HonNhanDao cdD=new HonNhanDao();
        private List<HonNhan> ConvertDataRowToList(DataRow dataRow)
        {
            List<HonNhan> items = new List<HonNhan>();

            foreach (DataRow row in dataRow.Table.Rows)
            {
                HonNhan item = new HonNhan(row[0].ToString(), row[1].ToString(), Convert.ToDateTime(row[2].ToString()), row[3].ToString(), row[4].ToString(), row[5].ToString()
                            , row[6].ToString(),Convert.ToDateTime( row[7].ToString()), row[8].ToString(), Convert.ToDateTime(row[9].ToString()), row[10].ToString(),row[11].ToString());
                items.Add(item);    
            }
            return items;
        }
        void LoadDataHN()
        {
            try
            {
                DataRow cd= cdD.GetValuesHN()[0];
                if (cd.Table.Rows.Count > 0)
                {                 
                    List<HonNhan> Items = ConvertDataRowToList(cd);
                    lvHonNhan.ItemsSource = Items;
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
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadDataHN();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DanhSach ds = new DanhSach();
                IEnumerable<HonNhan> honnhan = lvHonNhan.ItemsSource.Cast<HonNhan>(); // lấy dữ liệu từ listview hiện tại
                ds.ExportToExcel(honnhan, "Danh Sách Kết Hôn"); // xuất file excel
            }
            catch (Exception)
            {
                MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
    }
}
