
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
   public class Sprite
    {
        
        
        protected Texture2D texture;
        protected Rectangle destinationRectangle;
        protected Color color;
        protected float rotation;
        protected Vector2 origin;
        protected SpriteEffects imgOrientation;

        public Point GetTextureSize()
        {
            return new Point(this.destinationRectangle.Width, this.destinationRectangle.Height);
        }

      
        public void SetColor(Color color)
        {
            this.color = color;
        }

        public void SetOrientation(SpriteEffects orientation)
        {
            this.imgOrientation = orientation;
        }

        public void SetRotation(float rotation)
        {
            this.rotation = rotation;
        }

        public void SetOrigin(int x, int y)
        {
            this.origin.X = x;
            this.origin.Y = y;
        }

        public Sprite(string imgkey)
        {

            Initialize(imgkey, 0, 0,SpriteEffects.None);

        }
      
        public Sprite(string imgkey, int x, int y)
        {

            Initialize(imgkey, x, y, SpriteEffects.None);

        }
        public Sprite(string imgkey, int x, int y, SpriteEffects orientation)
        {

            Initialize(imgkey, x, y, orientation);

        }

        public void Initialize(string imgkey, int x, int y, SpriteEffects orientation)
        { 
            this.texture = Resources.Images[imgkey];    
            this.color = Color.White;
            this.destinationRectangle = new Rectangle(x*Settings.PIXEL_RAPIO,y * Settings.PIXEL_RAPIO, 
                this.texture.Width * Settings.PIXEL_RAPIO, 
                this.texture.Height * Settings.PIXEL_RAPIO);
            this.rotation = 0f;
            this.imgOrientation = orientation;
            this.origin = new Vector2(0,0);

        }

        public virtual void Update(int x, int y) {
            this.destinationRectangle.X = (x + (int)this.origin.X) * Settings.PIXEL_RAPIO;
            this.destinationRectangle.Y = (y + (int)this.origin.Y) * Settings.PIXEL_RAPIO;
            this.destinationRectangle.Width = this.texture.Width * Settings.PIXEL_RAPIO;
                this.destinationRectangle.Height = this.texture.Height * Settings.PIXEL_RAPIO;

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

           
            spriteBatch.Draw(this.texture, this.destinationRectangle, null, this.color,this.rotation, this.origin,this.imgOrientation, 0f);

        }


    }
}
