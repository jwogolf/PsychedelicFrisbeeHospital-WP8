using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Engine
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static IServiceProvider IServiceProvider { get; set; }
        public static GraphicsDeviceManager Manager { get; set; }

        public Game1()
        {
            Manager = new GraphicsDeviceManager(this);
            IServiceProvider = Content.ServiceProvider;
            Content.RootDirectory = "Content";

            Manager.SynchronizeWithVerticalRetrace = true;
            IsFixedTimeStep = true;
            IsMouseVisible = true;

            Manager.ApplyChanges();
        }

        protected override void Initialize()
        {
            GameState.AddScreen(new LoadingScreen(new LevelSelector()));
            base.Initialize();
        }

        protected override void LoadContent()
        {
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            GameState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GameState.Draw(gameTime);

            base.Draw(gameTime);
        }
    }


    #region Entry Point

#if WINDOWS || XBOX

    static class EntryPoint
    {
        static void Main()
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }

#endif

    #endregion
}
