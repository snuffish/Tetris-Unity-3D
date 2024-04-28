using UnityEngine;
using Random = UnityEngine.Random;

namespace Tetromino
{
    [RequireComponent(typeof(Rigidbody))]
    public class DroppingBlockController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        // private MainMenuManager _mainMenuManager;
        private BlockRotation _blockRotation;

        private Vector3 initialPosition;
        private Quaternion initialRotation;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            // _mainMenuManager = FindObjectOfType<MainMenuManager>();

            _rigidbody.constraints = RigidbodyConstraints.None;
            _rigidbody.isKinematic = false;
            _rigidbody.detectCollisions = true;

            _blockRotation = gameObject.AddComponent<BlockRotation>();
        }

        private void OnEnable() {
            var flipTimes = Random.Range(0, 4);
            for (int i = 0; i < flipTimes; i++)
            {
                transform.Rotate(TetrominoController.FlipRotation);
            }
        }

        private void Start()
        {
            initialPosition = transform.position;
            initialRotation = transform.rotation;

            _blockRotation.SetRandomRotatingSpeed();
        }

        // private void Update()
        // {
        //     _rigidbody.velocity = Vector3.down * _mainMenuManager.FallingSpeed;
        // }

        private void FixedUpdate()
        {
            // if (transform.position.y <= _mainMenuManager.YAxisRespawner) {
            //     ResetPhysicsState();
            //
            //     transform.Translate(_mainMenuManager.GetSpawnPosition());
            // }
        }

        private void ResetPhysicsState()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            transform.position = initialPosition;
            transform.rotation = initialRotation;
        }
    }
}