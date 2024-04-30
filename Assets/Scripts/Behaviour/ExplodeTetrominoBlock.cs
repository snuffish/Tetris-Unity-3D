using System;
using System.Collections.Generic;
using Tetromino;
using Unity.VisualScripting;
using UnityEngine;

public class ExplodeTetrominoBlock : MonoBehaviour {
    [SerializeField] private Vector3 _explosionPosition;
    [SerializeField] public bool ExplodeOnStart;
    [SerializeField] private float BlockExplosionForce = 600f;

    public bool DestroyInsteadOfExplode;

    public Vector3 ExplosionPosition {
        get { return _explosionPosition; }
        set { _explosionPosition = value; }
    }

    private List<Transform> _blocks = new();

    private void Awake() {
        #region If the current Object is a Block
            var singleBlock = GetComponent<OldTetrominoBlock>();
            if (singleBlock != null)
                _blocks.Add(singleBlock.transform);
        #endregion

        #region If the Child objects is a Block
            var childBlocks = GetComponentsInChildren<OldTetrominoBlock>();
            if (childBlocks != null)
                foreach (var block in childBlocks)
                    _blocks.Add(block.transform);
        #endregion
    }

    private void Start() {
        if (ExplodeOnStart)
            OnDestroy();
    }

    private void OnDestroy() {
        _blocks.ForEach(block => {
            Rigidbody rb = block.AddComponent<Rigidbody>();
            block.SetParent(null);

            if (DestroyInsteadOfExplode) {
                Destroy(block.gameObject);
            } else {
                rb.AddExplosionForce(BlockExplosionForce, ExplosionPosition, 20f);
            }
        });
    }
}