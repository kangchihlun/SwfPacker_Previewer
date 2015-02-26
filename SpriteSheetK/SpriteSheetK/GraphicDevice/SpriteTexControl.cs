#region File Description
//-----------------------------------------------------------------------------
// SpriteFontControl.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using StockEffects;
#endregion

namespace SpriteSheetEditor
{
    /// <summary>
    /// Example control inherits from GraphicsDeviceControl, which allows it to
    /// render using a GraphicsDevice. This control shows how to use ContentManager
    /// inside a WinForms application. It loads a SpriteFont object through the
    /// ContentManager, then uses a SpriteBatch to draw text. The control is not
    /// animated, so it only redraws itself in response to WinForms paint messages.
    /// </summary>
    class SpriteTexControl : GraphicsDeviceControl
    {
        //ContentManager content;
        public bool bEffectMode = true;
        //Stopwatch timer;
        //float prevTime;
        SpriteBatch spriteBatch;

        public AnimationProperty previewSpriteAP;
        AnimationProperty mokujinSpriteAP;
        FileStream scFS,  MokujinFS , RedCrossFS;
        Texture2D m_MokujinSpTex, m_ScBGTex ,m_RedCrossTex;

        //Content Related
        //ContentBuilder contentBuilder;
        //ContentManager contentManager;
        StockEffects.SpriteEffect _basicEffect;
        StockEffects.SpriteEffect_Colorized ColorTransformEffect;
        //private Effect ColorTransformEffect;


        // Update Related
        private Thread ReDrawThread;
        private const int DefaultFPS = 30;

        // Default Settings
        private Vector2 StandLocation = new Vector2(150, 300);

        
        /// <summary>
        /// Initializes the control, creating the ContentManager
        /// and using it to load a SpriteFont.
        /// </summary>
        protected override void Initialize()
        {
            //content = new ContentManager(Services, "Content");
           // timer = Stopwatch.StartNew();
            GraphicsDevice.BlendState = BlendState.AlphaBlend;
            GraphicsDevice.DepthStencilState = DepthStencilState.DepthRead;

            //contentBuilder = new ContentBuilder();
            //contentManager = new ContentManager(this.Services,
            //                                    contentBuilder.OutputDirectory);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            //
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string execPath = Path.GetDirectoryName(assemblyLocation);
            string scBGTex = execPath + "\\Scene_SpriteBG.png";
            string mokujunTex = execPath + "\\player_Idle.png";
            string sRedCrossTex = execPath + "\\Plus_numeric.png";
            scFS = new FileStream(scBGTex, FileMode.Open);
            MokujinFS = new FileStream(mokujunTex, FileMode.Open);
            RedCrossFS = new FileStream(sRedCrossTex, FileMode.Open);

            m_ScBGTex = Texture2D.FromStream(GraphicsDevice, scFS);
            m_MokujinSpTex = Texture2D.FromStream(GraphicsDevice, MokujinFS);
            m_RedCrossTex = Texture2D.FromStream(GraphicsDevice, RedCrossFS);

            //設定木頭人的preview (定值)
            mokujinSpriteAP = new AnimationProperty(m_MokujinSpTex);
            setupMoKuJunAP();

            //設定預覽用Sprite
            previewSpriteAP = new AnimationProperty(null);
            previewSpriteAP.m_position = StandLocation; //位置一開始是固定的
            previewSpriteAP.m_pivot = new Vector2(previewSpriteAP.m_FrameWidth / 2, previewSpriteAP.m_FrameHeight);


            _basicEffect = new StockEffects.SpriteEffect(GraphicsDevice);
            ColorTransformEffect = new StockEffects.SpriteEffect_Colorized(GraphicsDevice);
            Debug.WriteLine("ColorTransformEffect" + ColorTransformEffect.Name);

            //啟動重繪
            ReDrawThread = new Thread(() => { this.update(); });
            ReDrawThread.Start();

            //載入Shader，呼叫ContentBuilder Build shader
            //string cTmEffPath = execPath + "\\ColorTransform.fx";
            //contentBuilder.Clear();
            //contentBuilder.Add(cTmEffPath, "Shader", null, "EffectProcessor");
            //string buildError = contentBuilder.Build();
            //ColorTransformEffect = contentManager.Load<Effect>("Shader");


        }
        //木人樁的張數跟速率是寫死的
        private void setupMoKuJunAP()
        {
            mokujinSpriteAP.m_FrameWidth = 256;
            mokujinSpriteAP.m_FrameHeight = 256;
            mokujinSpriteAP.m_DrawRect = new Rectangle(0, 0, 256, 256);
            mokujinSpriteAP.m_pivot = new Vector2(mokujinSpriteAP.m_FrameWidth / 2, mokujinSpriteAP.m_FrameHeight);
            mokujinSpriteAP.m_position = StandLocation;

            //previewSpriteAP.m_pivot = new Vector2(64, 128);
            
        }
        public void setMainColorShifting(Microsoft.Xna.Framework.Color _inColor_)
        {
            //ColorTransformEffect.Parameters["ShiftedColor"].SetValue(_inColor_.ToVector4());
            ColorTransformEffect.colorshiftMain = _inColor_.ToVector4();
        }
        public void setCurPreviewSpTexture(FileStream inStream)
        {
            Texture2D m_PreviewSpTex = Texture2D.FromStream(GraphicsDevice, inStream);
            previewSpriteAP.m_AnimSheet = m_PreviewSpTex;
        }
        public void setCurPreviewSpPivot(int x , int y)
        {
            previewSpriteAP.m_pivot = new Vector2(x, y);
        }
        public void setCurPlayRate(int rate)
        {
            previewSpriteAP.m_playbackSpeed = rate;
        }
        private double GetInterval()
        {
            return ((double)Stopwatch.Frequency / (DefaultFPS));
        }
        public void update()
        {
            long ticks1 = 0;
            long ticks2 = 0;

            while (true)
            {
                double interval = GetInterval();
                Application.DoEvents();
                ticks2 = Stopwatch.GetTimestamp();
                if (ticks2 >= ticks1 + interval) //重繪時間到
                {
                    ticks1 = Stopwatch.GetTimestamp();
                    Draw();
                    this.Refresh();
                }
                Thread.Sleep(1); // Free's up the cpu
            }

        }


        /// <summary>
        /// Disposes the control, unloading the ContentManager.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (ReDrawThread != null)
                ReDrawThread.Abort();

            if (scFS != null)
            {
                scFS.Dispose();
                scFS.Close();
            }
            if (MokujinFS != null)
            {
                MokujinFS.Dispose(); 
                MokujinFS.Close();
            }
            if (RedCrossFS != null)
            {
                RedCrossFS.Dispose(); 
                RedCrossFS.Close();
            }
            
            base.Dispose(disposing);
        }


        /// <summary>
        /// Draws the control, using SpriteBatch and SpriteFont.
        /// </summary>
        protected override void Draw()
        {

            //清除背景
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend);
            //畫背景的啦
                spriteBatch.Draw(m_ScBGTex, new Vector2(0, 0),
                    new Rectangle(0, 0, m_ScBGTex.Width, m_ScBGTex.Height),
                    Color.White, 0.0f, new Vector2(0, 0), 1.0f,
                    SpriteEffects.None, 0f);
            spriteBatch.End();

            

            if (bEffectMode) //如果是特效預覽模式就
            {
                //Debug.WriteLine("mokujin X = " + mokujinSpriteAP.m_DrawRect.X.ToString());
                //Debug.WriteLine("mokujin Y = " + mokujinSpriteAP.m_DrawRect.Y.ToString());
                //畫木頭人
                spriteBatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend, null, null, null, _basicEffect);
                //spriteBatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend);
                spriteBatch.Draw(m_MokujinSpTex, mokujinSpriteAP.m_position,
                    mokujinSpriteAP.m_DrawRect,
                    Color.White, 0.0f, mokujinSpriteAP.m_pivot, 1.0f,
                    SpriteEffects.None, 0f);

                //畫紅十字
                spriteBatch.Draw(m_RedCrossTex, mokujinSpriteAP.m_position,
                new Rectangle(0, 0, m_RedCrossTex.Width, m_RedCrossTex.Height),
                Color.White, 0.0f, new Vector2(m_RedCrossTex.Width / 2, m_RedCrossTex.Height / 2), 1.0f,
                SpriteEffects.None, 0f);

                spriteBatch.End();
               
            }
            //if (bEffectMode)//開啟半透明，還沒好透阿!(不能用)
            //{
            //  previewSpriteAP.m_MainColorShift

            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.NonPremultiplied, null, null, null, ColorTransformEffect);
                if (previewSpriteAP.m_AnimSheet != null)
                {
                    spriteBatch.Draw(previewSpriteAP.m_AnimSheet, previewSpriteAP.m_position,
                       previewSpriteAP.m_DrawRect,
                       Color.White, 0.0f, previewSpriteAP.m_pivot, previewSpriteAP.m_scale_,
                       SpriteEffects.None, 0f);
                }
                spriteBatch.End();
            //}
            //else
            //{
            //    spriteBatch.Begin(SpriteSortMode.Texture, BlendState.NonPremultiplied);
            //    if (previewSpriteAP.m_AnimSheet != null)
            //    {
            //        spriteBatch.Draw(previewSpriteAP.m_AnimSheet, previewSpriteAP.m_position,
            //           previewSpriteAP.m_DrawRect,
            //           Color.White, 0.0f, previewSpriteAP.m_pivot, previewSpriteAP.m_scale_,
            //           SpriteEffects.None, 0f);
            //    }
            //    spriteBatch.End();

            //}
          
           

            

            
        }
    }
}
