using UnityEngine;

namespace Behaviour
{
    public class BlockRotation : MonoBehaviour
    {
        private float _rotationSpeed = 0f;
        public bool IsRotating => _rotationSpeed > 0f;

        private void Start()
        {
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
            // _rotationSpeed = MainMenuManager.Instance.BlockRotatingSpeed[Random.Range(0, MainMenuManager.Instance.BlockRotatingSpeed.Length)];
        }
    }
}