using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class Entity
    {
        #region Members

        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; set; }

        public Vector2 Origin { get; set; }

        public Texture2D Texture { get; set; }

        public SpriteEffects Direction { get; set; }

        #endregion

        #region Constructor

        #endregion

        #region Methods

        public void Update(GameTime Time)
        {
            #region Physics

            Position += Velocity;
            Velocity += Acceleration;

            #endregion

            Direction = Velocity.X < 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            Acceleration = Vector2.Zero;
        }

        public void Draw(GameTime Time, SpriteBatch Batch)
        {
            Batch.Draw(Texture, Position, null, Color.White, 0, Origin, 1, SpriteEffects.None, 1);
        }

        #endregion
    }
}

