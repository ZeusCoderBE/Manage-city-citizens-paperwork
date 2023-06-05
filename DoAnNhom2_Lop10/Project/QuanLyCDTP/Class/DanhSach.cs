using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace QuanLyCDTP
{
    public class DanhSach
    {
        public void ExportToExcel<T>(IEnumerable<T> data, string worksheetName)
        {
            // Thiết lập bản quyền cho gói ExcelPackage.
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            // Tạo hộp thoại lưu tập tin cho người dùng chỉ định đường dẫn và tên tập tin.
            var hopThoaiLuuTepTin = new SaveFileDialog();
            hopThoaiLuuTepTin.Filter = "Tập tin Excel (*.xlsx)|*.xlsx|Tất cả các tệp (*.*)|*.*";
            hopThoaiLuuTepTin.FilterIndex = 1;
            hopThoaiLuuTepTin.RestoreDirectory = true;

            // Nếu người dùng đã chọn một tập tin để lưu.
            if (hopThoaiLuuTepTin.ShowDialog() == true)
            {
                // Lấy đường dẫn và tên tập tin từ hộp thoại lưu tập tin.
                var duongDan = hopThoaiLuuTepTin.FileName;

                // Tạo một gói ExcelPackage mới.
                using (var goiExcel = new ExcelPackage())
                {
                    // Tạo một bảng tính mới trong gói ExcelPackage.
                    var bangTinhMoi = goiExcel.Workbook.Worksheets.Add(worksheetName);

                    // Lấy thông tin các thuộc tính của kiểu T.
                    var cacThuocTinh = typeof(T).GetProperties();

                    // Lấy tên của các cột từ các thuộc tính của kiểu T.
                    var tenCot = cacThuocTinh.Select(p => p.Name).ToArray();

                    // Ghi tên các cột vào hàng đầu tiên của bảng tính.
                    for (var i = 0; i < tenCot.Length; i++)
                    {
                        bangTinhMoi.Cells[1, i + 1].Value = tenCot[i];
                    }

                    // Ghi giá trị của các thuộc tính vào các ô của bảng tính.
                    for (var i = 0; i < data.Count(); i++)
                    {
                        for (var j = 0; j < tenCot.Length; j++)
                        {
                            var giaTri = cacThuocTinh[j].GetValue(data.ElementAt(i));
                            bangTinhMoi.Cells[i + 2, j + 1].Value = giaTri;
                        }
                    }

                    // Lưu gói ExcelPackage vào tập tin đã chỉ định.
                    goiExcel.SaveAs(new FileInfo(duongDan));
                }
            }

        }

    }
}
