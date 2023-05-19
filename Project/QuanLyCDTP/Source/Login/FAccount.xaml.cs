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

namespace QuanLyCDTP
{
    /// <summary>
    /// Interaction logic for FAccount.xaml
    /// </summary>
    public partial class FAccount : UserControl
    {
        public FAccount()
        {
            InitializeComponent();
        }
        //FGiaoDien fgd = new FGiaoDien();
        FinfoAcount finfo = new FinfoAcount();
        FchangePass pas = new FchangePass();
        FloginAccount login = new FloginAccount();
      
        void ChangeForm(Grid g1,UIElement FormUI)
        {
            g1.Children.Clear();
            g1.Children.Add(FormUI);
        }
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            ChangeForm(hienthi,finfo);
        }
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            ChangeForm(hienthi, pas);
        }

        private void btn_account_Click(object sender, RoutedEventArgs e)
        {
            ChangeForm(hienthi, login);
        }
    }
}
