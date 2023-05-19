using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyCDTP
{
    class KhaiTuDAO
    {
        DBConnection dbc = new DBConnection();
        public KhaiTuDAO()
        {

        }
        public bool Add(KhaiTu shk)
        {
            if (dbc.ThucThi($"insert into CongDanTu(cccd,ngaymat,nguyennhan,ngaydk,thangdk,namdk,cccdCanbo,NoiDangKy) " +
                $"values('{shk.Cccd}', '{shk.Ngaymat}', '{shk.Nguyennhan}', '{shk.Ngay}', '{shk.Thang}', '{shk.Nam}', '{shk.Cccdnguoidangky}','{shk.NoiDangKy}')") != null)
            {
                return true;
            }
            return false;
        }
        public DataRowCollection TimKiem(KhaiTu shk,string cccd,int select)
        {
            try
            {
                string query = "";
                switch (select)
                {
                    case 1://Tim kiem dua vao chuoi
                        {
                            query = $"where cccd='{cccd}'";
                            break;
                        }
                    case 2://Tim kiem dua vao lop
                        {
                            query = $"where cccd='{shk.Cccd}'";
                            break;
                        }
                }
                return dbc.ThucThi($"select * from CongDanTu {query}").Rows;
            }
            catch
            {

            }
            return null;
        }
    }
}
