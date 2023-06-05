using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCDTP
{
    
     public class KhaiSinhDao
    {
        DBConnection dB = new DBConnection();
        
        public bool ThemKhaiSinh(KhaiSinh ks)
        {
            string khaisinh = string.Format("insert into KhaiSinh(MaSoTo,HovaTen,GioiTinh,NgayThangNamSinh,DanToc,QuocTich,NoiSinh,HoTenCha,DanTocCha,QuocTichCha,HoTenMe,DanTocMe,QuocTichMe,NguoiDangKy,CCCDCha,CCCDMe,NgayThangNamDK,cccdCanBo)" +
                "Values('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',N'{9}',N'{10}',N'{11}',N'{12}',N'{13}',N'{14}',N'{15}',N'{16}',N'{17}')"
               , ks.Id, ks.Hoten, ks.Gioitinh, ks.NgayThangNamSinh, ks.Dantoc, ks.Quoctich,
             ks.Noisinh, ks.Hotencha, ks.Dantoccha, ks.Quoctichcha, ks.Hotenme, ks.Dantocme, ks.Quoctichme, ks.Nguoidangky,ks.CCCDCha,ks.CCCDMe,ks.NgayThangNamDK,ks.CCCDCanBo);
            if (dB.ThucThi(khaisinh) == null)
            {
                return false;
            }
            return true;
        }
        public bool SuaKhaiSinh(KhaiSinh ks)
        {
            string khaisinh = string.Format("Update KhaiSinh set HovaTen=N'{0}',GioiTinh=N'{1}',NgayThangNamSinh=N'{2}',DanToc=N'{3}'" +
                ",QuocTich=N'{4}',NoiSinh=N'{5}',HoTenCha=N'{6}',DanTocCha='{7}',QuocTichCha=N'{8}',HoTenMe=N'{9}',DanTocMe=N'{10}',QuocTichMe=N'{11}',NguoiDangKy=N'{12}',CCCDCha=N'{13}',CCCDMe=N'{14}',NgayThangNamDK=N'{15}', cccdCanBo=N'{16}'" +
                " where masoto='{17}'",
               ks.Hoten, ks.Gioitinh, ks.NgayThangNamSinh, ks.Dantoc, ks.Quoctich,
             ks.Noisinh, ks.Hotencha, ks.Dantoccha, ks.Quoctichcha, ks.Hotenme, ks.Dantocme, ks.Quoctichme, ks.CCCDCanBo, ks.CCCDCha, ks.CCCDMe, ks.NgayThangNamDK, ks.CCCDCanBo, ks.Id);
            if (dB.ThucThi(khaisinh) == null)
            {
                return false;
            }
            return true;
        }
        
        public DataTable XoaKS(KhaiSinh ks)
        {
            string fill = string.Format("Delete From KhaiSinh where MaSoTo='{0}'", ks.Id);
            return dB.ThucThi(fill);
        }
        
        public DataRowCollection TimKiem(KhaiSinh ks, string masoto, string thuoctinh, int select) // O de getvalue
        {
            string query = "";
            switch (select)
            {
                case 1:
                    {//Thuc hien cho viec chi truy van ten.
                        query = $"where MaSoTo = {masoto}";
                        break;
                    }
                case 2:
                    {//Thuc hien cho viec chi truy van theo lop.
                        query = $"where MaSoTo = '{ks.Id}'";
                        break;
                    }
                case 4:
                    {//Thuc hien cho viec sap xep Sort  order by hoten, order by hoten DESC
                        query = $"order by {thuoctinh}";
                        break;
                    }
                case 5:
                    {//LocNoiSinh
                        query = $"where NoiSinh like N'%{thuoctinh}%'";
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
                return dB.ThucThi($" select * From KhaiSinh {query}").Rows;

            }
            catch(Exception)
            {
            }
            return null;

        }
    }
}
