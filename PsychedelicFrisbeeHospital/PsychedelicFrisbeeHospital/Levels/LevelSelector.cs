using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;

namespace Engine
{
    public class LevelSelector : Screen
    {
        #region Members

        private Random Rand = new Random(DateTime.Now.Millisecond);
        double CurrentGameTime = 0;
        double PreviousGameTime = 0;

        private List<KeyValuePair<string, Texture2D>> Backgrounds { get; set; }
        private List<KeyValuePair<string, Texture2D>> Characters { get; set; }

        private int Bindex = 0;
        private int P1index = 0; 
        private int P2index = 0;

        private Rectangle BRectangle;
        private Rectangle P1Rectangle;
        private Rectangle P2Rectangle;

        #endregion

        #region Initialize

        public override void Initialize()
        {
            Backgrounds = new List<KeyValuePair<string, Texture2D>>();
            Characters = new List<KeyValuePair<string, Texture2D>>();

            
        }

        #endregion

        #region Load Content

        public override void LoadContent()
        {
            #region Backgrounds

            Backgrounds.Add(new KeyValuePair<string, Texture2D>("Hospital", Content.Load<Texture2D>("Backgrounds\\Hospital")));
            Backgrounds.Add(new KeyValuePair<string, Texture2D>("Candy Kingdom", Content.Load<Texture2D>("Backgrounds\\CandyKingdom")));

            #endregion

            #region Characters

            Characters.Add(new KeyValuePair<string, Texture2D>("Finn", Content.Load<Texture2D>("Characters\\Finn")));
            Characters.Add(new KeyValuePair<string, Texture2D>("Fiona", Content.Load<Texture2D>("Characters\\Fiona")));

            #endregion



            ContentLoaded = true;
        }

        #endregion

        #region Unload Content

        public override void UnloadContent()
        {
            Content.Unload();
            Batch.Dispose();
            ContentLoaded = false;
        }

        #endregion

        #region Update

        public override void Update(GameTime gameTime)
        {
            if (Updates)
            {
                #region Rectangles

                Vector2 BBottomRight = new Vector2(Backgrounds[Bindex].Value.Width, Backgrounds[Bindex].Value.Height);
                BRectangle = new Rectangle(Graphics.Width / 2 - (int)BBottomRight.X / 4, (int)BBottomRight.Y / 4, (int)BBottomRight.X / 2, (int)BBottomRight.Y / 2);

                Vector2 P1BottomRight = new Vector2(Characters[P1index].Value.Width, Characters[P1index].Value.Height);
                Vector2 P2BottomRight = new Vector2(Characters[P1index].Value.Width, Characters[P2index].Value.Height);
                P1Rectangle = new Rectangle(Graphics.Width / 4 - (int)P1BottomRight.X / 2, Graphics.Height / 4 * 3 - (int)P1BottomRight.Y / 2, (int)P1BottomRight.X, (int)P1BottomRight.Y);
                P2Rectangle = new Rectangle(Graphics.Width / 4 * 3 - (int)P2BottomRight.X / 2, Graphics.Height / 4 * 3 - (int)P2BottomRight.Y / 2, (int)P2BottomRight.X, (int)P2BottomRight.Y);

                #endregion


                TouchCollection tc = TouchPanel.GetState();

                foreach (TouchLocation tl in tc)
                {
                    //if ()
                    {
                        if (BRectangle.Contains((int)tl.Position.X, (int)tl.Position.Y)) if (Bindex >= Backgrounds.Count - 1) Bindex = 0; else Bindex++;
                        
                    }
                }
            }
        }

        #endregion

        #region Draw

        Color BCol = Color.Black;

        public override void Draw(GameTime gameTime)
        {
            if (Draws)
            {
                #region Flashing

                CurrentGameTime = gameTime.TotalGameTime.TotalSeconds;

                if (CurrentGameTime - PreviousGameTime > 0.25)
                {
                    BCol = new Color((float)Rand.NextDouble(), (float)Rand.NextDouble(), (float)Rand.NextDouble());
                    PreviousGameTime = CurrentGameTime;
                }


                Game1.Manager.GraphicsDevice.Clear(BCol);

                #endregion

                Batch.Begin();

                #region Background

                Batch.Draw(Backgrounds[Bindex].Value, BRectangle, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);

                #endregion 
                
                #region Players


                Batch.Draw(Characters[P1index].Value, P1Rectangle, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                Batch.Draw(Characters[P2index].Value, P2Rectangle, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);

                #endregion

                Batch.End();
            }
        }

        #endregion
    }
}
