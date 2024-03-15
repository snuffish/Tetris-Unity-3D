using UnityEngine;

public class PhysicsGravity : MonoBehaviour {
    public Vector3 Gravity;

    private void Start() {
        Physics.gravity = Gravity;
    }
}