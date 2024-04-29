using Tetromino;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Settings", menuName = "SnuffTool/Settings/Create", order = 0)]
    public class GameSettings : ScriptableObject
    {
        public Transform[] Prefabs;

        public int RandomSecondsForBlockSpawn;
        public float[] BlockRotatingSpeed;

        public int NumberOfBlocks;
        private int BlocksInScene => FindObjectsOfType<DroppingBlockController>().Length;

        [Range(0, 100)] public float YAxisSpawner = 60;

        [Range(0, -100)] public float YAxisRespawner = -40;

        [Range(0, 100)] public float FallingSpeed = 50f;
    }
}
