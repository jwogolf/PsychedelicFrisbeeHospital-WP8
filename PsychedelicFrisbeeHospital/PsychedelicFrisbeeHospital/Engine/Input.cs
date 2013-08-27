using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Engine
{
    public static class Input
    {
        public static bool IsConnected { get; set; }
        public static int MaximumTouchCount { get; set; }

        public static bool Side { get; set; }

        public static TouchCollection Touches;

        static Input()
        {
            TouchPanelCapabilities capabilities = TouchPanel.GetCapabilities();

            IsConnected = capabilities.IsConnected;
            MaximumTouchCount = capabilities.MaximumTouchCount;
        }
        
        public static void Update()
        {
            Touches = TouchPanel.GetState();
        }

        //TODO: Make this do lots of cool shit
    }


} 