using UnityEngine;

public class GizmosArea : MonoBehaviour {
    [Tooltip("Set 'White' as default")]
    [SerializeField] private Color _color = Color.white;
    
    [SerializeField] private Vector3 size;

    private void OnDrawGizmos() {
        Gizmos.color = _color;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
