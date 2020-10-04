using LD47.Levels;
using LD47.Ships;
using LD47.Weapons;
using OpenTK;
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

        private Level l;
        public List<DrawnButton> buttons = new List<DrawnButton>();

        public Radar radar = new Radar();
        public Player player = new Player(Enums.Nation.Brittain);



        public Game(Window window)
        {
            this.window = window;
            OnLoad();
            Globals.player = player;
        }

        public void OnLoad()
        {
            // Check if a savestate exists already
            if (FileHandler.FileExists("data/save.state"))
            {
                try
                {
                    Globals.state = FileHandler.Read<State>("data/save.state");
                }
                catch (Exception e)
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
                }
                catch (Exception e)
                {
                    Globals.Logger.Log(e.Message, LogLevel.ERROR);
                }
            }

            // Create leaderBoardUI
            Globals.leaderBoardUI = new LeaderBoardUI(50, 250, Globals.state.Highscores);
            
            CreateMainMenu();
        }

        public void Update(double delta)
        {
            Globals.delta = delta;
            //Updating logic
            switch (Globals.gamesState)
            {
                case Enums.GamesState.Playing:
                    if (player.health <= 0)
                    {
                        PlayerDied();
                        return;
                    }
                    player.Update(delta);

                    l.Update();
                    break;
                case Enums.GamesState.MainMenu:
                    Hotkey.Type();
                    break;
            }
        }

        public void StartLevel<T>(Enums.Nation playernation)
        {
            
            player = new Player(playernation);
            Globals.player = player;
            Globals.levelScore = 0;
            Globals.currentLevel = (Level)Activator.CreateInstance(typeof(T), new object[] { });
            l = Globals.currentLevel;
            Globals.gamesState = Enums.GamesState.Playing;
            Globals.difficulty = 0.5;
            buttons.Clear();
        }

        public void PlayerDied()
        {
            if (Globals.playerName == "Type to insert a name")
            {
                Globals.playerName = "AAA";
            }
            Globals.leaderBoardUI.AddToLeaderboard(new Score(Globals.playerName, Globals.levelScore));
            Globals.levelScore = 0;
            Globals.gamesState = Enums.GamesState.MainMenu;
            CreateMainMenu();
        }

        public void CreateMainMenu()
        {
            buttons.Add(new DrawnButton("Level 1", 1920 / 2 - 200, 50, 400, 100, () => StartLevel<LondonToDortmund>(Enums.Nation.Brittain), 1, 0.05f, 0.05f, 0.05f));
            buttons.Add(new DrawnButton("Level 2", 1920 / 2 - 200, 250, 400, 100, () => StartLevel<JapanToUSA>(Enums.Nation.Japan), 1, 0.05f, 0.05f, 0.05f));
        }

        private void RemoveOverdraw()
        {
            Sprite s = new Sprite(1920 / 2 - 400, 1080, 0, 1);
            s.Draw(0, 0, false, 0, 0, 0, 0, 1);
            s.Draw(1920 / 2 + 400, 0, false, 0, 0, 0, 0, 1);
            s = new Sprite(800, 45, 0, 1);
            s.Draw(1920 / 2 - 400, 0, false, 0, 0, 0, 0, 1);
            s.Draw(1920 / 2 - 400, 1080 - 45, false, 0, 0, 0, 0, 1);
        }

        public void Draw()
        {
            //Do all you draw calls here
            switch (Globals.gamesState)
            {
                case Enums.GamesState.Playing: // PLAYING
                    l.draw();
                    foreach (Projectile projectile in Globals.currentLevel.projectiles)
                    {
                        projectile.Draw();
                    }

                    player.Draw();

                    RemoveOverdraw();

                    Window.window.DrawText("SCORE: " + Globals.levelScore, 5, 5, false, Globals.ArcadeFont);
                    Window.window.DrawText("HEALTH: ", 5, 55, false, Globals.ArcadeFont);

                    for(int i = 0; i < Globals.player.health; i++)
                    {
                        Sprite s = new Sprite(32, 32, 0, 3);
                        s.Draw(175 + i*35, 55);
                    }

                    Window.window.DrawText("BOMBS: " + Globals.player.BombsLeft, 5, 105, false, Globals.ArcadeFont);

                    Window.window.DrawText("Last bomb dropped", 1920-550, 10, false, Globals.ArcadeFont);
                    Window.window.DrawText(Globals.lastBombDistance + "km", 1920 - 550, 45, false, Globals.ArcadeFont);
                    Window.window.DrawText("from " + Globals.lastBombLocation, 1920 - 550, 80, false, Globals.ArcadeFont);

                    Window.window.DrawText(Globals.currentLevel.date, 1920 - 400, 1080 - 60, false, Globals.ArcadeFont);
                    radar.Draw();
                    Globals.leaderBoardUI.Draw();
                    break;
                case Enums.GamesState.MainMenu:
                    Window.window.DrawText("NAME: " + Globals.playerName, 5, 5, false, Globals.ArcadeFont);
                    break;
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
