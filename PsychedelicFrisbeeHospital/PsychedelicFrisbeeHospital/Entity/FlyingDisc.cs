using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class FlyingDisc : Entity
    {
        #region Members

        #endregion

        #region Constructor

        public FlyingDisc(Texture2D Texture)
            : base(Texture, new Vector2(Texture.Width / 2, Texture.Height / 2))
        {
            base.Mass = 1;
        }

        #endregion

        #region Methods

        public override void Update(GameTime Time, FlyingDisc FlyingDisc)
        {
            
            base.Update(Time, FlyingDisc);
        }

        #endregion
    }
}

