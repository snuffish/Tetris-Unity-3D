using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
    private Rigidbody _rb;

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start() {
        _rb.AddForce(transform.forward, ForceMode.Impulse);
        
        Invoke("OnDestroy", 3f);
    }

    private void OnDestroy() {
        Destroy(gameObject);
    }
}