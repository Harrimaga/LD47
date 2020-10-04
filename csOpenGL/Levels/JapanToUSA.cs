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
    class JapanToUSA : Level
    {

        public JapanToUSA() :
            base(
                Textures.JapanUSAMap
                , new Dictionary<string, Vector2>
                {
                    { "Osaka", new Vector2(495, 7450-7192) },
                    { "Nagoya", new Vector2(463, 7450-7126) },
                    { "Tokyo", new Vector2(436, 7450-6989) },
                    { "Honolulu", new Vector2(575, 7450-4072) },
                    { "Lahaina", new Vector2(619, 7450-3969) },
                    { "Hilo", new Vector2(717, 7450-3847) },
                    { "San Fransisco", new Vector2(306, 7450-2322) },
                    { "Los Angeles", new Vector2(532, 7450-2125) },
                    { "San Diego", new Vector2(605, 7450-2067) },
                    { "Las Vegas", new Vector2(402, 7450-1975) },
                    { "Dallas", new Vector2(601, 7450-1097) },
                    { "Houston", new Vector2(767, 7450-1031) },
                    { "Chicago", new Vector2(54, 7450-661) },
                    { "Detroit", new Vector2(33, 7450-443) },
                    { "Philadelphia", new Vector2(203, 7450-47) },
                }
                , 11400
            )
        {
            date = "December 7th 1941";
        }

        public override void AddWaves()
        {
            waves = new List<EnemyWave>();
            waves.Add(new LineWave<EnemyUSAPlane>(60, 0, 3, new Vector2(290, -10), new Vector2(100, 0), (int i, double timeAlive, int max) => { return new Vector2(0, 3); }));
            if (Globals.difficulty >= 1.75)
            {
                waves.Add(new AAWave(240, 1, 0, new Vector2(200, -30), Textures.GERAABoat));
            }
            waves.Add(new AAWave(300, 1, 0, new Vector2(550, -30), Textures.GERAABoat));
            waves.Add(new AAWave(600, 1, 0, new Vector2(100, -30), Textures.GERAABoat));
            waves.Add(new BasicWave<EnemyUSAPlane>(900, 45, 6, new Vector2(0, 200), (int i, double timeAlive, int max) => ArchDown(i, timeAlive, max, new Vector2(max/2 + i * 2, max), 2)));
            if (Globals.difficulty >= 1.5)
            {
                waves.Add(new AAWave(1180, 1, 0, new Vector2(250, -30), Textures.GERAABoat));
            }
            waves.Add(new BasicWave<EnemyUSAPlane>(1250, 45, 6, new Vector2(790, 200), (int i, double timeAlive, int max) => ArchDown(i, timeAlive, max, new Vector2(-max / 2 + -i * 2, max), 2)));

            waves.Add(new AAWave(1600, 1, 0, new Vector2(200, -30), Textures.GERAABoat));
            if(Globals.difficulty >= 1.5)
                waves.Add(new AAWave(1655, 1, 0, new Vector2(750, -30), Textures.GERAABoat));
            if (Globals.difficulty >= 1.75)
                waves.Add(new AAWave(1725, 1, 0, new Vector2(350, -30), Textures.GERAABoat));
            waves.Add(new AAWave(1600, 1, 0, new Vector2(200, -30), Textures.GERAABoat));
            if (Globals.difficulty >= 2)
                waves.Add(new AAWave(1795, 1, 0, new Vector2(500, -30), Textures.GERAABoat));

        }

        private Vector2 Arch(int i, double timeAlive, int max)
        {
            Vector2 v = (new Vector2(max / 2 - i, max));
            v.Normalize();
            return (3 * v);
        }

        private Vector2 Arch(int i, double timeAlive, int max, Vector2 baseDirection)
        {
            Vector2 v = (new Vector2(max / 2 - i, max)) + baseDirection;
            v.Normalize();
            return (3 * v);
        }

        private Vector2 ArchDown(int i, double timeAlive, int max, Vector2 baseDirection, double archFactor = 1)
        {
            baseDirection.X /= (float)(1 + timeAlive * archFactor / 60);
            baseDirection.Normalize();
            return baseDirection * 4;
        }

    }
}
