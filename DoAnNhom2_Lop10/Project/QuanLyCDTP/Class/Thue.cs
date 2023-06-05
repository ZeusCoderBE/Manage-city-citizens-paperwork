using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCDTP
{
    public class Thue
    {
        private int mahd;
        private string macd;
        private string hoten;
        private string tamtru;
        private int maloaithue;
        private string tenloaithue;
        private float mucthue;
        private DateTime date;
        private float sotienthue;
        public Thue(int mahd, string macd, string hoten, string tamtru, int maloaithue, string tenloaithue,
            float mucthue, DateTime date, float sotienthue)
        {
            this.mahd = mahd;
            this.macd = macd.Trim();
            this.hoten = hoten.Trim();
            this.tamtru = tamtru.Trim();
            this.maloaithue = maloaithue;
            this.tenloaithue = tenloaithue.Trim();
            this.mucthue = mucthue;
            this.date = date;
            this.sotienthue = sotienthue;
        }
        public Thue(string tamtru)
        {
            this.tamtru=tamtru;
        }

        public int Mahd { get => mahd; }
        public string Macd { get => macd; }
        public string Hoten { get => hoten; }
        public string Tamtru { get => tamtru; }
        public int Maloaithue { get => maloaithue; }
        public string Tenloaithue { get => tenloaithue; }
        public float Mucthue { get => mucthue; }
        public DateTime Date { get => date; }
        public float Sotienthue { get => sotienthue; }
    }
}
