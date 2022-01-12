using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace drillGame
{
    public static class InputWrapper
    {
        public static Keys Up;
        public static Keys Down;
        public static Keys Left;
        public static Keys Right;
        public static Keys Interact;
        public static Keys ZoomPlus;
        public static Keys ZoomMinus;
        public static Keys Debug;
        public static void SetKeys(Keys up, Keys down, Keys left, Keys right, Keys interact, Keys zoomPlus, Keys zoomMinus, Keys debug) //this is better maybe :D
        {
            Up = up;
            Down = down;
            Left = left;
            Right = right;
            Interact = interact;
            ZoomPlus = zoomPlus;
            ZoomMinus = zoomMinus;
            Debug = debug;
        }
    }
}
