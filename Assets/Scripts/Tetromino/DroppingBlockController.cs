using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DroppingBlockController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        _rigidbody.constraints = RigidbodyConstraints.None;
        _rigidbody.isKinematic = false;
        _rigidbody.detectCollisions = true;
    }

    private void Start() {
        if (Random.Range(0, 2) == 1)
            gameObject.AddComponent<BlockRotation>();

        var flipTimes = Random.Range(0, 4);
        for (int i = 0; i < flipTimes; i++)
            transform.Rotate(TetrominoController.FlipRotation);
    }

    private void OnTriggerEnter(Collider hit) {
        if (hit.transform.CompareTag("DeSpawner"))
            Destroy(gameObject);
    }
}