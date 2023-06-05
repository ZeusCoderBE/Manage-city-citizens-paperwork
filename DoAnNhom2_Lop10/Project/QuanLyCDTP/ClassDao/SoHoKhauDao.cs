using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyCDTP
{
    class SoHoKhauDao
    {
        DBConnection dbc = new DBConnection();
        public SoHoKhauDao()
        {

        }
        public DataRowCollection TimKiem(string MsHoKhau,string cccd,int select)
        {
            if(select == 1)
            {
                //Danh cho nhung nguoi khong co giay khai sinh
                return dbc.ThucThi($"select MsHoKhau, k.hotendk,quequan,Ngay,Thang,Nam,CCCDNguoiDangKy,hoten as TruongCongAn,SoDangKy,k.dantoc,k.QuocTich,ngaysinh,k.gioitinh,DatO,NoiDangKy from SoHoKhau "
                                + $"join(select cccd, hoten from CongDan) c on SoHoKhau.CCCDNguoiDangKy = c.cccd "
                                + $"join(select cccd, hoten as hotendk, quequan, dantoc, ngaysinh, gioitinh, QuocTich from CongDan) k on SoHoKhau.cccd = k.cccd "
                                + $"where SoHoKhau.MsHoKhau = '{MsHoKhau}' "
                                + $"union "
                                + $"select MsHoKhau, HovaTen, NoiSinh, Ngay, Thang, Nam, NguoiDangKy, hoten as TruongCongAn, SoDangKy, DanToc, QuocTich, NgayThangNamSinh, GioiTinh, DatO ,SoHoKhau.NoiDangKy as NoiDangKy from SoHoKhau "
                                + $"join (select *from KhaiSinh) t on SoHoKhau.MaSoTo = t.MaSoTo "
                                + $"join(select cccd, hoten from CongDan) c on SoHoKhau.CCCDNguoiDangKy = c.cccd "
                                + $"where SoHoKhau.MsHoKhau = '{MsHoKhau}'").Rows;

            }else if (select == 2)
            {
                return dbc.ThucThi($"select t.MsHoKhau,c.hoten,ngaysinh,gioitinh,quequan,dantoc,thuongtru,QuocTich,t.Ngay,t.Thang,t.Nam,t.CCCDNguoiDangKy,NoiDangKy as CanBo from CongDan c " +
                                   $"join(select * from SoHoKhau where cccd = '{cccd}') t " +
                                   $"on t.cccd = c.cccd " +
                                   $"join(select cccd, hoten from CongDan) k " +
                                   $"on k.cccd = t.CCCDNguoiDangKy").Rows;
            }else if (select == 3)
            {
                return dbc.ThucThi($" select * from SoHoKhau ").Rows;
            }
            return null;
        }
        
        public bool Them(SoHoKhau shk)
        {
            if (dbc.ThucThi($"insert into SoHoKhau(MsHoKhau,MaSoTo,cccd,DoUuTien,Ngay,Thang,Nam,CCCDNguoiDangKy,SoDangKy,DatO,NoiDangKy)"
                            + $" values('{shk.MsHoKhau}', {shk.MaSoTo}, '{shk.Cccd}', {shk.DoUuTien}, {shk.Ngay}, {shk.Thang}, {shk.Nam}, '{shk.CccdNguoiDangKy}', '{shk.SoDangKy}','{shk.DatO}','{shk.NoiDangKy}'); ") == null)
                return false;
            return true;
        }
        public bool Xoa(string mshk, string cccd)
        {
            if (dbc.ThucThi($"delete from SoHoKhau where MsHoKhau='{mshk}' and cccd = {cccd}") == null)
                return false;
            return true;

        }
    }
}
