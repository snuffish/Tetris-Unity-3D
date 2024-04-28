using Tetromino;
using Unity.VisualScripting;
using UnityEngine;

namespace State
{
    public class FallingBlocks : MonoBehaviour
    {
        public float NumberOfBlocks;
        public float BlocksInScene;
        public float RandomSecondsForBlockSpawn;
        private Transform[] Prefabs;

        public Transform Spawner;
        public Transform Container;

        private MonoBehaviour _instance;

        private void Awake()
        {
            _instance = this;
        }

        public void Update()
        {
            // NumberOfBlocks = State.GetVariableValue<float>(ref _instance, "NumberOfBlocks");
            // BlocksInScene = State.GetVariableValue<float>(ref _instance, "BlocksInScene");
            // Prefabs = State.GetVariableValue<Transform[]>(ref _instance, "Prefabs");
            // RandomSecondsForBlockSpawn = State.GetVariableValue(ref _instance, "RandomSecondsForBlockSpawn");

            if (NumberOfBlocks > BlocksInScene)
                    Invoke("SpawnBlock", Random.Range(0, RandomSecondsForBlockSpawn));
        }

        private Vector3 GetSpawnPosition()
        {
            var spawnerScale = Spawner.localScale;
            var xScale = spawnerScale.x / 2;
            var zScale = spawnerScale.z / 2;

            var xPos = new Vector3(Random.Range(-xScale, xScale), 0, 0);
            var yPos = new Vector3(0, Random.Range(0, 25), 0);
            var zPos = new Vector3(0, 0, Random.Range(-zScale, zScale));

            Vector3 position = Spawner.position + xPos + yPos + zPos;

            return position;
        }

        public void SpawnBlock()
        {
            Vector3 position = GetSpawnPosition();

            var prefab = Prefabs[Random.Range(0, Prefabs.Length)];
            var block = Instantiate(prefab, position, Quaternion.identity, Container);
            block.AddComponent<DroppingBlockController>();
        }
    }
}