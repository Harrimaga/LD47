using LD47.Powerup;
using LD47.Ships;
using LD47.Weapons;
using OpenTK.Graphics.OpenGL;
using QuickFont;
using Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47
{
    public class Globals
    {
        public static ulong levelScore = 0;
        public static State state;
        public static Logger Logger = new Logger("data/log.txt");
        public static LeaderBoardUI leaderBoardUI;
        public static string playerName = "Type to insert a name";
        public static string lastBombLocation;
        public static double lastBombDistance;
        public static Random random = new Random();
        public static PowerupHandler powerupHandler = new PowerupHandler();
        public static int Width, Height;
        public static QFont buttonFont = new QFont("Fonts/arial.ttf", 16, new QuickFont.Configuration.QFontBuilderConfiguration(true));
        public static QFont ArcadeFont = new QFont("Fonts/ARCADE_I.TTF", 22, new QuickFont.Configuration.QFontBuilderConfiguration(true));
        public static double delta, difficulty = 0.5;
        public static Level currentLevel;
        public static Player player;
        public static Enums.GamesState gamesState = Enums.GamesState.MainMenu;
        public static bool stoppedScrolling = false;

        public static List<Projectile> projectiles;

        public static bool checkCol(int x1, int y1, int w1, int h1, int x2, int y2, int w2, int h2)
        {
            return x1 - w2 < x2 && x1 + w1 > x2 && y1 - h2 < y2 && y1 + h1 > y2;
        }

        public static bool checkCol(float x1, float y1, float w1, float h1, float x2, float y2, float w2, float h2)
        {
            return x1 - w2 < x2 && x1 + w1 > x2 && y1 - h2 < y2 && y1 + h1 > y2;
        }
    }
}
