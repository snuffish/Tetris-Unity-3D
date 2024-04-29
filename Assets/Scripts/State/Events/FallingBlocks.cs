using Unity.VisualScripting;
using UnityEngine;

namespace State.Events
{
    public class FallingBlocks : MonoBehaviour
    {
        public float NumberOfBlocks;
        public float BlocksInScene;
        public float RandomSecondsForBlockSpawn;

        public Transform[] Prefabs;

        public Transform Spawner;
        public Transform Container;

        private void Awake()
        {
            // Container = GameObject.Find("FallingBlocksContainer").transform;
            // Spawner = Container.GetComponentsInChildren();
            // var child = Container.GetComponentInChildren<GameObject>();
            // if (child.CompareTag("Spawner")) {
            //     Debug.Log("1111111111111111");
            // }
        }

        private void Update()
        {
            if (NumberOfBlocks > BlocksInScene) {
                Invoke("SpawnBlock", Random.Range(0, RandomSecondsForBlockSpawn));
                BlocksInScene++;
            }
        }

        public Vector3 GetSpawnPosition()
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

        // ReSharper disable Unity.PerformanceAnalysis
        public void SpawnBlock()
        {
            Vector3 position = GetSpawnPosition();

            var prefab = Prefabs[Random.Range(0, Prefabs.Length)];
            var block = Instantiate(prefab, position, Quaternion.identity, Container);
            block.AddComponent<FallingBlocks>();
        }
    }
}