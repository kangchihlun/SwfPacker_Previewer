#region File Description
//-----------------------------------------------------------------------------
// SpriteFontControl.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace WinFormsGraphicsDevice
{
    /// <summary>
    /// Example control inherits from GraphicsDeviceControl, which allows it to
    /// render using a GraphicsDevice. This control shows how to use ContentManager
    /// inside a WinForms application. It loads a SpriteFont object through the
    /// ContentManager, then uses a SpriteBatch to draw text. The control is not
    /// animated, so it only redraws itself in response to WinForms paint messages.
    /// </summary>
    class SpriteFontControl : GraphicsDeviceControl
    {
        //ContentManager content;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Texture2D mCatCreature;
        BasicEffect _basicEffect;
        /// <summary>
        /// Initializes the control, creating the ContentManager
        /// and using it to load a SpriteFont.
        /// </summary>
        protected override void Initialize()
        {
            //content = new ContentManager(Services, "Content");

            spriteBatch = new SpriteBatch(GraphicsDevice);

            //font = content.Load<SpriteFont>("hudFont");

            //Kang Test
            FileStream filestream = new FileStream("C:\\Users\\bodhi\\Dropbox\\RainbowCloud_Res\\MusicNode_Blue.png", FileMode.Open);
            mCatCreature = Texture2D.FromStream(GraphicsDevice, filestream);

            _basicEffect = new BasicEffect(GraphicsDevice);

        }


        /// <summary>
        /// Disposes the control, unloading the ContentManager.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //content.Unload();
            }

            base.Dispose(disposing);
        }


        /// <summary>
        /// Draws the control, using SpriteBatch and SpriteFont.
        /// </summary>
        protected override void Draw()
        {
            const string message = "Hello, World!\n" +
                                   "\n" +
                                   "I'm an XNA Framework GraphicsDevice,\n" +
                                   "running inside a WinForms application.\n" +
                                   "\n" +
                                   "This text is drawn using SpriteBatch,\n" +
                                   "with a SpriteFont that was loaded\n" +
                                   "through the ContentManager.\n" +
                                   "\n" +
                                   "The pane to my right contains a\n" +
                                   "spinning 3D triangle.";

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Texture,
            BlendState.Additive);
            
            //spriteBatch.DrawString(font, message, new Vector2(23, 23), Color.White);

            //開啟半透明，還沒好透阿!

            GraphicsDevice.BlendState = BlendState.AlphaBlend;
            GraphicsDevice.DepthStencilState = DepthStencilState.DepthRead;

            spriteBatch.Draw(mCatCreature, new Vector2(0,0), 
                new Rectangle(0, 0, mCatCreature.Width, mCatCreature.Height), 
                Color.White,0.0f,new Vector2(mCatCreature.Width / 2f, mCatCreature.Height / 2f),1.0f,
                SpriteEffects.None, 0f);
            spriteBatch.End();
        }
    }
}
