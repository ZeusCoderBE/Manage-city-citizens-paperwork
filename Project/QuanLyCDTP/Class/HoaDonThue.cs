using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCDTP
{
     public class HoaDonThue
    {
        private int mahoadon;
        private string macd;
        private int maloaithue;
        private DateTime ngaylaphoadon;
        private  float sotienthue;
        public int Mahoadon { get => mahoadon;}
        public string Macd { get => macd;}
        public int Maloaithue { get => maloaithue; }
        public DateTime Ngaylaphoadon { get => ngaylaphoadon; }
        public float Sotienthue { get => sotienthue; }
        public HoaDonThue(int mahoadon,string macd,int maloaithue,DateTime ngaylaphoadon,float sotienthue)
        {
            this.mahoadon = mahoadon;
            this.macd = macd.Trim();
            this.maloaithue = maloaithue;
            this.ngaylaphoadon=ngaylaphoadon;
            this.sotienthue = sotienthue;

        }
        public HoaDonThue(string macd,int maloaithue)
        {
            this.macd = macd;
            this.maloaithue = maloaithue;
        }
        public HoaDonThue(int mahoadon)
        {
            this.mahoadon=mahoadon;
        }
    }
}
