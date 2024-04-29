using Unity.VisualScripting;
using UnityEngine;

namespace Tetromino
{
    public class Tetromino : MonoBehaviour
    {
        public static Vector3 FlipRotation = Vector3.forward * 90;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX |
                                     RigidbodyConstraints.FreezePositionZ;
        }

        public void EnableRagdoll() {
            _rigidbody.isKinematic = false;
            _rigidbody.detectCollisions = true;
        }

        public void DisableRagdoll() {
            _rigidbody.isKinematic = true;
            _rigidbody.detectCollisions = false;
        }

        private void Move(Direction direction)
        {
            transform.position += direction == Direction.LEFT ? Vector3.left : Vector3.right;
        }

        public void Flip() {
            transform.Rotate(FlipRotation);
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                Flip();

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                Move(Direction.LEFT);

            if (Input.GetKeyDown(KeyCode.RightArrow))
                Move(Direction.RIGHT);
        }
    }
}