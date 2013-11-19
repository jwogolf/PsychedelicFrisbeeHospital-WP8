using System;
using Microsoft.Xna.Framework;

namespace Engine
{
    public static class Constants
    {
        #region Game

        #endregion

        #region Physics

        public static const float FrictionalForce = 0.4f;
        public static const float Gravity = 98f;

        #endregion

        #region Graphics

        public static readonly int[] Indices = new int[] { 0, 1, 2, 2, 3, 0 };

        #endregion
    }
}
