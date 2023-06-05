using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCDTP
{
     public class HonNhanDao
    {
         DBConnection dbc=new DBConnection();
        public bool ThemHN(HonNhan hn)
        {
            string insert = string.Format("insert into HonNhan(cccdNguoiChong,cccdNguoiVo,NgayDangKy,NoiDangKy,CCCDNguoiDangKy) values('{0}','{1}','{2}','{3}','{4}')", hn.Cccdnam, hn.Cccdnu, hn.Ngaydangky, hn.Noidangky,hn.CccdNguoiDangKy);
            string update1 = string.Format("update CongDan set honnhan=N'Kết Hôn' where cccd='{0}'",hn.Cccdnam);
            string update2 = string.Format("update CongDan set honnhan=N'Kết Hôn' where cccd='{0}'", hn.Cccdnu);
            if (dbc.ThucThi(insert) != null)
            {
                dbc.ThucThi(update1);
                dbc.ThucThi(update2);
                return true;
            }
            return false;
        }
        public DataRowCollection TimKiemThongTinKS(HonNhan hn,string cccdNam,string cccdNu,int select)
        {
            string honnhan = "";
            if (select == 1)
            {
                honnhan = string.Format("select cd1.hoten,cd1.dantoc,cd1.quoctich,cd2.hoten,cd2.dantoc,cd2.quoctich" +
                    " \r\nFrom (select cccdNguoiChong,cccdNguoiVo From HonNhan" +
                    " where cccdNguoiChong='{0}' and\r\ncccdNguoiVo='{1}' ) as hn,CongDan as cd1," +
                    "CongDan as cd2\r\nwhere cd1.cccd=hn.cccdNguoiChong and cd2.cccd=hn.cccdNguoiVo", hn.Cccdnam, hn.Cccdnu);
            }else if(select == 2){
                honnhan = $"select * from HonNhan where cccdNguoiChong='{cccdNam}' or cccdNguoiVo='{cccdNu}'";
            }
            return dbc.ThucThi(honnhan).Rows;
        }
        public bool XoaHN(HonNhan hn)
        {
            string delete = string.Format("Delete From HonNhan where cccdNguoiChong='{0}' and cccdNguoiVo='{1}'", hn.Cccdnam, hn.Cccdnu);
            string update1 = string.Format("update CongDan set honnhan=N'Độc Thân' where cccd='{0}'", hn.Cccdnam);
            string update2 = string.Format("update CongDan set honnhan=N'Độc Thân' where cccd='{0}'", hn.Cccdnu);
            if (dbc.ThucThi(delete) != null)
            {
                dbc.ThucThi(update1);
                dbc.ThucThi(update2);
                return true;
            }
            return false;
        }
        public DataRowCollection GetValuesHN()
        {
            return dbc.ThucThi("select hn.cccdNguoiChong,cd1.hoten,cd1.ngaysinh,cd1.quequan,cd1.honnhan ,hn.cccdNguoiVo,cd2.hoten,cd2.ngaysinh,cd2.quequan,hn.NgayDangKy,hn.NoiDangKy,hn.CCCDNguoiDangKy From CongDan as cd1,CongDan as cd2,HonNhan as hn\r\nwhere hn.cccdNguoiChong=cd1.cccd and hn.cccdNguoiVo=cd2.cccd").Rows;
        }
    }
}
