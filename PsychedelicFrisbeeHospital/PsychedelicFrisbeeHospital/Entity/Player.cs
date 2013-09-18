using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace Engine
{
    public class Player : Entity
    {
        #region Members

        protected bool HasFlyingDisc = false;
        protected bool FlyingDiscExiting = false;


        protected Vector2 HandPosition = new Vector2();

        #endregion

        #region Constructor

        public Player(Texture2D Texture)
            : base(Texture, new Vector2(Texture.Width / 2, Texture.Height / 2))
        {
            base.Mass = 324;

        }

        #endregion

        #region Methods

        public override void Update(GameTime Time, FlyingDisc FlyingDisc)
        {
            HandPosition = Position + new Vector2(45, 55);
            if (Vector2.Distance(HandPosition, FlyingDisc.Position) < 100) 
            { 
                if (!FlyingDiscExiting) HasFlyingDisc = true; 
            } 
            else FlyingDiscExiting = false;

            foreach (TouchLocation Touch in Input.Touches)
            {
                if (Touch.State == TouchLocationState.Moved || Touch.State == TouchLocationState.Pressed)
                {
                    if (Touch.Position.X < Graphics.Width / 2)
                    {
                        this.Force = base.Grounded ? new Vector2(-50, 0) : new Vector2(-25, 0);
                    }
                    else
                    {
                        this.Force = base.Grounded ? new Vector2(50, 0) : new Vector2(25, 0);
                    }
                }
            }

            if (HasFlyingDisc)
            {
                while(TouchPanel.IsGestureAvailable)
                {
                    GestureSample sample = TouchPanel.ReadGesture();

                    if (sample.GestureType == GestureType.Flick)
                    {
                        if (sample.Delta.Length() > 3)
                        {
                            double Rotation = Math.Atan2(sample.Delta.Y, sample.Delta.X);

                            
                            if (Rotation > 0 && Rotation < MathHelper.PiOver2)
                            {
                                ///fixxxxxxx
                                Throw(FlyingDisc, sample);
                            }
                        }
                    }
                }
            }
            
            base.Update(Time, FlyingDisc);

            if (HasFlyingDisc) FlyingDisc.Position = HandPosition - FlyingDisc.Origin;
        }

        private void Throw(FlyingDisc FlyingDisc, GestureSample sample)
        {
            FlyingDisc.Force = sample.Delta / 10;
            HasFlyingDisc = false;
            FlyingDiscExiting = true;
        }

        #endregion
    }
}

