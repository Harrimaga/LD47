using LD47.Ships;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Waves
{
    class AAWave : EnemyWave
    {
        public Vector2 spawnPosition;
        public int tex;

        public AAWave(double startTime, double interval, int spawnAmount, Vector2 position, int tex) : base(startTime, interval, spawnAmount)
        {
            spawnPosition = position;
            this.tex = tex;
        }

        public override void SpawnNext()
        {
            Globals.currentLevel.addPlane(new AA(Enums.Nation.Germany, spawnPosition, tex, 32, 32));
        }
    }
}
