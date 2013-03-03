using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Engine
{
    #region Graphics

    public static class Graphics
    {
        public static GraphicsDeviceManager Manager { get { return Game1.Manager; } }
        public static GraphicsDevice Device { get { return Manager.GraphicsDevice; } }

        public static int Width { get { return Device.Viewport.Width; } }
        public static int Height { get { return Device.Viewport.Height; } }
    }

    #endregion

    #region Camera

    public class Camera
    {
        #region Members

        public Matrix View;
        public Matrix Proj;

        public float Scl;

        Vector2 Pos;
        Vector2 Cnt;

        #endregion

        #region Constructor

        public Camera(Vector2 Pos)
        {
            this.Scl = 1;
            this.Pos = Pos;
            this.Cnt = new Vector2(Graphics.Width / 2, Graphics.Height / 2);
            this.View = Matrix.CreateTranslation(new Vector3(Cnt - Pos, 0));
            this.Proj = Matrix.CreateOrthographicOffCenter(0, 1280, 720, 0, 0, 1);
        }

        #endregion

        #region Update

        public void Update()
        {
            View = Matrix.CreateTranslation(new Vector3(Cnt - Pos, 0));
        }

        #endregion
    }

    #endregion

}
