#region File Description
//-----------------------------------------------------------------------------
// SpriteEffect.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace StockEffects
{
    /// <summary>
    /// The default effect used by SpriteBatch.
    /// </summary>
    public class SpriteEffect_Colorized : Effect
    {
        #region Effect Parameters

        EffectParameter matrixParam;
        EffectParameter shiftedColorParam;

        public Vector4 colorshiftMain=Vector4.One;
        #endregion

        #region Methods


        /// <summary>
        /// Creates a new SpriteEffect.
        /// </summary>
        public SpriteEffect_Colorized(GraphicsDevice device)
            : base(device, Resources.SpriteEffect_Colorized)
        {
            CacheEffectParameters();
        }


        /// <summary>
        /// Creates a new SpriteEffect by cloning parameter settings from an existing instance.
        /// </summary>
        protected SpriteEffect_Colorized(SpriteEffect_Colorized cloneSource)
            : base(cloneSource)
        {
            CacheEffectParameters();
        }


        /// <summary>
        /// Creates a clone of the current SpriteEffect instance.
        /// </summary>
        public override Effect Clone()
        {
            return new SpriteEffect_Colorized(this);
        }


        /// <summary>
        /// Looks up shortcut references to our effect parameters.
        /// </summary>
        void CacheEffectParameters()
        {
            matrixParam = Parameters["MatrixTransform"];
            shiftedColorParam = Parameters["ShiftedColor"];
        }


        /// <summary>
        /// Lazily computes derived parameter values immediately before applying the effect.
        /// </summary>
        protected override void OnApply()
        {
            Viewport viewport = GraphicsDevice.Viewport;

            Matrix projection = Matrix.CreateOrthographicOffCenter(0, viewport.Width, viewport.Height, 0, 0, 1);
            Matrix halfPixelOffset = Matrix.CreateTranslation(-0.5f, -0.5f, 0);

            matrixParam.SetValue(halfPixelOffset * projection);
            shiftedColorParam.SetValue(colorshiftMain);
        }

        //I:\C#Proj\SwfPack_Previewer\SpriteSheetK\StockEffects\CompileEffect\bin\$(ConfigurationName)\CompileEffect.exe Windows Reach $(ProjectDir)HLSL\SpriteEffect_Colorized.fx $(ProjectDir)obj\SpriteEffect_Colorized.bin
        #endregion
    }
}
