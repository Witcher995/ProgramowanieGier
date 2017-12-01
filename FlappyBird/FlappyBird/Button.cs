using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FlappyBird
{
    public class Button : GameObject
    {
        private bool isPressed;

        public bool IsPressed()
        {
            bool result = this.isPressed;
            if (this.isPressed)
                this.isPressed = false;

            return result;

        }


        public Button(int x, int y, int index)
            : base(x, y, new AnimatedSprite("menu_buttons", 140, 42, index, SheetOrientation.VERTICAL))
        {
            this.isPressed = false;
        }

        public override void Update(GameTime gameTime, Input input)
        {

            if (this.hitbox.Contains(input.GetMousePossition()))
            {
                if (input.IsLeftMousePressed())

                    this.isPressed = true;

                if (input.IsLeftMouseDown())

                    this.sprite.SetColor(Color.Gray);

                else
                    this.sprite.SetColor(Color.LightGray);
            }
            else
                this.sprite.SetColor(Color.White);
            base.Update(gameTime,input);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            base.Draw(spriteBatch);
        }
    }
}

