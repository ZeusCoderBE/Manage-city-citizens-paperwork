using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Interop;



namespace QuanLyCDTP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FGiaoDien : Window
    {
        CongDanDAO cdD = new CongDanDAO();
        BieuDo bd = new BieuDo();
        Flichsu flichsu = new Flichsu();
        FAccount account = new FAccount();
        ThongTinCaNhan tncn = new ThongTinCaNhan();
        FDangKy dk = new FDangKy();
        DispatcherTimer timer;
        double panelWidth;
        double borWidth = 16;
        bool hidden;
        
        public FGiaoDien()
        {
            InitializeComponent();
            ThanChinh.Children.Clear();
            ThanChinh.Children.Add(tt);
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            panelWidth = sidePanel.Width;
            txb_thoat.Visibility = Visibility.Visible;
        }
        void Exit()
        {
            if (System.Windows.MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Hide();
                Flogin flogin = new Flogin();
                flogin.Show();
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                infoTP.Visibility = Visibility.Visible;
                txb_thoat.Visibility = Visibility.Visible;
                item.Visibility= Visibility.Visible;
                item1.Visibility= Visibility.Visible;
                item2.Visibility= Visibility.Visible;
                item3.Visibility = Visibility.Visible;
                item4.Visibility= Visibility.Visible;
                item5.Visibility = Visibility.Visible;
                sidePanel.Width += 10;
                borWidth -= 10;
                bor_show.Margin = new Thickness(-borWidth, 0, 0, 0);
                if (sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                infoTP.Visibility = Visibility.Hidden;
                txb_thoat.Visibility = Visibility.Hidden;
                item.Visibility = Visibility.Hidden;
                item1.Visibility = Visibility.Hidden;
                item2.Visibility = Visibility.Hidden;
                item3.Visibility = Visibility.Hidden;
                item4.Visibility = Visibility.Hidden;
                item5.Visibility = Visibility.Visible;
                sidePanel.Width -= 10;
                borWidth += 10;
                bor_show.Margin = new Thickness(-borWidth, 0, 0, 0);
                if (sidePanel.Width <= 100)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }
        private void pnlControlBar_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Exit();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void BieuDoClick(object sender, RoutedEventArgs e)
        {
            ThanChinh.Children.Clear();
            ThanChinh.Children.Add(bd);
        }
        private void ClickTracuu(object sender, RoutedEventArgs e)
        {
            ThanChinh.Children.Clear();
            ThanChinh.Children.Add(tncn);
        }
        private void ClickInfo(object sender, RoutedEventArgs e)
        {
            ThanChinh.Children.Clear();
            ThanChinh.Children.Add(flichsu);
        }

        private void ClickDangKy(object sender, RoutedEventArgs e)
        {
            ThanChinh.Children.Clear();
            ThanChinh.Children.Add(dk);
        }

        private void PanelHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btn_LogOut(object sender, RoutedEventArgs e)
        { 
            Exit();
        }

        private void Button_Click(object sender, MouseButtonEventArgs e)
        {
            timer.Start();
        }

        FTrangTru tt = new FTrangTru();
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            ThanChinh.Children.Clear();
            ThanChinh.Children.Add(tt);
        }

        private void Zoom_Click(object sender, MouseButtonEventArgs e)
        {
        }

        private void ClickAccount(object sender, RoutedEventArgs e)
        {
            ThanChinh.Children.Clear();
            ThanChinh.Children.Add(account);
        }
    }
}
