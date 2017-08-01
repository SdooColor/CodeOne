using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.core {
    class TerrainSpawner {
        public void spawn(Transform center) {
            GameObject brick = GameObject.FindWithTag("brick");
            GameObject.Instantiate(brick, center, true);
        }
    }
}
