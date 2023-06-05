using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace QuanLyCDTP
{
    class CongDanDAO
    {
        DBConnection dbc = new DBConnection();
        public CongDanDAO()
        {
            
        }
        
        public bool Them (CongDan cd)
        {
            
            string congdan = $"Insert Into CongDan(cccd,hoten,gioitinh,ngaysinh,quequan,thuongtru,tamtru,dantoc,honnhan,cccdCha,cccdMe,TienLuong,QuocTich) " +
                             $"Values('{cd.CCCD}', N'{cd.HoTen}', N'{cd.GioiTinh}', '{cd.NgaySinh}', N'{cd.QueQuan}', N'{cd.ThuongTru}', N'{cd.TamTru}', N'{cd.DanToc}', N'{cd.HonNhan}', '{cd.CccdCha}', '{cd.Cccdme}', '{cd.Tienluong}', N'{cd.Quoctich}')";
            if (dbc.ThucThi(congdan) == null)
            {
                return false;
            }
            return true;
        }

        public DataTable Xoa (CongDan cd)
        {
            string fill = string.Format("Delete From CongDan where cccd='{0}'", cd.CCCD);
            return dbc.ThucThi(fill);
        }
        public bool Sua(CongDan cd)
        {
            string congdan = string.Format("Update CongDan set hoten=N'{0}',gioitinh=N'{1}',ngaysinh=N'{2}'" +
                ",quequan=N'{3}',thuongtru=N'{4}',tamtru=N'{5}',dantoc='{6}',honnhan=N'{7}',cccdCha=N'{8}',cccdMe=N'{9}',TienLuong={10},QuocTich=N'{11}'" +
                " where cccd='{12}'"
                ,cd.HoTen,cd.GioiTinh,cd.NgaySinh,cd.QueQuan,cd.ThuongTru,cd.TamTru,cd.DanToc,cd.HonNhan,cd.CccdCha,cd.Cccdme,cd.Tienluong,cd.Quoctich,cd.CCCD);
            dbc.ThucThi(congdan);
            if (dbc.ThucThi(congdan) == null)
            {
                return false;
            }
            return true;
        }

        public DataRowCollection TimKiem(CongDan cd, string cccd, string thuoctinh, int select) // O de getvalue
        {
            string query = "";
            switch (select)
            {
                case 1:
                    {//Thuc hien cho viec chi truy van ten.
                        query = $"where cccd = '{cccd}'";
                        break;
                    }
                case 2:
                    {//Thuc hien cho viec chi truy van theo lop.
                        query = $"where cccd = '{cd.CCCD}'";
                        break;
                    }
                case 3:
                    {//Thuc hien cho viec chi truy van theo ten cha, me.
                        query = "inner join (select {thuoctinh} From CongDan where cccd='{cd.CCCD}')" +
                                    $" on  t.{thuoctinh}=cccd";
                        break;
                    }
                case 4:
                    {//Thuc hien cho viec sap xep Sort  order by hoten, order by hoten DESC
                        query = $"order by {thuoctinh}";
                        break;
                    }
                case 5:
                    {//Loc tam tru 
                        query = $"where tamtru like N'%{thuoctinh}%'";
                        break;
                    }
                case 6:
                    {//Loc dan toc
                        query = $"where dantoc like N'%{thuoctinh}%'";
                        break;
                    }
                case 7:
                    {

                        break;
                    }
                default:
                    {
                        break;
                    }

            }
            // ThucThi cau lenh
            try
            {
                return dbc.ThucThi($"select * From CongDan {query}").Rows;
            }
            catch(Exception)
            {
            }
            return null;
        }


    }


}
