using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;
namespace SpriteSheetEditor
{
    //主要就是紀錄Draw 相關的資訊
    class AnimationProperty : IDisposable
    {
        
        public bool         bPaused = false;
        public float        m_scale_ = 1.0f;
        public Texture2D    m_AnimSheet = null;
        public Vector2      m_pivot = new Vector2(64, 128);
        public Vector2      m_position = new Vector2(0, 0); //位置
        public float        m_playbackSpeed = 50;
        public int          m_FrameWidth = 128;
        public int          m_FrameHeight = 128;
        public int          m_FrameCount = 7;
        public int          m_CurrentFrame = 0;
        public Rectangle    m_DrawRect;

        public Color        m_MainColorShift; // 主套色
        //public Color        m_ViceColorShift; // 副套色

        //private float       prevStepAmount = 0.0f;


        

        // Update Related
        private Thread      PreviewThread;
        private int         DefaultFPS = 60;

        public AnimationProperty(Texture2D inTex)
        {
            m_AnimSheet = inTex;
            m_DrawRect = new Rectangle(0, 0, m_FrameWidth, m_FrameHeight);
            PreviewThread = new Thread(() => { this.update(); });
            PreviewThread.Start();
            //timer = Stopwatch.StartNew();
            
        }
        private double GetInterval()
        {
            return ((double)Stopwatch.Frequency / (DefaultFPS) * (m_playbackSpeed / 10.0));
        }
        public void update()
        {
            long ticks1 = 0;
            long ticks2 = 0;

            while (true)
            {
                double interval = GetInterval();
                Application.DoEvents();
                if (m_AnimSheet != null)
                {
                    ticks2 = Stopwatch.GetTimestamp();
                    if (ticks2 >= ticks1 + interval)
                    {
                        ticks1 = Stopwatch.GetTimestamp();
                        //Debug.WriteLine("interval = " + interval.ToString()); //  43402.8166666667
                        if (m_CurrentFrame < m_FrameCount)     // 更新FrameCount
                            m_CurrentFrame++;
                        else
                            m_CurrentFrame = 0;
                        CalculateFrame();
                        //prevTime = (float)timer.Elapsed.TotalSeconds;
                    }
                }
                Thread.Sleep(1); // Free's up the cpu
            }

        }

        //public void updateAnimation(float DeltaTime)
        //{
        //    if (!bPaused)
        //    {
        //        if (m_AnimSheet != null)
        //        {
        //            prevStepAmount+=DeltaTime;
        //            if(prevStepAmount > m_playbackSpeed/100.0f) // 更新時間到
        //            {
        //                prevStepAmount=0;
        //                if (m_CurrentFrame < m_FrameCount)     // 更新FrameCount
        //                    m_CurrentFrame++;
        //                else
        //                    m_CurrentFrame = 0;
        //                CalculateFrame();
        //            }

        //        }
        //    }
        //}
        
        public void CalculateFrame()
        {
            
            if (m_AnimSheet != null)
            {
                int _x_ = m_DrawRect.X;
                int _y_ = m_DrawRect.Y;
                int curHorIdx = m_CurrentFrame % (m_AnimSheet.Width / m_FrameWidth);
                _x_ = curHorIdx * m_FrameWidth;
                _y_ = m_FrameHeight * (m_CurrentFrame / (m_AnimSheet.Width / m_FrameWidth));
                m_DrawRect.X = _x_;
                m_DrawRect.Y = _y_;
                //Debug.WriteLine("_x_" + _x_.ToString());
            }
            
        }
        public void Dispose()
        {
            //離開線程
            if (PreviewThread != null)
                PreviewThread.Abort();
            if (m_AnimSheet!=null)
                m_AnimSheet.Dispose();   
         
        }
    }
}
