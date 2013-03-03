using Microsoft.Xna.Framework;
using System;

namespace Engine
{
    public class LevelSelector : Screen
    {
        #region Members

        private Random Rand = new Random(DateTime.Now.Millisecond);

        #endregion

        #region Initialize

        public override void Initialize()
        {

        }

        #endregion

        #region Load Content

        public override void LoadContent()
        {
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
