using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace SpriteSheetEditor
{
    public class ImgInfo
    {
        public string FileName;
        public string FullPath;
        public Bitmap Img;
        public ImgInfo(string fileName, string fullPath , int _fwidth_ , int _fheight_ , int _frameCnt_ , float _playBackSpeed_)
        {
            FileName = fileName;
            FullPath = fullPath;
            FrameWidth = _fwidth_;
            FrameHeight = _fheight_;
            FrameCount = _frameCnt_;
            playbackSpeed = _playBackSpeed_;

        }
        public override string ToString()
        {
            return FileName.ToString();
        }

        private int m_FrameWidth=128;
        public int FrameWidth
        {
            get { return m_FrameWidth; }
            set
            {
                m_FrameWidth = value;
                if (m_FrameWidth < 1)
                    m_FrameWidth = 1;
            }
        }

        private int m_FrameHeight=128;
        public int FrameHeight
        {
            get { return m_FrameHeight; }
            set
            {
                m_FrameHeight = value;
                if (m_FrameHeight < 1)
                    m_FrameHeight = 1;
            }
        }
        private int m_FrameCount = 8;
        public int FrameCount
        {
            get { return m_FrameCount; }
            set
            {
                m_FrameCount = value;
                if (m_FrameCount < 1)
                    m_FrameCount = 1;
            }
        }

        private float m_playbackSpeed = 50;
        public float playbackSpeed
        {
            get { return m_playbackSpeed; }
            set
            {
                m_playbackSpeed = value;
                if (m_playbackSpeed < 0)
                    m_playbackSpeed = 0;
                if (m_playbackSpeed > 999)
                    m_playbackSpeed = 999;
            }
        }

        private Point m_Pivot = new Point(64,128);
        public Point Pivot
        {
            get { return m_Pivot; }
            set{ m_Pivot = (Point)value;}
        }

        private Color m_Color = Color.White;
        public Color color
        {
            get { return m_Color; }
            set { m_Color = (Color)value; }
        }

        private Color m_ColorVice = Color.White;
        public Color colorVice
        {
            get { return m_ColorVice; }
            set { m_ColorVice = (Color)value; }
        }
    }
}
