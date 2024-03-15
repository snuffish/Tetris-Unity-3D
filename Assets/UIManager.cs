using System;
using UnityEngine;

public class UIManager : MonoBehaviour {
    private Transform _bulletsText;
    private int Bullets;

    public static event Action<int> OnBulletsCount;

    private void Awake() {
        if (TryGetComponent(out BulletsTextComponent component)) {
            _bulletsText = component.transform;
        }
    }

    private void Start() {
        BroadcastMessage("IncrementBulletCount");
    }

    public void IncrementBulletCount() {
        Bullets++;
        OnBulletsCount?.Invoke(Bullets);
    }
}