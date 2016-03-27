using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame1
{
    public class Sprites : GameObject
    {
        protected Texture2D _texture2D;
        protected SpriteBatch _spriteBatch;

        public Sprites (SpriteBatch spriteBatch, Texture2D texture2D)    
            : base()        
        {
            _spriteBatch = spriteBatch;
            _texture2D = texture2D;

            Size = new Rectangle(0, 0, _texture2D.Width, _texture2D.Height);
            Source = Size;
        }

        public void Draw()
        {
            _spriteBatch.Draw(_texture2D, Position, Source, Color.White);
        }
    }
}
