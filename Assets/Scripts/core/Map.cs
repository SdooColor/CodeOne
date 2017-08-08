using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.core {
    class Map {
        // 视窗
        readonly Rect viewport = new Rect(0,0, 10f,10f);

        // 渲染区域
        readonly Rect renderRect = new Rect();
        // 上一次的渲染范围
        readonly Rect lastRenderRect = new Rect();

        // 当前的地图内容
        readonly Dictionary<string, GameObject[]> canvas = new Dictionary<string, GameObject[]>();
        readonly Dictionary<string, Boolean> canvasRenderFlag = new Dictionary<string, bool>();

        readonly Vector2 helpPoint = new Vector2();

        MAP_DATA data;

        public Map() {
        }

        public void load() {
        }

        public void save() {
        }

        void render() {
            // 获取渲染区域
            // 坐标要进行转换，获取 tile 的坐标
            renderRect.Set(
                Mathf.Floor(viewport.x / MAP_DATA.TILE_WIDTH),
                Mathf.Floor(viewport.y / MAP_DATA.TILE_HEIGHT),
                Mathf.Ceil(viewport.xMax / MAP_DATA.TILE_WIDTH),
                Mathf.Ceil(viewport.yMax / MAP_DATA.TILE_HEIGHT)
                );

            for (float x = renderRect.x; x < renderRect.xMax; x++) {
                for (float y = renderRect.y; y < renderRect.yMax; y++) {
                    string key = x + "_" + y;
                    if (!data.tiles.ContainsKey(key)) {
                        data.tiles.Add(key, MAP_DATA.randomSpawn(x, y));
                    }

                    if (!canvas.ContainsKey(key)) {
                        canvas.Add(key, null);
                    }
                }
            }

            foreach (string key in canvas.Keys) {
                string[] keys = key.Split('_');
                helpPoint.Set(System.Convert.ToSingle(keys[0]), System.Convert.ToSingle(keys[1]));

                if (renderRect.Contains(helpPoint)) {
                    if (canvas[key] == null) {
                        renderTiles(key, data.tiles[key]);
                    }
                    else {
                        // 已渲染
                    }
                }
                // 移除
                else {
                    removeTiles(canvas[key]);
                    canvas.Remove(key);
                }
            }
        }

        void renderTiles(string key, Vector3 [] data) {
            canvas.Add(key, Globals.terrainSpawner.spawn(data));
        }

        void removeTiles(GameObject [] bricks) {
            foreach (GameObject brick in bricks) {
                GameObject.DestroyObject(brick);
            }
        }
    }

    public struct MAP_DATA {
        public const float TILE_WIDTH = 10f;
        public const float TILE_HEIGHT = 10f;

        public Dictionary<string, Vector3 []> tiles;

        public static Vector3[] randomSpawn(float x, float y) {
            Vector3[] tiles = new Vector3[(int)(TILE_WIDTH * TILE_HEIGHT)];

            int index = 0;
            for (; x < x + TILE_WIDTH; x++) {
                for (; y < y + TILE_HEIGHT; y++) {
                    Boolean hasBrick = UnityEngine.Random.Range(0, 1) > 0.8;
                    float height = Mathf.Floor(UnityEngine.Random.Range(1, 4));
                    tiles[index] = new Vector3(y, height, x);
                }
            }
            return tiles;
        }
    }
}
