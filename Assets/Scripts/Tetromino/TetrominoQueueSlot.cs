using UnityEngine;

public class TetrominoQueueSlot : MonoBehaviour {
    private void OnTriggerEnter(Collider hit) {
        Debug.Log($"Trigger on:{hit.name}");
    }
}