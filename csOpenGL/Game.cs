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
        

        private Sprite s = new Sprite(Globals.Width, Globals.Height, 0, 0);
        public List<DrawnButton> buttons = new List<DrawnButton>();


        public Player player = new Player(Enums.Nation.Brittain);
        


        public Game(Window window)
        {
            this.window = window;
            OnLoad();
        }

        public void OnLoad()
        {
            buttons.Add(new DrawnButton("test", 0, 0, 200, 100, () => { Window.window.ToggleShader(1); }, 0.5f, 0.5f, 0.5f));
            buttons.Add(new DrawnButton("test2", 0, 105, 200, 100, () => { Window.window.ToggleShader(2); }, 0.5f, 0.5f, 0.5f));

            Globals.projectiles = new List<Projectile>();
        }

        public void Update(double delta)
        {
            //Updating logic
            player.Update(delta);
            foreach (Projectile projectile in Globals.projectiles)
            {
                projectile.Update(delta);
            }
        }

        public void Draw()
        {
            //Do all you draw calls here
            s.Draw(0, 0);

            player.Draw();
            foreach (Projectile projectile in Globals.projectiles)
            {
                projectile.Draw();
            }


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
