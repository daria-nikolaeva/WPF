using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    class Phone
    {
        public string Name { get; set; }
        public uint Count { get; set; }
        public uint Cost { get; set; }
        public string Image { get; set; }
        public Phone()
        {
            Image = null;
        }
        public BitmapImage ImageSourse
        {
            get
            {
                if (Image == null)
                {
                    return null;
                }
                BitmapImage img = new BitmapImage();
                Uri uri = new Uri(Image, UriKind.Relative);

                img.BeginInit();
                img.UriSource = uri;
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.EndInit();

                return img;
            }
        }
    }
}
