using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47
{
    public class LeaderBoardUI
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Score[] Scores { get; set; }

        public LeaderBoardUI(int x, int y, Score[] scores)
        {
            X = x;
            Y = y;
            Scores = scores;
        }

        public void Draw()
        {
            int currentX = X;
            int currentY = Y;

            foreach(Score score in Scores)
            {
                Window.window.DrawText(score.Name, currentX, currentY, false, Globals.buttonFont);
                Window.window.DrawText(score.Points.ToString(), currentX + 50, currentY, false, Globals.buttonFont);
                currentY += 50;
            }
            
        }
    }
}
