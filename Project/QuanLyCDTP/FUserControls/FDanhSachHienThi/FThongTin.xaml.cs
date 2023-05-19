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
using Microsoft.Win32;
using OfficeOpenXml;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using static System.Net.WebRequestMethods;

namespace QuanLyCDTP
{
    /// <summary>
    /// Interaction logic for FThongTin.xaml
    /// </summary>
    public partial class FThongTin : UserControl
    {
        public FThongTin()
        {
            InitializeComponent();
        }
        CongDanDAO cdD = new CongDanDAO();
        private List<CongDan> ConvertDataRowToList(DataRow dataRow)
        {
            List<CongDan> items = new List<CongDan>();

            foreach (DataRow row in dataRow.Table.Rows)
            {
                CongDan item = new CongDan(row[0].ToString(), row[1].ToString(), row[2].ToString(),
                    Convert.ToDateTime(row[3]), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString()
                    , row[8].ToString(), row[9].ToString(), row[10].ToString(), float.Parse(row[11].ToString()), row[12].ToString());
                items.Add(item);
            }

            return items;
        }
        void FillterAdd(string fill)
        {
            try
            {
                DataRow dataTable = cdD.TimKiem(null,"",fill,5)[0];
                if (dataTable.Table.Rows.Count > 0)
                {
                    List<CongDan> items = ConvertDataRowToList(dataTable);
                    lvUser.ItemsSource = items;
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
        void FillterDanToc (string fill)
        {
            try
            {
                DataRow dataTable = cdD.TimKiem(null,"",fill,6)[0];
                if (dataTable.Table.Rows.Count > 0)
                {
                    List<CongDan> items = ConvertDataRowToList(dataTable);
                    lvUser.ItemsSource = items;
                }
                else
                {
                    MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            catch(Exception) 
            {
                MessageBox.Show("Có Lỗi Khi Tải Dữ Liệu", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
        void SortAZ()
        {
            try
            {
                DataRow dataTable = cdD.TimKiem(null,"", "hoten", 4)[0];
                if (dataTable.Table.Rows.Count > 0)
                {
                    List<CongDan> items = ConvertDataRowToList(dataTable);
                    lvUser.ItemsSource = items;
                }
                else
                {
                    MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            catch( Exception)
            {
                MessageBox.Show("Có Lỗi Khi Tải Dữ Liệu", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
        void SortZA()
        {
            try
            {
                DataRow dataTable = cdD.TimKiem(null, "", "hoten DESC", 4)[0];
                if (dataTable.Table.Rows.Count > 0)
                {
                    List<CongDan> items = ConvertDataRowToList(dataTable);
                    lvUser.ItemsSource = items;
                }
                else
                {
                    MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            catch(Exception ) 
            {
                MessageBox.Show("Có Lỗi Khi Tải Dữ Liệu", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
        void LoadData()
        {
            try
            {
                DataRow dataTable = cdD.TimKiem(null,"","",0)[0];
                if (dataTable.Table.Rows.Count > 0)
                {
                    List<CongDan> items = ConvertDataRowToList(dataTable);
                    lvUser.ItemsSource = items;
                }
                else
                {
                    MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
            }
            catch (Exception ) 
            {
                MessageBox.Show("Có Lỗi Xảy Ra", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }
        private void btnHienThi_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
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
            catch (Exception )
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DanhSach ds = new DanhSach();
                IEnumerable<CongDan> congDans = lvUser.ItemsSource.Cast<CongDan>(); // lấy dữ liệu từ listview hiện tại
                ds.ExportToExcel(congDans, "Danh Sách Công Dân"); // xuất file excel
            }
            catch (Exception)
            {
                MessageBox.Show("Danh sach khong co nguoi nao", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            }
        }

        private void btnLocDanToc_Click(object sender, RoutedEventArgs e)
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
                    FillterDanToc(box.textBox.Text);
                    box.Visibility = Visibility.Hidden;
                    check = 1;
                }

            }
            catch (Exception )
            {
                MessageBox.Show("Không Tìm Thấy");
            }
        }

        private void btnsxtang_Click(object sender, RoutedEventArgs e)
        {
            SortAZ();
        }

        private void btnsxgiam_Click(object sender, RoutedEventArgs e)
        {
            SortZA();
        }
    }
    }

