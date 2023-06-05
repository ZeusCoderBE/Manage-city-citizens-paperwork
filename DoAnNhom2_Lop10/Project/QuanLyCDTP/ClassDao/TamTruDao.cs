using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Controls.Primitives;

namespace QuanLyCDTP
{
    public class TamTruDao
    {
        DBConnection dB = new DBConnection();
        
        
        public bool ThemTamTru(TamTru tamtru)
        {
            string them = string.Format("insert into TamTru Values('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}','{9}','{10}')",
                tamtru.Masoto, tamtru.Hoten, tamtru.Ngaysinh, tamtru.Thuongtru, tamtru.Tamtru, tamtru.Cmnd, tamtru.Lydo, tamtru.Tencanbo,
                tamtru.Noidangky,tamtru.Ngaydangky,tamtru.Ngayketthuc);
            if (dB.ThucThi(them) == null)
            {
                return false;
            }
            return true;
        }
        public bool XoaTamTru(TamTru tamtru)
        {
            string fill = string.Format("Delete From TamTru where MaSoTo='{0}'", tamtru.Masoto);
            if (dB.ThucThi(fill) == null)
            {
                return false;
            }
            return true;
        }
        public bool AddLSTamTru(TamTru tamTru)
        {
            string fill = string.Format("Insert INTO LichSuTamTru select* FROM TamTru where MaSoTo='{0}'", tamTru.Masoto);
            if (dB.ThucThi(fill) == null)
            {
                return false;
            }
            return true;
        }
        public bool SuaTamTru(TamTru tamtru)
        {
            string thuchien = string.Format("Update TamTru set HoTen=N'{0}',NgaySinh=N'{1}',ThuongTru=N'{2}',TamTru=N'{3}'" +
                ",CMND=N'{4}',Lydo=N'{5}',TenCanBo=N'{6}',NoiDangKy='{7}',NgayDangKy='{8}',NgayKetThuc='{9}' where MaSoTo='{10}'"
               , tamtru.Hoten, tamtru.Ngaysinh, tamtru.Thuongtru, tamtru.Tamtru, tamtru.Cmnd, tamtru.Lydo,
             tamtru.Tencanbo, tamtru.Noidangky,tamtru.Ngaydangky,tamtru.Ngayketthuc, tamtru.Masoto);
            if (dB.ThucThi(thuchien) == null)
            {
                return false;
            }
            return true;

        }

        public DataRowCollection TimKiem(TamTru tamtru, string thuoctinh, int select, string bang) // O de getvalue
        {
            string query = "";
            switch (select)
            {
                case 2:
                    {//Thuc hien cho viec chi truy van theo lop.
                        query = $"where MaSoTo = '{tamtru.Masoto}'";
                        break;
                    }
                case 4:
                    {//Thuc hien cho viec sap xep Sort  order by hoten, order by hoten DESC
                        query = $"order by {thuoctinh}";
                        break;
                    }
                case 5:
                    {//LocNoiSinh
                        query = $"where tamtru like N'%{thuoctinh}%'";
                        break;
                    }
                default:
                    {
                        break;
                    }

            }
            // ThucThi cau lenh
            try
            {
                return dB.ThucThi($"select * From {bang} {query}").Rows;
            }
            catch
            {
                return null;
            }

        }
    }
}
