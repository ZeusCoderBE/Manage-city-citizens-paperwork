using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCDTP
{
    public class NhatKyDao
    {
        DBConnection dB = new DBConnection();
        public DataTable ThemLT(NhatKyDiLai nk)
        {
            string hochieu = string.Format("Insert into NhatKy values ({0},{1},N'{2}',N'{3}','{4}')",
               nk.Stt, nk.Id, nk.Noiden, nk.Ngaydi, nk.Ngayden);
            return dB.ThucThi(hochieu);
        }
        public DataTable XoaLT(NhatKyDiLai hc)
        {
            string hochieu = string.Format("delete From nhatky where Stt={0}", hc.Stt);
            return dB.ThucThi(hochieu);
        }
        public DataTable SuaLT(NhatKyDiLai hc)
        {
            string hochieu = string.Format("Update NhatKy set ID={0},noiden=N'{1}',ngaydi='{2}',ngayden='{3}' where Stt={4}"
                , hc.Id, hc.Noiden, hc.Ngaydi, hc.Ngayden, hc.Stt);
            return dB.ThucThi(hochieu);
        }
        public DataRowCollection TimKiemLS(NhatKyDiLai MaSo)
        {
            return dB.ThucThi($"select * from nhatky where Stt ={MaSo.Stt}").Rows;
        }
    }
}
