using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using UbwTools.Common.Storage;

namespace UbwTools.Launch
{
    public class QuickExternalItem : IRepBinary
    {
        public string PathAndFilename { get; set; }
        public Bitmap Icon { get; set; }

        public string Name
        {
            get { return PathAndFilename; }
        }

        public byte[] Value
        {
            get
            {
                if (null == Icon)
                {
                    return null;
                }
                MemoryStream ms = new MemoryStream();
                Icon.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public string DisplayName
        {
            get { return Path.GetFileNameWithoutExtension(PathAndFilename); }
        }
    }
}
