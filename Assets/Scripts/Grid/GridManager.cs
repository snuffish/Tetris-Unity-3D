using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GridManager : MonoBehaviour {
    [SerializeField] private Dictionary<float, List<GridBlockTrigger>> _gridColliders = new Dictionary<float, List<GridBlockTrigger>>();
    [SerializeField] private bool MarkInsteadOfExplodeBlocks;

    public UnityEvent OnClearedBlock;

    private void Start() {
        InitGridCollider();
    }

    private void InitGridCollider() {
        var sortedColliders = FindObjectsOfType<GridBlockTrigger>()
            .OrderBy(item => item.yPos);
        
        foreach (var collider in sortedColliders) {
            var list = _gridColliders.ContainsKey(collider.yPos)
                ? _gridColliders[collider.yPos]
                : CreateRow(collider.yPos);
            
            list.Add(collider);
        }
    }

    private List<GridBlockTrigger> CreateRow(float y) {
        var list = new List<GridBlockTrigger>();
        _gridColliders.Add(y, list);
        return list;
    }

    private void Update() {
        CheckAndExplodeCompletedRows();
    }

    private void CheckAndExplodeCompletedRows() {
        foreach (var row in _gridColliders) {
            var triggers = row.Value;
            var allColumnsOccupied = triggers.All(item => item.IsOccupied);
            if (allColumnsOccupied)
                triggers.ForEach(item => {
                    if (item.IsOccupied) {
                        if (MarkInsteadOfExplodeBlocks) {
                            // item.OccupiedByBlock.Marked(true);
                        } else {
                            // item.OccupiedByBlock.Explode();
                            OnClearedBlock?.Invoke();
                        }
                    }
                });
        }
    }
}