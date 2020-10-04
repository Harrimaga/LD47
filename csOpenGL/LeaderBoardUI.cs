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

        public void AddToLeaderboard(Score score)
        {
            for(int i = Scores.Length-1; i >= 0; i--)
            {
                if(score.Points > Scores[i].Points)
                {
                    if(i != Scores.Length-1)
                    {
                        Scores[i + 1] = Scores[i];
                    }
                    Scores[i] = score;
                }
            }
        }

        public void Draw()
        {
            int currentX = X;
            int currentY = Y;

            foreach(Score score in Scores)
            {
                Window.window.DrawText(score.Name, currentX, currentY, false, Globals.ArcadeFont);
                Window.window.DrawText(score.Points.ToString(), currentX + 100, currentY, false, Globals.ArcadeFont);
                currentY += 50;
            }
            
        }
    }
}
