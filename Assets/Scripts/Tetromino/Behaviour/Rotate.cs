using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tetromino.Behaviour
{
    public class Rotate : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private float _rotationSpeed;
        private Rotate _instance;

        private void Awake()
        {
            _instance = this;
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _rigidbody.constraints = RigidbodyConstraints.None;
            _rigidbody.isKinematic = false;
            _rigidbody.detectCollisions = true;
        }

        private void Start()
        {
            gameObject.AddComponent<Rotate>();
            SetRandomRotatingSpeed();
        }

        private void FixedUpdate()
        {
            var from = Quaternion.Euler(0, 0, -25);
            var to = Quaternion.Euler(0, 0, 25);

            transform.rotation *= Quaternion.Euler(0, 0, 25 * _rotationSpeed * Time.deltaTime);
        }

        public void SetRandomRotatingSpeed()
        {
            _rotationSpeed = 30;
        }

        // private void ResetPhysicsState()
        // {
        //     _rigidbody.velocity = Vector3.zero;
        //     _rigidbody.angularVelocity = Vector3.zero;
        //     transform.position = initialPosition;
        //     transform.rotation = initialRotation;
        // }
    }
}