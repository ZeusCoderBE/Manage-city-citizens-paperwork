using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace QuanLyCDTP
{
    public class HonNhan
    {
        private string honNhanNam;
        private string cccdnam; 
        private string honNhanNu;
        private string cccdnu;
        private DateTime ngaydangky;
        private string noidangky;
        private string hotennam;
        private string hotennu;
        private DateTime ngaysinhnam;
        private DateTime ngaysinhnu;
        string quanhe;
        string quequannam;
        string quequannu;
        string cccdcanbo;
        public HonNhan(string honNhanNam, string cccdnam, string honNhanNu, string cccdnu, DateTime ngaydangky, string noidangky,string cccdcanbo)
        {
            this.honNhanNam = honNhanNam.Trim();
            this.cccdnam = cccdnam.Trim();
            this.honNhanNu = honNhanNu.Trim();
            this.cccdnu = cccdnu.Trim();
            this.ngaydangky = ngaydangky;
            this.noidangky = noidangky.Trim();
            this.cccdcanbo = cccdcanbo.Trim();
        }
        public HonNhan(string cccdnam,string cccdnu)
        {
            this.cccdnam= cccdnam.Trim();
            this.cccdnu= cccdnu.Trim();
        }
        public HonNhan(string cccdnam,string hotennam,DateTime ngaysinhnam,string quequannam,string quanhe,
            string cccdnu,string hotennu,DateTime ngaysinhnu,string quequannu, DateTime ngaydangky, string noidangky,string cccdcanbo)
        {
            this.cccdnam = cccdnam.Trim();
            this.hotennam= hotennam.Trim();
            this.ngaysinhnam= ngaysinhnam;
            this.quequannam= quequannam.Trim();
            this.quanhe = quanhe.Trim();
            this.cccdnu= cccdnu.Trim();
            this.hotennu= hotennu.Trim();
            this.ngaysinhnu= ngaysinhnu;
            this.quequannu = quequannu.Trim();
            this.ngaydangky= ngaydangky;
            this.noidangky= noidangky.Trim();
            this.cccdcanbo = cccdcanbo.Trim();
        }
        public bool checkKH()
        {
            if (String.Compare(honNhanNam, "Kết Hôn") == 0 || String.Compare(honNhanNu, "Kết Hôn") == 0)
            { 
                return false;
            }
            return true;

        }
        public bool checkLH()
        {
            if (String.Compare(honNhanNam, "Kết Hôn") == 0 && String.Compare(honNhanNu, "Kết Hôn") == 0)
            {
                return true;
            }
            return false;

        }
        public string HonNhanNam { get => honNhanNam; }
        public string Cccdnam { get => cccdnam; }
        public string HonNhanNu { get => honNhanNu; }
        public string Cccdnu { get => cccdnu; }
        public DateTime Ngaydangky { get => ngaydangky;  }
        public string Noidangky { get => noidangky;}
        public string Hotennam { get => hotennam; }
        public string Hotennu { get => hotennu; }
        public DateTime Ngaysinhnam { get => ngaysinhnam; }
        public DateTime Ngaysinhnu { get => ngaysinhnu; }
        public string Quanhe { get => quanhe; }
        public string Quequannam { get => quequannam; }
        public string Quequannu { get => quequannu; }
        public string CccdNguoiDangKy { get => cccdcanbo; }
    }
}
