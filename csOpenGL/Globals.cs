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

        public static int Width, Height;
        public static QFont buttonFont = new QFont("Fonts/arial.ttf", 16, new QuickFont.Configuration.QFontBuilderConfiguration(true));
        public static double delta, difficulty = 1;
        public static Level currentLevel;
        public static Player player;

        public static List<Projectile> projectiles;

        public static bool checkCol(int x1, int y1, int w1, int h1, int x2, int y2, int w2, int h2)
        {
            return x1 - w2 < x2 && x1 + w1 > x2 && y1 - h2 < y2 && y1 + h1 > y2;
        }
    }
}
