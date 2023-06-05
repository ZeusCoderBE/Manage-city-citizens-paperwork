using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.CompilerServices;

namespace QuanLyCDTP
{
    class Check
    {
        DBConnection dbC = new DBConnection();
        private string input;
        private string output;

        public string Input { get => input; set => input = value; }

        public Check()
        {

        }
        public Check(string input)
        {
            this.input= input;
        }
        public Check(string input,string output)
        {
            this.input = input;
            this.output= output;
        }
        int check = 0;
        public bool checkID()
        {
            if (int.TryParse(input, out check) == true)
            {
                return true;
            }
            return false;
        }
        public bool Checknull()
        {
            if(String.IsNullOrEmpty(input) || String.IsNullOrEmpty(output))
            {
                return true;
            }
            return false;
        }
        public bool NotContains(string info,string thuoctinh,string Bang)
        {
            try
            {
                DataRowCollection drc = dbC.ThucThi($"select {thuoctinh} from {Bang}").Rows;
                
                foreach(DataRow i in drc)
                {
                    if (info.ToString() == i[0].ToString()) return false;
                }
                
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool CheckNotNull(Object ob, List<String> ten = null)
        {
            if(ten == null)
            {
                ten=new List<String>() { "" };
            }
            var kq = ob.GetType().GetProperties()
                .Where(pi =>(pi.PropertyType == typeof(string)|| pi.PropertyType == typeof(DateTime)) && !ten.Contains(pi.Name.ToString()))
                .Select(pi => pi.GetValue(ob)==null ? "" : pi.GetValue(ob).ToString())
                .Any(value => (string.IsNullOrEmpty(value.ToString()) || value.ToString()==""));


            return !Convert.ToBoolean(kq);
        }

        public bool Tuoi(DateTime time1, DateTime time2)
        {
            TimeSpan difference = time2 - time1;
            if ((Convert.ToInt64(difference.TotalDays)/365) >= 18)
            {
                return true;
            }
            return false;
        }
    }
}
