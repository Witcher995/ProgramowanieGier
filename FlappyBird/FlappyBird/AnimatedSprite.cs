using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FlappyBird
{
    public enum SheetOrientation
    {
        VERTICAL,
        HORIZONTAL
    }


    public class AnimatedSprite : Sprite
    {
        private int spriteWidth;
        private int spriteHeight;
        private int currentIndex;
        private Rectangle sourceRectangle;
        
        private SheetOrientation orientation;

        public void SetIndex(int index)
        {
            this.currentIndex = index;
        }


        public AnimatedSprite(string imgKey, int spriteWidth, int spriteHeight, int index, SheetOrientation orientation)
            : base(imgKey)
        {
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
            this.currentIndex = index;
            this.orientation = orientation;

            this.destinationRectangle = new Rectangle(0, 0, this.spriteWidth * Settings.PIXEL_RAPIO, this.spriteHeight * Settings.PIXEL_RAPIO);

            if (this.orientation == SheetOrientation.HORIZONTAL)
                this.sourceRectangle = new Rectangle(this.currentIndex * this.spriteWidth, 0, this.spriteWidth, this.spriteHeight);
            else
                this.sourceRectangle = new Rectangle(0, this.currentIndex * this.spriteHeight, this.spriteWidth, this.spriteHeight);

        }

        public override void Update(int x, int y)
        {
            this.destinationRectangle.X = (x + (int)this.origin.X) * Settings.PIXEL_RAPIO;
            this.destinationRectangle.Y = (y + (int)this.origin.Y) * Settings.PIXEL_RAPIO;
            this.destinationRectangle.Width = this.spriteWidth * Settings.PIXEL_RAPIO;
            this.destinationRectangle.Height = this.spriteHeight * Settings.PIXEL_RAPIO;
            if (this.orientation == SheetOrientation.HORIZONTAL)
            {
                this.sourceRectangle.X = this.currentIndex * this.spriteWidth;
                this.sourceRectangle.Y = 0;
            }
            else
            {
                this.sourceRectangle.X = 0;
                this.sourceRectangle.Y = this.currentIndex * this.spriteHeight; ;
            }
            this.sourceRectangle.Width = this.spriteWidth;
            this.sourceRectangle.Height = this.spriteHeight;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.destinationRectangle,this.sourceRectangle, this.color,this.rotation,Vector2.Zero,this.imgOrientation,0f);

        }
    }
}
