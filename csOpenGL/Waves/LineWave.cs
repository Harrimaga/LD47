using LD47.Ships;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LD47.Ships.EnemyPlane;

namespace LD47.Waves
{
    public class LineWave<T> : EnemyWave
    {

        public Vector2 spawnPosition, offset;
        public Movement movement;

        public LineWave(double startTime, double interval, int spawnAmount, Vector2 position, Vector2 offset, Movement movement) : base(startTime, interval, spawnAmount)
        {
            spawnPosition = position;
            this.movement = movement;
            this.offset = offset;
        }

        public override void SpawnNext()
        {
            Globals.currentLevel.addPlane((Plane)Activator.CreateInstance(typeof(T), new object[] { spawnPosition + offset*(float)(spawned/Globals.difficulty), movement, spawned, spawnAmount }));
        }

    }
}
