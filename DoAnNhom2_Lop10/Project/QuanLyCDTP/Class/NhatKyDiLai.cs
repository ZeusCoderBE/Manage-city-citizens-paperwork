using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCDTP
{
    public class NhatKyDiLai
    {
        private int id;
        private string noiden;
        private DateTime ngaydi;
        private DateTime ngayden;
        private int stt;

        public int Id { get => id; set => id = value; }
        public string Noiden { get => noiden; set => noiden = value; }
        public DateTime Ngaydi { get => ngaydi; set => ngaydi = value; }
        public DateTime Ngayden { get => ngayden; set => ngayden = value; }
        public int Stt { get => stt; set => stt = value; }
        public NhatKyDiLai(int stt, int id, string noiden, DateTime ngaydi, DateTime ngayden)
        {
            this.stt = stt;
            this.id = id;
            this.noiden = noiden.Trim();
            this.ngaydi = ngaydi;
            this.ngayden = ngayden;

        }
        public NhatKyDiLai(int stt)
        {
            this.stt = stt;
        }
    }
}
