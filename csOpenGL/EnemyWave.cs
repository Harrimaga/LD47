﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47
{
    class EnemyWave
    {

        public double startTime, interval, spawnTimer = 0;
        public int spawnAmount, spawned = 0;
        public bool spawning = false;

        public EnemyWave(double startTime, double interval, int spawnAmount)
        {
            this.startTime = startTime;
            this.interval = interval;
            this.spawnAmount = (int)(spawnAmount * Globals.difficulty);
        }

        /// <summary>
        /// returns true is it is done spawning
        /// </summary>
        public virtual bool update(double time)
        {
            if(spawning)
            {
                spawnTimer += Globals.delta;
                if(spawnTimer >= interval)
                {
                    spawnTimer -= interval;
                    SpawnNext();
                    spawned++;
                    return spawned >= spawnAmount;
                }
            }
            else if(time >= startTime)
            {
                spawning = true;
                SpawnNext();
                spawned++;
                spawnTimer = time - startTime;
                return spawned >= spawnAmount;
            }
            return false;
        }

        public virtual void SpawnNext()
        {
            
        }

    }
}