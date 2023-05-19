using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyCDTP
{
    public class TamTru
    {
        private string masoto;
        private string hoten;
        private string thuongtru;
        private string tamtru;
        private DateTime ngaysinh;
        private string cmnd;
        private string lydo;
        private string tencanbo;
        private string noidangky;
        private DateTime ngaydangky;
        private DateTime ngayketthuc;
        

        public TamTru(string masoto, string hoten, DateTime ngaysinh, string thuongtru, string tamtru, string cmnd,
            string lydo, string tencanbo,string noidangky,DateTime ngaydangky,DateTime ngayketthuc)
        {
            this.masoto = masoto.Trim();
            this.cmnd = cmnd.Trim();
            this.tamtru=tamtru.Trim();
            this.thuongtru = thuongtru.Trim();
            this.hoten = hoten.Trim();
            this.ngaysinh = ngaysinh;
            this.lydo = lydo.Trim();
            this.tencanbo = tencanbo.Trim();
            this.noidangky = noidangky.Trim();
            this.ngaydangky = ngaydangky;
            this.ngayketthuc=ngayketthuc;
        }
       
        public  TamTru(string masoto)
        {
            this.masoto = masoto;
        }
     
        public string Masoto { get => masoto; }
        public string Cmnd { get => cmnd; }
        public string Lydo { get => lydo; }
        public string Noidangky { get => noidangky; }
        public string Tencanbo { get => tencanbo; }
        public string Thuongtru { get => thuongtru; }
        public string Hoten { get => hoten; }
        public DateTime Ngaysinh { get => ngaysinh; }
        public string Tamtru { get => tamtru; }
        public DateTime Ngaydangky { get => ngaydangky; }
        public DateTime Ngayketthuc { get => ngayketthuc; }
    }
}

