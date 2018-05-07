using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNGItems
{
    public static class ImageLoader
    {
        //a class for the test class to load all images in a folder
        //each subfolder is type, the images in the subfolders are the images for the type
        public static Dictionary<string, List<Bitmap>> getTypesAndImages(string path)
        {
            Dictionary<string, List<Bitmap>> ret = new Dictionary<string, List<Bitmap>>();

            var directories = Directory.GetDirectories(path);

            foreach (string s in directories)
            {
                ret.Add(s.Substring(s.LastIndexOf('\\') + 1), new List<Bitmap>());
                foreach (string imagepath in Directory.GetFiles(s))
                    ret[s.Substring(s.LastIndexOf('\\') + 1)].Add(new Bitmap(imagepath));
            }

            return ret;
        }
    }
}
