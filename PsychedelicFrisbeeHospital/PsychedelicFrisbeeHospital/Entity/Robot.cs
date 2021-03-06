using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class Robot : Entity
    {
        #region Members

        bool HasFlyingDisc = false;
        bool FlyingDiscExiting = false;

        Player Player;

        #endregion

        #region Constructor

        public Robot(Texture2D Texture, Player Player)
            : base(Texture, new Vector2(Texture.Width / 2, Texture.Height / 2))
        {

        }

        #endregion

        #region Methods

        public override void Update(GameTime Time, FlyingDisc FlyingDisc)
        {
            base.Update(Time,FlyingDisc);

            //if (HasFlyingDisc) FlyingDisc.Position = base.HandPosition - FlyingDisc.Origin;
        }

        #endregion
    }
}

