using UnityEngine;
using UnityEngine.Events;

namespace Tetromino
{
    internal enum Direction {
        LEFT,
        RIGHT
    }

    [RequireComponent(typeof(Rigidbody))]
    internal class TetrominoController : MonoBehaviour {
        public static Vector3 FlipRotation = new Vector3(0, 0, 90);
        private Direction undoLatestDirection;
        private Rigidbody _rigidbody;

        public UnityEvent OnFlip;
        public UnityEvent OnCollision;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX |
                                     RigidbodyConstraints.FreezePositionZ;
        }

        public void EnableRagdoll() {
            _rigidbody.isKinematic = false;
            _rigidbody.detectCollisions = true;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                Flip();

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                Move(Direction.LEFT);

            if (Input.GetKeyDown(KeyCode.RightArrow))
                Move(Direction.RIGHT);
        }

        private void Move(Direction direction) {
            switch (direction) {
                case Direction.LEFT:
                    transform.position += Vector3.left;
                    undoLatestDirection = Direction.RIGHT;
                    break;
                case Direction.RIGHT:
                    transform.position += Vector3.right;
                    undoLatestDirection = Direction.LEFT;
                    break;
            }
        }

        public void Flip() {
            transform.Rotate(FlipRotation);
            OnFlip?.Invoke();
        }

        private void OnCollisionEnter(Collision hit) {
            OnCollision?.Invoke();
            Debug.Log($"Collision with: {hit.transform.tag}");

            if (hit.transform.CompareTag("Bottom") ||
                hit.transform.CompareTag("Tetromino") ||
                hit.transform.CompareTag("TetrominoBlock")) {
                enabled = false;

                // gameObject.AddComponent<ExplodeTetrominoBlock>();
            }

            if (hit.transform.CompareTag("Walls"))
                Move(undoLatestDirection);

            // if (hit.transform.CompareTag("GameOver"))
            //     GameManager.Instance.GameOver();
        }
    }
}