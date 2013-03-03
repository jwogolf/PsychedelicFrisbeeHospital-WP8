using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class GameSettings : Screen
    {
        #region Members

        public static Keys[] PlayerOneKeys { get; set; }
        public static Keys[] PlayerTwoKeys { get; set; }

        public int[,] Index { get; set; }

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

        public override void Draw(GameTime gameTime)
        {
            if (Draws)
            {
                Game1.Manager.GraphicsDevice.Clear(Color.CornflowerBlue);
            }
        }

        #endregion
    }
}
