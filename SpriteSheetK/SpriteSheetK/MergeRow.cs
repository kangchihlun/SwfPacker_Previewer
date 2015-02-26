using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpriteSheetEditor
{
    public class MergeRow
    {
        public int Index;
        public List<ImgInfo> ImageInfos = new List<ImgInfo>();
        public MergeRow(int index)
        {
            Index = index;
        }
    }
}
