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
   
        Dictionary<string, Texture2D> Backgrounds { get; set; }
        Dictionary<string, Texture2D> Characters { get; set; }

        #endregion

        #region Initialize

        public override void Initialize()
        {

        }

        #endregion

        #region Load Content

        public override void LoadContent()
        {
            #region Backgrounds

            Backgrounds.Add("Hospital", Content.Load<Texture2D>("Background\\Hospital"));
            Backgrounds.Add("Candy Kingdom", Content.Load<Texture2D>("Background\\CandyKingdom"));

            #endregion

            #region Characters

            Characters.Add("Finn", Content.Load<Texture2D>("Finn"));
            Characters.Add("Fiona", Content.Load<Texture2D>("Fiona"));

            #endregion

            ContentLoaded = true;
        }

        #endregion

        #region Unload Content

        public override void UnloadContent()
        {
            Content.Unload();
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

                
            }
        }

        #endregion
    }
}
