using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyCDTP
{
    public class KhaiSinh
    {
        private int id;
        private string hoten;
        private string gioitinh;
        private DateTime ngayThangNamSinh;
        private string dantoc;
        private string quoctich;
        private string noisinh;
        private string hotencha;
        private string dantoccha;
        private string quoctichcha;
        private string hotenme;
        private string dantocme;
        private string quoctichme;
        private string nguoidangky;
        private string cccdcha;
        private string cccdme;
        private DateTime ngaythangnamdk;
        private string cccdcanbo;

        public KhaiSinh(string hotencha,string dantoccha,string quoctichcha,string hotenme,string dantocme,string quoctichme)
        {
            this.hotencha=hotencha.Trim();
            this.dantoccha=dantoccha.Trim();
            this.quoctichcha=quoctichcha.Trim();
            this.hotenme=hotenme.Trim();
            this.dantocme=dantocme.Trim();
            this.quoctichme=quoctichme.Trim();
        }
        public KhaiSinh(int id, string hoten, string gioitinh, DateTime ngayThangNamSinh, 
            string dantoc, string quoctich, string noisinh, string hotencha, string dantoccha, 
            string quoctichcha, string hotenme, string dantocme, string quoctichme, string nguoidangky,
            string cccdcha,string cccdme,DateTime ngaythangnamdk,string cccdcanbo)
        {
            this.id = id;
            this.hoten = hoten.Trim();
            this.gioitinh = gioitinh.Trim();
            this.ngayThangNamSinh = ngayThangNamSinh;
            this.dantoc = dantoc.Trim();
            this.quoctich = quoctich.Trim();
            this.noisinh = noisinh.Trim();
            this.hotencha = hotencha.Trim();
            this.dantoccha = dantoccha.Trim();
            this.quoctichcha = quoctichcha.Trim();
            this.hotenme = hotenme.Trim();
            this.dantocme = dantocme.Trim();
            this.quoctichme = quoctichme.Trim();
            this.nguoidangky = nguoidangky.Trim();
            this.cccdcha = cccdcha.Trim();
            this.cccdme = cccdme.Trim();
            this.ngaythangnamdk = ngaythangnamdk;
            this.cccdcanbo = cccdcanbo.Trim();
        }
        public KhaiSinh(int id)
        {
            this.id=id;
        }
        public string Hoten { get => hoten; }
        public string Gioitinh { get => gioitinh; }
        public DateTime NgayThangNamSinh { get => ngayThangNamSinh; }
        public string Dantoc { get => dantoc; }
        public string Quoctich { get => quoctich; }
        public string Noisinh { get => noisinh; }
        public string Hotencha { get => hotencha; }
        public string Dantoccha { get => dantoccha; }
        public string Quoctichcha { get => quoctichcha; }
        public string Hotenme { get => hotenme; }
        public string Dantocme { get => dantocme; }
        public string Quoctichme { get => quoctichme; }
        public string Nguoidangky { get => nguoidangky; }
        public int Id { get => id; }
        public string CCCDCha { get => cccdcha; }
        public string CCCDMe { get => cccdme; }
        public string CCCDCanBo { get => cccdcanbo; }
        public DateTime NgayThangNamDK { get => ngaythangnamdk; }
    }
}
