using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace QuanLyCDTP
{
     public  class LoaiThueDao
    {
        DBConnection db = new DBConnection();
        public bool Add(LoaiThue lt)
        {
            string add = string.Format("Insert into LoaiThue(MaLoaiThue,TenLoaiThue,MucThue, NgayThangNamDK, NoiDangKy, CCCDcanbo) Values('{0}',N'{1}','{2}',N'{3}',N'{4}',N'{5}')", 
                lt.Maloaithue,lt.Tenloaithue,lt.Mucthue,lt.Date,lt.NoiDangKy,lt.CCCDDangKy );
            if (db.ThucThi(add) == null)
            {
                return false;
            }
            return true;
        }
        public bool Sua(LoaiThue lt)
        {
            string update= string.Format("Update LoaiThue set TenLoaiThue=N'{0}',MucThue='{1}',NgayThangNamDK='{2}', NoiDangKy='{3}', CCCDcanbo='{4}' where MaLoaiThue='{2}' ", lt.Tenloaithue,lt.Mucthue,lt.Maloaithue, lt.Date, lt.NoiDangKy, lt.CCCDDangKy);
            if (db.ThucThi(update) == null)
            {
                return false;
            }
            return true;
        }
        public DataTable Xoa(LoaiThue lt) 
        {
            string remove = string.Format("Delete From LoaiThue where MaLoaiThue='{0}'", lt.Maloaithue);
            return db.ThucThi(remove);
        }
        public DataRowCollection Search (LoaiThue lt)
        {
            string item = string.Format("select *From LoaiThue where MaloaiThue={0}", lt.Maloaithue);
            return db.ThucThi(item).Rows;
        }
        public DataRowCollection TimKiemMucthue(LoaiThue lt)
        {
            string item = string.Format("select MucThue From LoaiThue where MaloaiThue={0}", lt.Maloaithue);
            return db.ThucThi(item).Rows;
        }
    }
}
