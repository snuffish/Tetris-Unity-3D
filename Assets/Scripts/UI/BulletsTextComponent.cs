using System;
using TMPro;
using UnityEngine;

public class BulletsTextComponent : MonoBehaviour {
    private TextMeshProUGUI _textMesh;

    private void Awake() {
        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        UIManager.OnBulletsCount += BulletsCountCallback;
    }

    private void BulletsCountCallback(int count) {
        _textMesh.SetText($"Bullets: {count}");
    }
}