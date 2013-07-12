using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class Player : Entity
    {
        #region Members

        #endregion

        #region Constructor

        public Player(Texture2D Texture)
            : base(Texture, new Vector2(Texture.Width / 2, Texture.Height / 2))
        {
            
        }

        #endregion

        #region Methods

        #endregion
    }
}

