using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace FlappyBird
{
    public class Input
    {
        public KeyboardState oldkeyboard;
        private KeyboardState keyboard;

        private MouseState oldMouse;
        private MouseState mouse;

        public Input(KeyboardState oldkeyboard, MouseState oldMouse, KeyboardState keyboard, MouseState mouse)
        {
            this.oldkeyboard = oldkeyboard;
            this.oldMouse = oldMouse;


            this.keyboard = keyboard;
            this.mouse = mouse;

            
        }


        public bool IsKey(Keys key)
        {
            return this.oldkeyboard.IsKeyUp(key) && this.keyboard.IsKeyDown(key);
        }


        public bool IsLeftMouseDown()
        {
            return this.mouse.LeftButton == ButtonState.Pressed;
        }

      
        public bool IsLeftMousePressed()
        {
            return this.oldMouse.LeftButton == ButtonState.Pressed && this.mouse.LeftButton == ButtonState.Released;
        }

        public bool IsSpacePressed()
        {
            return this.oldkeyboard.IsKeyDown(Keys.Space);
        }

        public Point GetMousePossition()
        {
            return new Point(this.mouse.X, this.mouse.Y);
        }

        

    }
}
