using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCDTP
{
    public class HCVaNKDiLai
    {
        private int id;
        private string sodoc;
        private DateTime ngaycap;
        private string noicap;
        private string hoten;
        private string gioitinh;
        private DateTime ngaysinh;
        private string diachi;
        private string sdt;
        private string noiden;
        private DateTime ngaydi;
        private DateTime ngayden;
        private int stt;
        private string noidangky;
        private string cccd;

        public int Id { get => id; }
        public string Sodoc { get => sodoc; }
        public DateTime Ngaycap { get => ngaycap; }
        public string Noicap { get => noicap; }
        public string Hoten { get => hoten; }
        public string Gioitinh { get => gioitinh; }
        public DateTime Ngaysinh { get => ngaysinh; }
        public string Diachi { get => diachi; }
        public string Sdt { get => sdt; }
        public string Noiden { get => noiden; }
        public DateTime Ngaydi { get => ngaydi; }
        public DateTime Ngayden { get => ngayden; }
        public int Stt { get => stt; }
        public string Noidangky { get => noidangky; }
        public string Cccd { get => cccd; }

        public HCVaNKDiLai(int stt, int id, string sodoc, DateTime ngaycap, string noicap, string hoten, string gioitinh
            , DateTime ngaysinh, string diachi, string sdt, string noiden, DateTime ngaydi, DateTime ngayden, string cccd)
        {
            this.stt = stt;
            this.id = id;
            this.sodoc = sodoc;
            this.ngaycap = ngaycap;
            this.noicap = noicap;
            this.hoten = hoten;
            this.gioitinh = gioitinh;
            this.ngaysinh = ngaysinh;
            this.diachi = diachi;
            this.sdt = sdt;
            this.noiden = noiden;
            this.ngaydi = ngaydi;
            this.ngayden = ngayden;
            this.cccd = cccd;
        }
}
}
