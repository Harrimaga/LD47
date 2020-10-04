using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47
{
    [Serializable]
    public class State
    {
        public ulong ScoreAccumulated { get; set; }
        public List<Enums.Nation> NationsUnlocked { get; set; }
        public Score[] Highscores { get; set; }
        public string Name { get; set; }

        // Used when initializing the state
        public State()
        {
            ScoreAccumulated = 0;
            NationsUnlocked  = new List<Enums.Nation>{ Enums.Nation.Brittain };
            Highscores       = new Score[] 
            {
                new Score("ACE", 75000),
                new Score("BOB", 60000),
                new Score("DAB", 50000),
                new Score("TIM", 40000),
                new Score("MAT", 35000),
                new Score("ILN", 27500),
                new Score("GAY", 20000),
                new Score("HAM", 12500),
                new Score("REY", 8000),
                new Score("YEE", 5000),
            };
            Name = "Type to insert a name";
        }
    }
    [Serializable]
    public class Score
    {
        public string Name { get; set; }
        public ulong Points { get; set; }

        public Score(string name, ulong points)
        {
            Name = name;
            Points = points;
        }
    }
}
