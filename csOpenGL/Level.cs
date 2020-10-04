using LD47.Powerup;
using LD47.Ships;
using LD47.Waves;
using LD47.Weapons;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47
{
    public class Level
    {
        public const int gameHeight = 1000;
        public Texture background, clouds;
        public double timePassed = 0;
        public List<EnemyWave> waves;
        public List<Plane> planes;
        public List<Projectile> projectiles;
        public List<Pickupable> powerups;
        public Hotkey dropBom = new Hotkey(false).AddKey(OpenTK.Input.Key.F);
        public string date;
        public Dictionary<string, Vector2> Locations { get; set; }
        public double KilometerScale { get; set; }
        protected double Scale { get => background.totH / KilometerScale ; }

        public Level(int background, Dictionary<string, Vector2> locations, double kilometerScale)
        {
            Locations       = locations;
            this.background = Textures.Get(background);
            clouds          = Textures.Get(7);
            planes          = new List<Plane>();
            projectiles     = new List<Projectile>();
            powerups        = new List<Pickupable>();
            KilometerScale  = kilometerScale;
            AddWaves();
        }

        public virtual void AddWaves()
        {
            waves = new List<EnemyWave>();
            waves.Add(new BasicWave<TestEnemy>(120, 25, 5, new Vector2(200, 45), (int i, double timeAlive, int max) => { Vector2 v = (new Vector2(max / 2 - i, max)); v.Normalize(); return (3 * v); }));
            waves.Add(new AAWave(400, 80, 2 , new Vector2(0,0), Textures.GERAABoat));
        }

        public void addPlane(Plane p)
        {
            planes.Add(p);
        }

        public void Update()
        {
            timePassed += Globals.delta;

            if (dropBom.IsDown() && ( Globals.player.BombsLeft > 0 || timePassed >= background.totH - gameHeight)) // Matthijs: I'm being nice and won't allow the player to be softlocked
            {
                // Get player location
                Player player = Globals.player;
                float playerMapX = player.position.X - 560;
                float playerMapY = 1080 - player.position.Y - 45;

                // Get the actual Y value against the scrolled sprite
                float playerRealY = (float)timePassed + playerMapY;

                // Get the distances to each location
                var tuples = Locations.Select((location) => Tuple.Create(location.Key, Math.Sqrt(Math.Pow(location.Value.X - playerMapX, 2) + Math.Pow(location.Value.Y - playerRealY, 2))));
                // Order the list
                tuples = tuples.OrderBy((tuple) => tuple.Item2);
                // Get the closest
                Tuple<string, double> closestLocation = tuples.First();
                double distance = Math.Round(closestLocation.Item2 / Scale, 1);
                // Write data to Globals
                Globals.lastBombDistance = distance;
                Globals.lastBombLocation = closestLocation.Item1;

                player.BombsLeft--;

                if(timePassed >= background.totH - gameHeight)
                {
                    ResetLevel();
                }

                Plane planeToDelete = null;
                foreach(Plane plane in planes)
                {
                    // You are only able to bomb AA
                    if (plane is AA && Globals.checkCol(player.position.X, player.position.Y, player.w, player.h, plane.position.X, plane.position.Y, plane.w, plane.h))
                    {
                        // Trigger death
                        plane.OnDeath();
                        planeToDelete = plane;
                        break;
                    }
                }
                if (planeToDelete != null)
                {
                    planes.Remove(planeToDelete);
                }
                
            }

            Globals.stoppedScrolling = false;
            // background updating
            if (timePassed > background.totH-gameHeight)
            {
                Globals.stoppedScrolling = true;
                timePassed = background.totH - gameHeight;
            }
            if(timePassed < 0)
            {
                timePassed = 0;
            }
            // Enemy spawning
            for(int i = 0; i < waves.Count; i++)
            {
                if(waves[i].update(timePassed))
                {
                    waves.RemoveAt(i);
                    i--;
                }
            }
            for (int i = planes.Count - 1; i >= 0; i--)
            {
                if(planes[i].health <= 0)
                {
                    planes[i].OnDeath();
                    planes.RemoveAt(i);
                    continue;
                }
                planes[i].Update(Globals.delta);
                if(!Globals.checkCol(planes[i].position.X, planes[i].position.Y, planes[i].w, planes[i].h, 1920/2 - 400, 45, 800, gameHeight))
                {
                    planes.RemoveAt(i);
                    continue;
                }
            }

            for (int i = powerups.Count - 1; i >= 0; i--)
            {
                powerups[i].Update();
            }

            for(int i = projectiles.Count-1; i >= 0; i--)
            {
                if(projectiles[i].Update(Globals.delta))
                {
                    projectiles.RemoveAt(i);
                }
            }
        }

        public virtual void ResetLevel()
        {
            Globals.levelScore += (ulong)(1000 * Globals.difficulty);
            Globals.difficulty += 0.25;
            planes = new List<Plane>();
            projectiles = new List<Projectile>();
            timePassed = 0;
            AddWaves();
            if (Globals.player.health < 5)
            {
                Globals.player.health = 5;
            }
            Globals.player.BombsLeft = 5;

        }

        public void draw()
        {
            background.AddToList(1920 / 2 - 400, 45, 1, 1, 1, 1, (int)timePassed , background.totW, gameHeight);
            foreach (Plane p in planes)
            {
                if (p is AA)
                {
                    p.Draw();
                }
            }
            clouds.AddToList(1920 / 2 - 400, 45, 0, 0, 0, 0.2f, (int)(timePassed * 1.5f) + 50, background.totW, gameHeight);
            clouds.AddToList(1920 / 2 - 400, 45, 1, 1, 1, 1, (int)(timePassed * 1.4f), background.totW, gameHeight);
            foreach (Plane p in planes)
            {
                if (!(p is AA))
                {
                    p.Draw();
                }
            }

            foreach (Pickupable pickupable in powerups)
            {
                pickupable.Draw();
            }

            foreach (Projectile p in projectiles)
            {
                p.Draw();
            }
        }

    }
}
