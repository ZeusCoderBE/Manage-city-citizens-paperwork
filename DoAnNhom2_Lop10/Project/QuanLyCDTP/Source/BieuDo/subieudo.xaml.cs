using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
namespace QuanLyCDTP
{
    /// <summary>
    /// Interaction logic for subieudo.xaml
    /// </summary>
    public partial class subieudo : UserControl
    {

        CongDanDAO cdD = new CongDanDAO();
        List<String> lb = new List<String>();
        List<double> gt = new List<double>();
        DataRowCollection dr;
        TruyVanChungDao tvc = new TruyVanChungDao();
        public subieudo()
        {
            InitializeComponent();
        }
        public void LayThongTin(string name, string thuoctinh, string bang)
        {
            lb.Clear();
            gt.Clear();
            try
            {
                dr = tvc.GetValue(bang, $"{thuoctinh},Count({thuoctinh})", "", $"group by {thuoctinh};", 1);

                foreach (DataRow pt in dr)
                {
                    lb.Add(pt[0].ToString());
                    gt.Add(Convert.ToDouble(pt[1]));
                }
                Value(lb, gt, name);
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu để đưa vào biểu đồ.");
            }
        }
        public void Value(List<String> ThongTinCot, List<double> GiaTriCot, string name)
        {
            TenBD.Text = name;
            TrucX.Labels = ThongTinCot;
            Cot.Values = new LiveCharts.ChartValues<double>(GiaTriCot);
            
        }
    }
}
