using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird
{
    class Bird : GameObject
    {
        private const float MAX_SPEED = 10f;
        private const float FLAP = -4f;
        private const float MAX_ROTATION = ((float)Math.PI/4f);
        private const float MAX_ROTATION_VELOCITY = 0.15f;

        private bool gravity;
        private float speedY;
        private float rotationVelocity;
        private float rotation;
        private int currentFrame;
        private bool flap;
        private int timer;

        public Bird(int x, int y)
            : base(x, y, new AnimatedSprite("bird", 73, 67, 0, SheetOrientation.HORIZONTAL))

        {
            this.gravity = false;
            this.speedY = 0f;
            this.rotationVelocity = 0F;
            this.rotation = 0f;
            this.currentFrame = 0;
            this.flap = false;
            this.timer = 0;
        }

        public void ActiveGravity()
        {
            this.gravity = true;
        }

        public void SetMaxRotation()
        {
            this.rotation = MAX_ROTATION;
        }


        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);


            if (this.flap)
            {
                this.timer += gameTime.ElapsedGameTime.Milliseconds;
                if (this.timer >= 24)
                {
                    this.timer = 0;
                  
                    if (this.currentFrame == 13)
                    {
                        this.currentFrame = 0;
                        this.flap = false;

                    }
                    else
                        ++this.currentFrame;
                    ((AnimatedSprite)this.sprite).SetIndex(this.currentFrame);
                
                }
            }
         
            if (input != null)
            { 
                if (input.IsSpacePressed() && !this.flap)
                {
                    
                    this.gravity = true;
                    this.speedY = FLAP;
                    this.flap = true;
                    this.rotation = -(float)Math.PI / 5f;
                    this.rotationVelocity = -0.15f;
                }
            }

            if (this.gravity)
            {

                if (this.speedY < MAX_SPEED)
                {
                    this.speedY += 0.15f;
                }

                if (this.rotationVelocity < MAX_ROTATION_VELOCITY)
                {
                    this.rotationVelocity += 0.005f;
                }

                if (this.rotation < MAX_ROTATION)
                {
                    if (this.rotationVelocity > 0f)
                        this.rotation += this.rotationVelocity;
                }
                else
                    this.rotation = MAX_ROTATION;

                this.sprite.SetRotation(this.rotation);
                this.hitbox.Y += (int)this.speedY;


            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }


}
