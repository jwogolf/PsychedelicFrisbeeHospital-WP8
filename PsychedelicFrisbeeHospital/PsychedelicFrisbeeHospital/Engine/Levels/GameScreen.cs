using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Engine
{
    public class GameScreen : Screen
    {
        #region Members

        private Texture2D Background;

        private List<Entity> Entities;

        #endregion

        #region Constructor

        public GameScreen(ContentManager Content, Texture2D Background, Player player, Robot robot, bool OnLeftSide)
        {
            this.Content.Unload();
            this.Content.Dispose();
            this.Content = Content;

            //Do some stuff to Left and Right before adding them
            if (OnLeftSide)
            {
                player.Position = new Vector2(60, 120);
                robot.Position = new Vector2(730, 120);
            }
            else
            {
                player.Position = new Vector2(730, 120);
                robot.Position = new Vector2(60, 120);
            }


            FlyingDisc flyingDisc = new FlyingDisc(Content.Load<Texture2D>("General\\FlyingDisc"));
            flyingDisc.Position = new Vector2(70, 110);

            Entities = new List<Entity>(new List<Entity> { player, robot, flyingDisc });

            this.Background = Background;
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
            string s = Background.Name;

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
                foreach (Entity e in Entities) e.Update(gameTime, Entities[2] as FlyingDisc);
            }
        }

        #endregion

        #region Draw

        public override void Draw(GameTime gameTime)
        {
            if (Draws)
            {
                Game1.Manager.GraphicsDevice.Clear(Color.Green);

                Batch.Begin();

                Batch.Draw(Background, Vector2.Zero, Color.White);

                foreach (Entity e in Entities) e.Draw(gameTime, Batch);

                Batch.End();
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}
