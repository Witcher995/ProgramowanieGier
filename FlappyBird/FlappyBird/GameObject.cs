using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird
{
    public abstract class GameObject
    {
        protected Rectangle hitbox;
        protected Sprite sprite;

        public int x
        {
            get { return this.hitbox.X; }
        }

        public int Right
        {
            get { return this.hitbox.Right; }
        }

        protected GameObject(int x, int y,Sprite sprite)
        {
          
            Point textureSize = sprite.GetTextureSize();
            this.hitbox = new Rectangle(x * Settings.PIXEL_RAPIO, y * Settings.PIXEL_RAPIO, textureSize.X, textureSize.Y);
            this.sprite = sprite;
            this.sprite.Update(x, y);
        }

        public bool CollisionWith(GameObject obj)
        {
            return this.hitbox.Intersects(obj.hitbox);
        }

        public virtual void Update(GameTime gameTime, Input input)
        {
            this.sprite.Update(this.hitbox.X * Settings.PIXEL_RAPIO, this.hitbox.Y * Settings.PIXEL_RAPIO);
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
         // spriteBatch.Draw(Resources.Images["ground"], this.hitbox, Color.Red);
        }

    }
}
