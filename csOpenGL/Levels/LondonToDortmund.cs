using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Levels
{
    class LondonToDortmund : Level
    {

        public LondonToDortmund() : base(Textures.MapLondonDortmund)
        {

        }

        public override void AddWaves()
        {
            waves = new List<EnemyWave>();

        }

    }
}
