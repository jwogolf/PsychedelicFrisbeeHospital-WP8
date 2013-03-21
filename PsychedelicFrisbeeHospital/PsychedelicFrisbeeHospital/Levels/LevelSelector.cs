using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Engine
{
    public class LevelSelector : Screen
    {
        #region Members

        private Random Rand = new Random(DateTime.Now.Millisecond);

        private List<KeyValuePair<string, Texture2D>> Backgrounds { get; set; }
        private List<KeyValuePair<string, Texture2D>> Characters { get; set; }

        private int Bindex = 0;
        private int Cindex = 0;

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

            }
        }

        #endregion

        #region Draw

        double CurrentGameTime = 0;
        double PreviousGameTime = 0;
        Color BCol = Color.Black;

        public override void Draw(GameTime gameTime)
        {
            if (Draws)
            {
                #region Background
                CurrentGameTime = gameTime.TotalGameTime.TotalSeconds;
                if (CurrentGameTime - PreviousGameTime > 0.25)
                {
                    BCol = new Color((float)Rand.NextDouble(), (float)Rand.NextDouble(), (float)Rand.NextDouble());
                    PreviousGameTime = CurrentGameTime;
                }

                Game1.Manager.GraphicsDevice.Clear(BCol);
                #endregion

                Batch.Begin();

                Batch.Draw(Backgrounds[Bindex].Value, new Rectangle(20, 20, Backgrounds[Bindex].Value.Width / 2, Backgrounds[Bindex].Value.Height / 2), Color.White);

                Batch.End();
            }
        }

        #endregion
    }
}
