using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using System.Data.SqlTypes;

namespace QuanLyCDTP
{
    class DBConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr2);
        public DBConnection()
        {

        }
        
        public DataTable ThucThi(string thucthi)
        {
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(thucthi, conn);
                DataTable dtSinhVien = new DataTable();
                adapter.Fill(dtSinhVien);
                return dtSinhVien;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public string Practice(string practice)
        {
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(practice, conn);
                SqlDataReader sqlData = sqlCommand.ExecuteReader();
                if (sqlData.Read() == true)
                {
                    return "Dung";
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable AddList(string sql)
        {
            try
            {
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
                DataTable DSHocSinh = new DataTable();
                sqlDataAdapter.Fill(DSHocSinh);
                return DSHocSinh;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        

    }
}
