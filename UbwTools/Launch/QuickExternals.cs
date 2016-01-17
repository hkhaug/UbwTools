using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using UbwTools.Common.Storage;

namespace UbwTools.Launch
{
    public class QuickExternals
    {
        private readonly List<QuickExternalItem> _items = new List<QuickExternalItem>();

        public IEnumerable<QuickExternalItem> Items
        {
            get
            {
                IEnumerable<QuickExternalItem> result = _items.OrderBy(x => x.DisplayName)
                    .ThenBy(x => x.PathAndFilename);
                return result;
            }
        }

        public void Add(string pathAndFilename, Bitmap icon)
        {
            LoadAll();
            if (!Exists(pathAndFilename))
            {
                _items.Add(new QuickExternalItem {Icon = icon, PathAndFilename = pathAndFilename});
                SaveAll();
            }
        }

        public void Delete(string pathAndFilename)
        {
            LoadAll();
            QuickExternalItem item = Lookup(pathAndFilename);
            if (null != item)
            {
                while (null != item)
                {
                    _items.Remove(item);
                    item = Lookup(pathAndFilename);
                }
                SaveAll();
            }
        }

        private bool Exists(string pathAndFilename)
        {
            return null != Lookup(pathAndFilename);
        }

        private QuickExternalItem Lookup(string pathAndFilename)
        {
            foreach (QuickExternalItem item in _items)
            {
                if (item.PathAndFilename.Equals(pathAndFilename, StringComparison.InvariantCultureIgnoreCase))
                {
                    return item;
                }
            }
            return null;
        }

        public void LoadAll()
        {
            _items.Clear();
            IEnumerable<IRepBinary> binaryItems = Repository.Launch.Externals.GetBinaryItems();
            foreach (IRepBinary binaryItem in binaryItems)
            {
                Bitmap bmp;
                if ((null == binaryItem.Value) || (binaryItem.Value.Length == 0))
                {
                    bmp = null;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(binaryItem.Value);
                    bmp = new Bitmap(ms, true);
                }
                QuickExternalItem item = new QuickExternalItem {PathAndFilename = binaryItem.Name, Icon = bmp};
                _items.Add(item);
            }
        }

        private void SaveAll()
        {
            Repository.Launch.Externals.ClearAndSaveList(_items);
        }
    }
}
