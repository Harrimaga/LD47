using LD47.Ships;
using LD47.Weapons;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47
{
    class Game
    {

        public Window window;
        
        private Level l = new Level(Textures.testLevel);
        public List<DrawnButton> buttons = new List<DrawnButton>();


        public Player player = new Player(Enums.Nation.Brittain);
        


        public Game(Window window)
        {
            this.window = window;
            OnLoad();
        }

        public void OnLoad()
        {
            Globals.projectiles = new List<Projectile>();
        }

        public void Update(double delta)
        {
            Globals.delta = delta;
            //Updating logic
            player.Update(delta);
            foreach (Projectile projectile in Globals.projectiles)
            {
                projectile.Update(delta);
            }

            l.Update();
        }

        public void Draw()
        {
            //Do all you draw calls here

            player.Draw();
            foreach (Projectile projectile in Globals.projectiles)
            {
                projectile.Draw();
            }


            l.draw();
            foreach (DrawnButton button in buttons)
            {
                button.Draw();
            }
        }

        public void MouseDown(MouseButtonEventArgs e, int mx, int my)
        {
            if (e.Button == MouseButton.Left)
            {
                for (int i = buttons.Count - 1; i >= 0; i--)
                {
                    DrawnButton button = buttons[i];
                    if (button.IsInButton(mx, my))
                    {
                        button.OnClick();
                        break;
                    }
                }
            }
        }

        public void MouseUp(MouseButtonEventArgs e, int mx, int my)
        {

        }
    }
}
