using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ImageMagick;

namespace MetadataRemover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Metadata Remover");
            Console.WriteLine("Enter the path of the image you want to remove metadata from:");
            string imagePath = Console.ReadLine().Trim('"');
            using (MagickImage cleanImage = new MagickImage(imagePath))
            {          //save orientation if have in metadata
                var orientation = cleanImage.GetAttribute("EXIF:Orientation");
                if (orientation != null)
                {
                    cleanImage.AutoOrient();
                }
                cleanImage.Strip(); // Remove all metadata
                string cleanImagePath = Path.Combine(Path.GetDirectoryName(imagePath), "clean_" + Path.GetFileName(imagePath));
                cleanImage.Write(cleanImagePath);
            }
        }
    }
}
