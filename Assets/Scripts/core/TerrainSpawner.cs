using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.core {
    class TerrainSpawner {
        const float MAX_Y_SCALE = 5f;
        const float SPAWNER_PROBABILITY = 0.6f;
        const String BRICK_PATH = "Perfab/brick";

        GameObject brick;
        Transform stage;

        public TerrainSpawner(Transform stage) {
            brick = Resources.Load(BRICK_PATH) as GameObject;
            this.stage = stage;
        }

        public void spawn(Rect rect) {
            // 遍历矩形区域，生成地形
            for (float x = rect.x; x < rect.xMax; x++) {
                for (float z = rect.y; z < rect.yMax; z++) {
                    float p = UnityEngine.Random.Range(0, 1);
                    if (p > SPAWNER_PROBABILITY) {
                        GameObject tile = GameObject.Instantiate(brick, stage, false) as GameObject;
                        // 随机 y 长度
                        float yScale = UnityEngine.Random.Range(1, MAX_Y_SCALE);
                        // 设置 tile 的坐标
                        tile.transform.InverseTransformPoint(x, yScale * 0.5f, z);
                    }
                }
            }
        }
    }
}
