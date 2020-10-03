using LD47.Ships;
using LD47.Weapons;
using OpenTK.Input;
using Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47
{
    public class Game
    {

        public Window window;
        
        private Level l = new Level(Textures.MapLondonDortmund);
        public List<DrawnButton> buttons = new List<DrawnButton>();


        public Player player = new Player(Enums.Nation.Brittain);
        


        public Game(Window window)
        {
            this.window = window;
            OnLoad();
            Globals.currentLevel = l;
            Globals.player = player;
        }

        public void OnLoad()
        {
            // Check if a savestate exists already
            if ( FileHandler.FileExists("data/save.state") )
            {
                try
                {
                    Globals.state = FileHandler.Read<State>("data/save.state");
                } catch(Exception e)
                {
                    Globals.Logger.Log(e.Message, LogLevel.ERROR);
                }

            }

            if (Globals.state == null)
            {
                Globals.state = new State();
                try
                {
                    FileHandler.Write(Globals.state, "data/save.state", true);
                } catch(Exception e)
                {
                    Globals.Logger.Log(e.Message, LogLevel.ERROR);
                }
            }

            // Create leaderBoardUI
            Globals.leaderBoardUI = new LeaderBoardUI(50, 250, Globals.state.Highscores);

        }

        public void Update(double delta)
        {
            Globals.delta = delta;
            //Updating logic
            if(player.health <= 0)
            {
                PlayerDied();
                return;
            }
            player.Update(delta);

            l.Update();
        }

        public void PlayerDied()
        {
            player = new Player(Enums.Nation.Brittain);
            Globals.player = player;
            Globals.leaderBoardUI.AddToLeaderboard(new Score(Globals.playerName, Globals.levelScore));
            Globals.levelScore = 0;
            Globals.currentLevel = new Level(Textures.testLevel);
            l = Globals.currentLevel;
        }

        private void RemoveOverdraw()
        {
            Sprite s = new Sprite(1920 / 2 - 400, 1080, 0, 1);
            s.Draw(0, 0, false, 0, 0, 0, 0, 1);
            s.Draw(1920/2+400, 0, false, 0, 0, 0, 0, 1);
            s = new Sprite(800, 45, 0, 1);
            s.Draw(1920 / 2 - 400, 0, false, 0, 0, 0, 0, 1);
            s.Draw(1920 / 2 - 400, 1080-45, false, 0, 0, 0, 0, 1);
        }

        public void Draw()
        {
            //Do all you draw calls here

            l.draw();
            foreach (Projectile projectile in Globals.currentLevel.projectiles)
            {
                projectile.Draw();
            }

            player.Draw();

            RemoveOverdraw();

            foreach (DrawnButton button in buttons)
            {
                button.Draw();
            }

            Window.window.DrawText("SCORE: " + Globals.levelScore, 5, 5);
            Globals.leaderBoardUI.Draw();

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
