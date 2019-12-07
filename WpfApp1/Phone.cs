using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml;
using System.ComponentModel.DataAnnotations;
namespace WpfApp1
{
    class Phone
    {
        [StringLength(128,MinimumLength =6)]
        public string Name { get; set; }
        [Required]
        public uint Count { get; set; }
        [Range(1,20)]
        public uint Cost { get; set; }

        public string Image { get; set; }
        public Phone()
        {
            Image = null;
        }

        public Phone(XmlElement node)
        {
            Name = node.GetAttribute("Name");
            Count = uint.Parse(node.GetAttribute("Count"));
            Cost = uint.Parse(node.GetAttribute("Cost"));
            Image = node.GetAttribute("Image");
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
