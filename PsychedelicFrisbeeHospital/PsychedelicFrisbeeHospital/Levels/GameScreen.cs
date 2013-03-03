using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class GameScreen : Screen
    {
        #region Members

        #endregion

        #region Constructor

        //Kevin is Player 1
        //Zaq is Player 2
        public GameScreen(Texture2D Background, Player Kevin, Player Zaq)
        {

        }

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
                Game1.Manager.GraphicsDevice.Clear(Color.Green);
            }
        }

        #endregion
    }
}
