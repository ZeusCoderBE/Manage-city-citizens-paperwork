using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCDTP
{
   public class LoaiThue
    {
        private int maloaithue;
        private string tenloaithue;
        private float mucthue;
        private DateTime date;
        private string noidangky;
        private string cccddangky;
        public int Maloaithue { get => maloaithue;}
        public string Tenloaithue { get => tenloaithue; }
        public float Mucthue { get => mucthue; }
        public string NoiDangKy { get => noidangky; }
        public DateTime Date { get => date; }
        public string CCCDDangKy { get => cccddangky; }
        public LoaiThue(int maloaithue,string tenloaithue,float mucthue,string date,string noidangky,string cccddangky)
        {
            this.maloaithue= maloaithue;
            this.tenloaithue=tenloaithue.Trim();
            this.mucthue= mucthue;
            this.noidangky = noidangky.Trim();
            this.cccddangky = cccddangky.Trim();
            this.date = Convert.ToDateTime(date);
        }
        public LoaiThue(int maloaithue)
        {
            this.maloaithue = maloaithue;    
        }

    }
}
