using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyCDTP
{
     public class HoChieu
    {
        private int id;
        private string sodoc;
        private DateTime ngaycap;
        private string noicap;
        private string sdt;
        private string cccd;
        

        public HoChieu(int id, string sodoc, DateTime ngaycap, string noicap, string sdt,string cccd)
        {
            this.id = id;
            this.sodoc = sodoc.Trim();
            this.ngaycap = ngaycap;
            this.noicap = noicap.Trim();
            this.sdt = sdt.Trim();
            this.cccd = cccd.Trim();

        }
        public HoChieu(int id)
        {
            this.id = id;
        }
        public HoChieu(string cccd)
        {
            this.cccd = cccd;
        }

        public int Id { get => id; }
        public string Sodoc { get => sodoc; }
        public DateTime Ngaycap { get => ngaycap; }
        public string Noicap { get => noicap; }

        public string Sdt { get => sdt; }
        public string Cccd { get => cccd;}
    }
}
