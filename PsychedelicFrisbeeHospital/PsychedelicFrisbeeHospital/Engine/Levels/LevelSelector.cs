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

        private List<KeyValuePair<string, Texture2D>> Backgrounds;
        private List<KeyValuePair<string, Texture2D>> Characters;

        private Texture2D StartTripTex;
        private Texture2D StartTripPressedTex;
        
        private int Bindex = 0;
        private int Pleftindex = 0; 
        private int Prightindex = 0;

        private Rectangle BRectangle;
        private Rectangle PleftRectangle;
        private Rectangle PrightRectangle;
        private Rectangle StartTripRectangle;

        private bool StartPressed;

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
            Characters.Add(new KeyValuePair<string, Texture2D>("Kevin", Content.Load<Texture2D>("Characters\\Kevin2")));
            Characters.Add(new KeyValuePair<string, Texture2D>("Zaq", Content.Load<Texture2D>("Characters\\zaq2")));

            #endregion

            StartTripTex = Content.Load<Texture2D>("General\\trip");
            StartTripPressedTex = Content.Load<Texture2D>("General\\trippressed");

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
        int startId;
        public override void Update(GameTime gameTime)
        {
            if (Updates)
            {
                #region Rectangles

                Vector2 BBottomRight = new Vector2(Backgrounds[Bindex].Value.Width, Backgrounds[Bindex].Value.Height);
                BRectangle = new Rectangle(Graphics.Width / 2 - (int)BBottomRight.X / 4, (int)BBottomRight.Y / 4, (int)BBottomRight.X / 2, (int)BBottomRight.Y / 2);

                Vector2 PleftBottomRight = new Vector2(Characters[Pleftindex].Value.Width, Characters[Pleftindex].Value.Height);
                Vector2 PrightBottomRight = new Vector2(Characters[Prightindex].Value.Width, Characters[Prightindex].Value.Height);
                PleftRectangle = new Rectangle(Graphics.Width / 4 - (int)PleftBottomRight.X / 2, Graphics.Height / 4 * 3 - (int)PleftBottomRight.Y / 2, (int)PleftBottomRight.X, (int)PleftBottomRight.Y);
                PrightRectangle = new Rectangle(Graphics.Width / 4 * 3 - (int)PrightBottomRight.X / 2, Graphics.Height / 4 * 3 - (int)PrightBottomRight.Y / 2, (int)PrightBottomRight.X, (int)PrightBottomRight.Y);

                StartTripRectangle = new Rectangle(Graphics.Width / 2 - StartTripTex.Width / 2, Graphics.Height / 4 * 3 - StartTripTex.Height, StartTripTex.Width, StartTripTex.Height);

                StartTripRectangle.Inflate(80, 40);

                #endregion

                TouchCollection tc = TouchPanel.GetState();

                foreach (TouchLocation tl in tc)
                {
                    #region Selector

                    if (tl.State == TouchLocationState.Pressed)
                    {
                        if (Graphics.Device.Viewport.Bounds.Contains((int)tl.Position.X, (int)tl.Position.Y))
                        {
                            if (Utilities.PadRectangle(PleftRectangle, 1.2f, 1.03f).Contains((int)tl.Position.X, (int)tl.Position.Y))
                            {
                                if (Pleftindex >= Characters.Count - 1) Pleftindex = 0; else Pleftindex++;
                            }
                            else if (Utilities.PadRectangle(PrightRectangle, 1.2f, 1.03f).Contains((int)tl.Position.X, (int)tl.Position.Y))
                            {
                                if (Prightindex >= Characters.Count - 1) Prightindex = 0; else Prightindex++;
                            }
                            else if (StartTripRectangle.Contains((int)tl.Position.X, (int)tl.Position.Y))
                            {
                                StartPressed = true;
                                startId = tl.Id;
                                
                            }
                            else
                            {
                                if (Bindex >= Backgrounds.Count - 1) Bindex = 0; else Bindex++;
                            }
                        }
                    }
                    if (tl.State == TouchLocationState.Released)
                    {
                        if (!StartTripRectangle.Contains((int)tl.Position.X, (int)tl.Position.Y))
                        {
                            if (startId == tl.Id)
                            {
                                StartPressed = false;
                            }
                        }
                        if (StartTripRectangle.Contains((int)tl.Position.X, (int)tl.Position.Y))
                        {
                            if (startId == tl.Id)
                            {
                                StartPressed = false;

                                Player PlayerLeft = new Player(Characters[Pleftindex].Value);
                                Player PlayerRight = new Player(Characters[Prightindex].Value);

                                GameState.AddScreen(new GameScreen(Backgrounds[Bindex].Value, PlayerLeft, PlayerRight));
                                GameState.RemoveScreen(this);
                            }
                        }
                    }

                    #endregion
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

                //CurrentGameTime = gameTime.TotalGameTime.TotalSeconds;

                //if (CurrentGameTime - PreviousGameTime > 0.25)
               // {
                //    BCol = new Color((float)Rand.NextDouble(), (float)Rand.NextDouble(), (float)Rand.NextDouble());
                //    PreviousGameTime = CurrentGameTime;
               // }


                //Game1.Manager.GraphicsDevice.Clear(BCol);

                
                Game1.Manager.GraphicsDevice.Clear(Color.CornflowerBlue);

                #endregion

                Batch.Begin();

                //Draw Background
                Batch.Draw(Backgrounds[Bindex].Value, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

                //Draw Players
                Batch.Draw(Characters[Pleftindex].Value, PleftRectangle, null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                Batch.Draw(Characters[Prightindex].Value, PrightRectangle, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);

                if (StartPressed)
                {
                    Batch.Draw(StartTripPressedTex, StartTripRectangle, null, new Color(255, 255, 255, 140), 0, Vector2.Zero, SpriteEffects.None, 0);
                }
                else
                {
                    Batch.Draw(StartTripTex, StartTripRectangle, null, new Color(255, 255, 255, 100), 0, Vector2.Zero, SpriteEffects.None, 0);
                }


                Batch.End();
            }
        }

        #endregion

        #region Methods


        #endregion

    }
}
