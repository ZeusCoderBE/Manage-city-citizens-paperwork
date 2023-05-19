using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyCDTP
{
    class TruyVanChungDao
    {
        DBConnection dbD = new DBConnection();
        public TruyVanChungDao()
        {

        }
        public DataRowCollection GetValue(string bang, string thuoctinhgiatri, string thuoctinhdk, string giatri,int select)
        {
            string truyvan = $"select {thuoctinhgiatri} from {bang} ";
            try
            {
                switch (select)
                {
                    case 1: //Khong co dieu kien where
                        {
                            truyvan += $"{ giatri}";
                            break;
                        }
                    case 2: // Co dieu kien where
                        {
                            truyvan += $"where { thuoctinhdk} = { giatri}";
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                DataTable temp = dbD.ThucThi(truyvan);
                if (temp != null)
                {
                    return temp.Rows;
                }
                else
                {
                    return null;
                }
            }
            catch
            {

            }
            return null;
        }
    }
}
