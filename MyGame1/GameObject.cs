using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame1
{
    public class GameObject
    {
        public Vector2 Position;
        public Rectangle Source;
        public Rectangle Size;

        public GameObject()
        {
            Position = Vector2.Zero;
            Size = Rectangle.Empty;
            Source = Rectangle.Empty;
        }
    }

}
