using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Healthcare.Common
{
    public class Background
    {
        public static ImageBrush GetBackgroundBrush(string imgName)
        {
            BitmapImage bi01 = new BitmapImage(new Uri(string.Format("img/{0}", imgName), UriKind.Relative));
            ImageBrush ib01 = new ImageBrush();
            ib01.ImageSource = bi01;
            ib01.Opacity = 10;
            return ib01;
        }
        public static ImageBrush GetBackgroundBrush()
        {
            BitmapImage bi01 = new BitmapImage(new Uri(string.Format("img/{0}", "bg1.png"), UriKind.Relative));
            ImageBrush ib01 = new ImageBrush();
            ib01.ImageSource = bi01;
            ib01.Opacity = 10;
            return ib01;
        }

    }
}
