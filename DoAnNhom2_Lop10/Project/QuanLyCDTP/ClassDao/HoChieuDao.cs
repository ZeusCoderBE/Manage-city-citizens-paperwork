using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace QuanLyCDTP
{
    public  class HoChieuDao
    {
        DBConnection dB = new DBConnection();
        public DataRowCollection TimKiemHoChieu(int MaSo)
        {
            return dB.ThucThi($"select * from HoChieu where ID ='{MaSo}'").Rows;
        }
        public DataTable ThemHoChieu(HoChieu hc)
        {
            string hochieu = string.Format("insert into HoChieu(ID,SoDoc,NgayCap,NoiCap,SoDienThoai,CCCD) " +
                "Values('{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}')"
               , hc.Id, hc.Sodoc, hc.Ngaycap, hc.Noicap, hc.Sdt, hc.Cccd);
            return dB.ThucThi(hochieu);
        }
        public DataTable SuaHoChieu(HoChieu hc)
        {
            string hochieu = string.Format("Update HoChieu set SoDoc=N'{0}',NgayCap=N'{1}',NoiCap=N'{2}',SoDienThoai='{3}',CCCD='{4}' where ID='{5}'"
              , hc.Sodoc, hc.Ngaycap, hc.Noicap, hc.Sdt, hc.Cccd, hc.Id);
            return dB.ThucThi(hochieu);
        }

        public DataRowCollection LayDSHC()
        {
            return dB.ThucThi("Select*From HoChieu").Rows;
        }
        public DataTable XoaHC(HoChieu hc)
        {
            string fill = string.Format("Delete From HoChieu where ID='{0}'", hc.Id);
            return dB.ThucThi(fill);
        }
        public DataRowCollection Check(HoChieu cd, int select, NhatKyDiLai nhatky)
        {
            string check = "";
            if (select == 1)
            {
                check = string.Format("select *From HoChieu where '{0}' in (select cccd From CongDan)", cd.Cccd);
                return dB.ThucThi(check).Rows;
            }
            else if (select == 2)
            {
                check = string.Format("select id From nhatky where {0} in (select ID From HoChieu)", nhatky.Stt);
                return dB.ThucThi(check).Rows;
            }
            else
            {
                return null;
            }
        }
        public DataRowCollection TimKiem(string fillter, int select)
        {
            string truyvan = $"select nk.Stt,nk.id,hc.SoDoc,hc.NgayCap,hc.NoiCap,cd.hoten,cd.gioitinh,cd.ngaysinh,\r\n " +
                $"cd.quequan,hc.SoDienThoai,nk.noiden,nk.ngaydi,nk.ngayden,hc.CCCD From HoChieu as hc,nhatky as nk,CongDan as\r\n                cd where nk.ID=hc.ID and cd.cccd=hc.CCCD";
            switch (select)
            {
                case 1:
                    {//LayDSlsdilai
                        break;
                    }
                case 2:
                    {//SortAZ 
                        truyvan += " order by cd.hoten ";
                        break;
                    }
                case 3:
                    {//SortZA()
                        truyvan += " order by cd.hoten desc";
                        break;
                    }
                case 4:
                    {//LocTamTru
                        truyvan += $" and  hc.NoiCap like '%{fillter}%'";
                        break;
                    }
            }
            try
            {
                return dB.ThucThi(truyvan).Rows;
            }
            catch
            {

            }
            return null;
        }
    }
}
