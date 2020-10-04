using LD47.Ships;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47
{
    public class Radar
    {

        Sprite planeSprite = new Sprite(5, 5, 0, 1);
        Sprite bg = new Sprite(82, 82, 0, Textures.RadarBackground);

        public Radar()
        {
            
        }

        public void Update()
        {
            
        }

        public void Draw()
        {
            bg.Draw(1555, 800, false, 0, 1, 1, 1, 1);

            foreach (Plane plane in Globals.currentLevel.planes)
            {
                Vector2 radarPos = LevelToRadarCoords(plane);
                planeSprite.Draw(radarPos.X, radarPos.Y, false, 0, 1, plane is AA ? 0 : 1, plane is AA ? 0 : 1, 1);
            }

            Vector2 playerRadarPos = LevelToRadarCoords(Globals.player);
            planeSprite.Draw(playerRadarPos.X, playerRadarPos.Y, false, 0, 0, 1, 0, 1);
        }

        public Vector2 LevelToRadarCoords(Plane plane)
        {
            Vector2 planePos = plane.position;
            return new Vector2(1500 + planePos.X / 10, 800 + planePos.Y / (10 * 1.2375f));
        }
    }
}
