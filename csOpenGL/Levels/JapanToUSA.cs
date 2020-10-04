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
                    { "London", new Vector2(420, 300) },
                    { "Middelburg", new Vector2(428, 6000-2981) },
                    { "Vlissingen", new Vector2(473, 6000-3008) },
                    { "Oostkapelle", new Vector2(342, 6000-3025) },
                    { "Antwerp", new Vector2(751, 6000-2418) },
                    { "Breda", new Vector2(316, 6000-2190) },
                    { "Tilburg", new Vector2(348, 6000-1991) },
                    { "Den Bosch", new Vector2(197, 6000-1811) },
                    { "Eindhoven", new Vector2(499, 6000-1714) },
                    { "Nijmegen", new Vector2(68, 6000-1474) },
                    { "Venlo", new Vector2(567, 6000-1273) },
                    { "Krefeld", new Vector2(610, 6000-958) },
                    { "Dusseldorf", new Vector2(722, 6000-843) },
                    { "Duisburg", new Vector2(508, 6000-855) },
                    { "Gelschenkirchen", new Vector2(399, 6000-742) },
                    { "Wuppertal", new Vector2(683, 6000-538) },
                    { "Dortmund", new Vector2(434, 6000-544) },
                    { "Wesel", new Vector2(243, 6000-923) },
                    { "Bocholt", new Vector2(49, 6000-925) },
                    { "Dumen", new Vector2(52, 6000-763) }
                }
                , 600
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
