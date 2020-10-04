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
            date = "June 12th 1943";
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
            if (Globals.difficulty >= 2)
                waves.Add(new AAWave(1795, 1, 0, new Vector2(500, -30), Textures.GERAABoat));


            waves.Add(new LineWave<EnemyUSAPlane>(2000, 0, 5, new Vector2(190, -10), new Vector2(100, 0), (int i, double timeAlive, int max) => { return new Vector2(0, 4.5f); }));
            waves.Add(new AAWave(2200, 1, 0, new Vector2(450, -30), Textures.GERAABoat));
            waves.Add(new AAWave(2200, 1, 0, new Vector2(75, -30), Textures.GERAABoat));
            if (Globals.difficulty >= 1.5)
                waves.Add(new AAWave(2210, 1, 0, new Vector2(550, -30), Textures.GERAABoat));
            if (Globals.difficulty >= 2)
                waves.Add(new AAWave(2270, 1, 0, new Vector2(430, -30), Textures.GERAABoat));
            if (Globals.difficulty >= 3)
                waves.Add(new AAWave(2290, 1, 0, new Vector2(530, -30), Textures.GERAABoat));

            waves.Add(new AAWave(3200, 1, 0, new Vector2(450, -30), Textures.GERAABoat));
            waves.Add(new AAWave(3200, 1, 0, new Vector2(75, -30), Textures.GERAABoat));
            if (Globals.difficulty >= 1.5)
                waves.Add(new AAWave(3210, 1, 0, new Vector2(550, -30), Textures.GERAABoat));
            if (Globals.difficulty >= 2)
                waves.Add(new AAWave(3230, 1, 0, new Vector2(600, -30), Textures.GERAABoat));
            if (Globals.difficulty >= 3)
                waves.Add(new AAWave(3235, 1, 0, new Vector2(350, -30), Textures.GERAABoat));

            waves.Add(new BasicWave<EnemyUSAPlane>(4100, 20, 5, new Vector2(0, 200), (int i, double timeAlive, int max) => Circle(i, timeAlive, max, new Vector2(3, -1))));
            waves.Add(new BasicWave<EnemyUSAPlane>(4300, 20, 5, new Vector2(790, 200), (int i, double timeAlive, int max) => Circle(i, -timeAlive, max, new Vector2(-3, -1))));

            waves.Add(new LineWave<EnemyUSAPlane>(4600, 0, 7, new Vector2(90, -10), new Vector2(100, 0), (int i, double timeAlive, int max) => { return new Vector2(-1, 4f); }));
            waves.Add(new LineWave<EnemyUSAPlane>(4800, 0, 7, new Vector2(90, -10), new Vector2(100, 0), (int i, double timeAlive, int max) => { return new Vector2(1, 4f); }));

            waves.Add(new AAWave(5000, 1, 0, new Vector2(750, -30), Textures.GERAAGround));
            waves.Add(new AAWave(5000, 1, 0, new Vector2(35, -30), Textures.GERAAGround));
            if(Globals.difficulty >= 2)
            {

                waves.Add(new AAWave(5250, 1, 0, new Vector2(755, -30), Textures.GERAAGround));
                waves.Add(new AAWave(5250, 1, 0, new Vector2(30, -30), Textures.GERAAGround));
            }
            waves.Add(new LineWave<EnemyUSAPlane>(6000, 0, 7, new Vector2(90, -10), new Vector2(100, 0), (int i, double timeAlive, int max) => { return new Vector2(-1, 4f); }));
            waves.Add(new LineWave<EnemyUSAPlane>(6000, 0, 7, new Vector2(90, -10), new Vector2(100, 0), (int i, double timeAlive, int max) => { return new Vector2(1, 4f); }));
            waves.Add(new AAWave(6300, 1, 0, new Vector2(700, -30), Textures.GERAABoat));
            waves.Add(new AAWave(6310, 1, 0, new Vector2(85, -30), Textures.GERAAGround));
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
            baseDirection.X /= (float)(1 + timeAlive * archFactor / 90);
            baseDirection.Normalize();
            return baseDirection * 4;
        }

        private Vector2 Circle(int i, double timeAlive, int max, Vector2 baseDirection)
        {
            float c = (float)Math.Cos(timeAlive / 60);
            float s = (float)Math.Sin(timeAlive / 60);
            return new Vector2(baseDirection.X * c + baseDirection.Y * s, baseDirection.X * s + baseDirection.Y * c);
        }

    }
}
