using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public static class Utilities
    {
        /// <summary>
        /// Copys a rectangle and inflates it
        /// </summary>
        /// <param name="source">Rectangle to copy and inflate</param>
        /// <returns>Inflated rectangle</returns>
        public static Rectangle PadRectangle(Rectangle source, float scaleX, float scaleY)
        {
            //return new Rectangle((int)(source.X * scale), (int)(source.Y * scale), (int)(source.Width * scale), (int)(source.Height * scale));
            
            //inflate and return copy
            source.Inflate((int)(source.Width * scaleX), (int)(source.Height * scaleY));
            return source;
        }
     }
}

