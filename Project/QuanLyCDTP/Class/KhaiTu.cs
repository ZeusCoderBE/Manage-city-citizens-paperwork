using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCDTP
{
    class KhaiTu
    {

        private string cccd;
        private string ngaymat;
        private string nguyennhan;
        private string ngay;
        private string thang;
        private string nam;
        private string cccdnguoidangky;
        private string noidangky;
        public KhaiTu(string cccd,string ngaymat,string nguyennhan, string ngay,string thang,string nam,string cccdnguoidk,string noidangky)
        {
            this.cccd = cccd.Trim();
            this.ngaymat = ngaymat.Trim();
            this.nguyennhan = nguyennhan.Trim();
            this.ngay = ngay.Trim();
            this.thang = thang.Trim();
            this.nam = nam.Trim();
            this.cccdnguoidangky = cccdnguoidk.Trim();
            this.noidangky = noidangky.Trim();
        }
        public string Cccd
        {
            get => cccd;
        }
        public string Ngaymat
        {
            get => ngaymat;
        }
        public string Nguyennhan
        {
            get => nguyennhan;
        }
        public string Ngay
        {
            get => ngay;
        }
        public string Thang
        {
            get => thang;
        }
        public string Nam
        {
            get => nam;
        }
        public string Cccdnguoidangky
        {
            get => cccdnguoidangky;
        }
        public string NoiDangKy
        {
            get => noidangky;
        }
    }
}
