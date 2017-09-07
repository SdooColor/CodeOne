using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.core {
    class Map {

        MAP_DATA data;

        Rect viewport;
        // 当前的地图内容
        GameObject[,] canvas;

        bool forceRender;

        public Map() {
        }

        public void load() {
            data = new MAP_DATA();
            data.tiles = new Dictionary<string, Vector3?[,]>();
            viewport = new Rect(0, 0, MAP_DATA.WIDTH, MAP_DATA.HEIGHT);
            canvas = new GameObject[MAP_DATA.WIDTH * 3, MAP_DATA.HEIGHT * 3];

            // 第一次渲染需要强制执行
            forceRender = true;
        }

        public void save() {
        }

        public void followTarget(Transform target) {
            int indexX = (int)Mathf.Floor(target.position.x / MAP_DATA.WIDTH);
            int indexY = (int)Mathf.Floor(target.position.z / MAP_DATA.HEIGHT);

            if (forceRender) {
                viewport.x = indexX;
                viewport.y = indexY;
                render();
                forceRender = false;
            }
            else if (viewport.x != indexX * MAP_DATA.WIDTH || viewport.y != indexY * MAP_DATA.HEIGHT) {
                viewport.x = indexX * MAP_DATA.WIDTH;
                viewport.y = indexY * MAP_DATA.HEIGHT;

                render();
            }
        }

        void render() {
            int indexX = (int)viewport.x / MAP_DATA.WIDTH;
            int indexY = (int)viewport.y / MAP_DATA.HEIGHT;
            int canvasIndexX, canvasIndexY;
            int canvasC, canvasR;

            for (int x = indexX - 1; x <= indexX + 1; x++) {
                for (int y = indexY - 1; y <= indexY + 1; y++) {
                    string key = x + "_" + y;

                    // 数据还未生成
                    if (!data.tiles.ContainsKey(key)) {
                        data.tiles.Add(key, MAP_DATA.randomSpawn(x, y));
                    }

                    // 根据地形数据生成 gameObject
                    GameObject[,] gameobjects = Globals.terrainSpawner.spawn(data.tiles[key]);

                    canvasIndexX = x - indexX + 1;
                    canvasIndexY = y - indexY + 1;

                    for (int c = 0; c < MAP_DATA.WIDTH; c++) {
                        for (int r = 0; r < MAP_DATA.HEIGHT; r++) {
                            canvasC = c + canvasIndexX * MAP_DATA.WIDTH;
                            canvasR = r + canvasIndexY * MAP_DATA.HEIGHT;
                            if (canvas[canvasC, canvasR]) {
                                GameObject.Destroy(canvas[canvasC, canvasR]);
                            }

                            canvas[canvasC, canvasR] = gameobjects[c, r];
                        }
                    }
                }
            }
        }

        public struct MAP_DATA {
            public const int WIDTH = 10;
            public const int HEIGHT = 10;

            public Dictionary<string, Vector3?[,]> tiles;

            public static Vector3?[,] randomSpawn(int indexX, int indexY) {
                Vector3?[,] tiles = new Vector3?[WIDTH, HEIGHT];

                int x, y;
                for (int c = 0; c < WIDTH; c++) {
                    for (int r = 0; r < HEIGHT; r++) {
                        Boolean hasbrick = UnityEngine.Random.Range(0f, 1f) > 0.8f;
                        x = c + indexX * WIDTH;
                        y = r + indexY * HEIGHT;
                        if (hasbrick) {
                            float height = Mathf.Floor(UnityEngine.Random.Range(1, 4));
                            tiles[c, r] = new Vector3(x, height, y);
                        }
                        else {
                            tiles[c, r] = new Vector3(x, 1, y);
                        }
                    }
                }
                return tiles;
            }
        }
    }
}
