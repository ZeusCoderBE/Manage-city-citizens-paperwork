using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCDTP
{
    internal class HoaDonThueDao
    {
        DBConnection db = new DBConnection();
        public bool Add(HoaDonThue hdt)
        {
            string add = string.Format("Insert into HoaDonThue Values({0},'{1}',{2},'{3}',{4})"
                ,hdt.Mahoadon,hdt.Macd,hdt.Maloaithue,hdt.Ngaylaphoadon,hdt.Sotienthue);
            if (db.ThucThi(add) == null)
            {
                return false;
            }
            return true;
        }
        public bool Sua(HoaDonThue hdt)
        {
            string update = string.Format("Update HoaDonThue set MaCD='{0}',MaLoaiThue={1},NgayLapHoaDon='{2}',SoTienThue='{3}'" +
                " where MaHoaDon={4}",hdt.Macd, hdt.Maloaithue, hdt.Ngaylaphoadon, hdt.Sotienthue,hdt.Mahoadon);
            
            if (db.ThucThi(update) == null)
            {
                return false;
            }
            return true;
        }
        public DataTable Xoa(HoaDonThue hdt)
        {
            string remove = string.Format("Delete From HoaDonThue where MaHoaDon='{0}'", hdt.Mahoadon);
            return db.ThucThi(remove);
        }
        public DataRowCollection Search(HoaDonThue hdt)
        {
            string item = string.Format("Select* From HoaDonThue where MaHoaDon={0}", hdt.Mahoadon);
            return db.ThucThi(item).Rows;
        }
        public DataRowCollection CheckItem(HoaDonThue hd,int select)
        {
           if(select==1)
            {
                string item = string.Format("select MaCD,maloaithue From HoaDonThue \r\nwhere '{0}' in (select cccd From CongDan)", hd.Macd);
                return db.ThucThi(item).Rows;
            }
           else if(select==2)
            {
                string item = string.Format("select MaCD,maloaithue From HoaDonThue \r\nwhere {0} in (select maloaithue From LoaiThue)", hd.Maloaithue);
                return db.ThucThi(item).Rows;
            }
            return null;
        }
        
        public DataRowCollection TimKiem(string filter, int select)
        {
            string truyvan = $"select hd.MaHoaDon,hd.MaCD,cd.hoten,cd.tamtru  " +
                ",hd.MaLoaiThue,lt.TenLoaiThue,lt.MucThue,hd.NgayLapHoaDon,hd.SoTienThue From LoaiThue as lt , " +
                "HoaDonThue as hd,CongDan as cd where lt.MaLoaiThue=hd.MaLoaiThue " +
                "and cd.cccd=hd.MaCD ";
            switch (select)
            {
                case 1:
                    {//Hien Thi
                        break;
                    }
                case 2:
                    {//Sort AZ
                        truyvan += "order by cd.hoten";
                        break;
                    }
                case 3:
                    {//Sort ZA
                        truyvan += "order by cd.hoten desc";
                        break;
                    }
                case 4:
                    {//LocTen
                        truyvan += $"and lt.TenLoaiThue like N'%{filter}%'";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            try
            {
                return db.ThucThi(truyvan).Rows;
            }
            catch
            {

            }
            return null;

        }
    }
}

