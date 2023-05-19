using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
namespace QuanLyCDTP
{
    public class CongDan
    {
        private string cccd;
        private string hoten;
        private DateTime ngaysinh;
        private string gioitinh;
        private string quequan;
        private string thuongtru;
        private string tamtru;
        private string dantoc;
        private string honnhan;
        private string cccdcha;
        private string cccdme;
        private float tienluong;
        private string quoctich;
        private string ngaymat;
        public CongDan(string cccd, string hoten, string gioitinh, DateTime ngaysinh, string quequan
            , string thuongtru, string tamtru, string dantoc, string honnhan, string cccdcha, string cccdme, float tienluong, string quoctich)
        {
            this.cccd = cccd.Trim();
            this.hoten = hoten.Trim();
            this.gioitinh = gioitinh.Trim();
            this.ngaysinh = ngaysinh;
            this.quequan = quequan.Trim();
            this.thuongtru = thuongtru.Trim();
            this.tamtru = tamtru.Trim();
            this.dantoc = dantoc.Trim();
            this.honnhan = honnhan.Trim();
            this.cccdcha = cccdcha.Trim();
            this.Cccdme = cccdme.Trim();
            this.tienluong = tienluong;
            this.quoctich = quoctich.Trim();
        }
        
        public CongDan(string cccd, string hoten, DateTime ngaysinh, string thuongtru)
        {
            this.cccd = cccd.Trim();
            this.hoten = hoten.Trim();
            this.ngaysinh = ngaysinh;
            this.thuongtru = thuongtru.Trim();
        }
        public CongDan(string cccd)
        {
            this.cccd = cccd;
        }
        
        public string CCCD
        {
            get => cccd;
        }

        public string DanToc
        {
            get => dantoc;
        }

        public string GioiTinh
        {
            get => gioitinh;
        }

        public string HonNhan
        {
            get => honnhan;
        }

        public string HoTen
        {
            get => hoten;
        }

        public string CccdCha
        {
            get => cccdcha;
        }


        public DateTime NgaySinh
        {
            get => ngaysinh;
        }

        public string QueQuan
        {
            get => quequan;
        }

        public string TamTru
        {
            get => tamtru;
        }

        public string ThuongTru
        {
            get => thuongtru;
        }
        public float Tienluong { get => tienluong;}
        public string Quoctich { get => quoctich; }
        public string NgayMat
        {
            get => ngaymat;
            set
            {
                ngaymat = value;
            }
        }

        public string Cccdme { get => cccdme; set => cccdme = value; }
    }
}
