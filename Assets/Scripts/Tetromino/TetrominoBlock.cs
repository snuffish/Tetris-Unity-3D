using Unity.VisualScripting;
using UnityEngine;

public class TetrominoBlock : MonoBehaviour {
    private Renderer _renderer;
    private Color _defaultColor;
    private bool _marked;
    private bool _exploded;

    public bool IsMarked => _marked;
    public bool HasExploded => _exploded;

    public void Marked(bool state) {
        _marked = state;
    }

    public void Explode() {
        if (HasExploded) return;
        _exploded = true;
        
        var component = transform.AddComponent<ExplodeTetrominoBlock>();
        component.ExplosionPosition = transform.position + Vector3.back;
        component.ExplodeOnStart = true;
        component.DestroyInsteadOfExplode = true;
    }

    private void Awake() {
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
    }

    private void Update() {
        _renderer.material.color = IsMarked ? Color.red : _defaultColor;
    }
}