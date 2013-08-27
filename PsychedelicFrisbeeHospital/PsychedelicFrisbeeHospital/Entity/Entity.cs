using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public abstract class Entity
    {
        #region Members

        public float Mass { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Force { get; set; }

        public Vector2 Origin { get; set; }

        public Texture2D Texture { get; set; }

        public SpriteEffects Direction { get; set; }

        public bool PlayerOnLeftSide { get; protected set; }

        #endregion

        #region Constructor

        public Entity(Texture2D Texture, Vector2 Origin)
        {
            this.Texture = Texture;
            this.Origin = Origin;

            this.Mass = 1;
        }

        #endregion

        #region Methods

        public virtual void Update(GameTime Time)
        {
            Vector2 Previous = Velocity;

            Velocity += (Force / Mass) + (new Vector2(0, 98f)) / 2 * (float)Time.ElapsedGameTime.TotalSeconds;
            Position += Velocity * (float)Time.ElapsedGameTime.TotalSeconds;

            Direction = Velocity.X < 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            Force = Vector2.Zero;
            if (this.Position.Y + Texture.Height > Graphics.Height)
            {
                Position = new Vector2(Position.X, Graphics.Height - Texture.Height);
            }
        }

        public void Draw(GameTime Time, SpriteBatch Batch)
        {
            Batch.Draw(Texture, Position, null, Color.White, 0, Origin, 1, Direction, 1);
        }

        #endregion
    }
}

