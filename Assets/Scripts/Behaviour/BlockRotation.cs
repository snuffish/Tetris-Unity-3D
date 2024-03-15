using UnityEngine;

public class BlockRotation : MonoBehaviour
{
    private float _rotationSpeed;

    private void Awake() {
        _rotationSpeed =
            MainMenuManager.Instance.BlockRotatingSpeed[
                Random.Range(0, MainMenuManager.Instance.BlockRotatingSpeed.Length)];
    }

    private void Update() {
        var from = Quaternion.Euler(0, 0, -25);
        var to = Quaternion.Euler(0, 0, 25);
        
        transform.rotation *= Quaternion.Euler(0, 0, 25 * _rotationSpeed * Time.deltaTime);
    }
}