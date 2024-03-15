using Unity.VisualScripting;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    #region Singleton
    public static MainMenuManager Instance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }
    }
    #endregion
    
    public Transform Container;
    
    public Transform Spawner;
    public Transform[] prefabs;

    public int RandomSecondsForBlockSpawn;
    public float[] BlockRotatingSpeed;
    
    public int NumberOfBlocks;
    private int BlocksInScene => FindObjectsOfType<DroppingBlockController>().Length;

    private void Update() {
        if (NumberOfBlocks > BlocksInScene)
            Invoke("SpawnBlock", Random.Range(0, RandomSecondsForBlockSpawn));
    }

    private void SpawnBlock()
    {
        var spawnerScale = Spawner.localScale;
        var xScale = spawnerScale.x / 2;
        var zScale = spawnerScale.z / 2;
        
        var xPos = new Vector3(Random.Range(-xScale, xScale), 0, 0);
        var yPos = new Vector3(0, Random.Range(0, 25), 0);
        var zPos = new Vector3(0, 0, Random.Range(-zScale, zScale));
        
        var position = Spawner.position + xPos + yPos + zPos;
        
        var prefab = prefabs[Random.Range(0, prefabs.Length)];
        var block = Instantiate(prefab, position, Quaternion.identity, Container);
        block.AddComponent<DroppingBlockController>();
    }
}
