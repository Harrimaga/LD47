using LD47.Ships;
using LD47.Waves;
using OpenTK;
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
            waves.Add(new BasicWave<TestEnemy>(120, 60, 4, new Vector2(400, -27), Arch));
            if(Globals.difficulty >= 2)
            {
                waves.Add(new AAWave(300, 1, 0, new Vector2(200, -30), Textures.GERAABoat));
            }
            waves.Add(new BasicWave<TestEnemy>(450, 35, 3, new Vector2(0, 200), (int i, double timeAlive, int max) => ArchDown(i, timeAlive, max, new Vector2(5, 2))));
            waves.Add(new BasicWave<TestEnemy>(462, 35, 3, new Vector2(800, 200), (int i, double timeAlive, int max) => ArchDown(i, timeAlive, max, new Vector2(-5, 2))));

            waves.Add(new AAWave(673, 1, 0, new Vector2(700, -30), Textures.GERAABoat));
            waves.Add(new LineWave<TestEnemy>(1200, 15, 6, new Vector2(50, -10), new Vector2(135, 0), (int i, double timeAlive, int max) => { return new Vector2(1, 3); }));
            waves.Add(new LineWave<TestEnemy>(1230, 15, 6, new Vector2(750, -10), new Vector2(-135, 0), (int i, double timeAlive, int max) => { return new Vector2(-1, 3); }));
            waves.Add(new AAWave(1900, 1, 0, new Vector2(550, -30), Textures.GERAAGround));
        }

        private Vector2 Arch(int i, double timeAlive, int max)
        {
            Vector2 v = (new Vector2(max / 2 - i, max));
            v.Normalize();
            return (3 * v);
        }

        private Vector2 ArchDown(int i, double timeAlive, int max, Vector2 baseDirection)
        {
            baseDirection.X /= (float)(1 + timeAlive / 60);
            baseDirection.Normalize();
            return baseDirection * 4;
        }

    }
}
