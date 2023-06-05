using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
namespace QuanLyCDTP
{
    class LamSach
    {
        public LamSach() {}
        public void LamSachGiaTri(Grid gr, StackPanel sp, int select)
        {
            UIElementCollection tg = null;
            switch (select)
            {
                case 1:
                    {
                        tg = gr.Children;
                        break;
                    }
                case 2:
                    {
                        tg = sp.Children;
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            if (tg == null) return;
            foreach (UIElement element in tg)
            {
                if (element is InfoCard)
                {
                    InfoCard userControl = (InfoCard)element;
                    userControl.textBox.Clear();
                }
                if (element is StackPanel)
                {
                    StackPanel sp_t = (StackPanel)(element);
                    LamSachGiaTri(null, sp_t, 2);
                }
                if (element is Grid)
                {
                    Grid sp_t = (Grid)(element);
                    LamSachGiaTri(sp_t, null, 1);
                }
            }
        }
    }
}
