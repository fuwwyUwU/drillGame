using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace drillGame
{
    public static class Extensions
    {
        //turns out, static classes cant have extension methods :(
        public static Vector2 ToInt(this Vector2 vector)
        {
            vector.X = (int)vector.X;
            vector.Y = (int)vector.Y;
            return vector;
        }
    }
}
