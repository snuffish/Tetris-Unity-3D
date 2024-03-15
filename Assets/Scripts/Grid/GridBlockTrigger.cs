using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GridBlockTrigger : MonoBehaviour {
    public bool OCCUPIED;
    
    [SerializeField] private float _y;
    [SerializeField] private float _x;
    
    private Color _defaultColor;
    private Renderer _renderer;
    private TetrominoBlock _occupiedByBlock;

    public float yPos {
        get { return _y; }
        set { _y = value;  }
    }

    public float xPos {
        get { return _x; }
        set { _x = value; }
    }
    
    public TetrominoBlock OccupiedByBlock => _occupiedByBlock;
    public bool IsOccupied => OccupiedByBlock != null;

    private void Awake() {
        _x = Int32.Parse(transform.name);
        _y = Int32.Parse(transform.parent.name);
    }

    private void OnTriggerStay(Collider hit) {
        if (hit.TryGetComponent(out TetrominoBlock block))
            _occupiedByBlock = block;
    }

    private void OnTriggerExit(Collider hit) {
        _occupiedByBlock = null;
    }
}