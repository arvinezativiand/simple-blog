using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeyad.CoreLayer.Utilities
{
    public class ImageValidation
    {
        public static bool Validation(string imageName)
        {
            string extension = Path.GetExtension(imageName);
            if(extension==null)
                return false;

            return extension.ToLower() == ".jpg" || extension.ToLower() == ".png";
        }
    }
}
