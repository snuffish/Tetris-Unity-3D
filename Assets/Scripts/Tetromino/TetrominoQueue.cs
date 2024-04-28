using UnityEngine;
using UnityEngine.Splines;

namespace Tetromino
{
    [RequireComponent(typeof(SplineAnimate))]
    public class TetrominoQueue : MonoBehaviour {
        public SplineContainer Spline;
        public Transform QueueSlot;

        private SplineAnimate _splineAnimate;

        private void Awake() {
            _splineAnimate = GetComponent<SplineAnimate>();
        }

        private void Start() {
            _splineAnimate.Container = Spline;
            _splineAnimate.enabled = true;
            GameManager.Instance.TetrominoOnSplinePath = true;
        }

        private void Update() {
            if (!_splineAnimate.enabled) return;

            var splineAnimationIsDone = !_splineAnimate.IsPlaying;
            if (splineAnimationIsDone) {
                transform.SetParent(QueueSlot);
                transform.position = QueueSlot.position;
                GameManager.Instance.TetrominoOnSplinePath = false;
                _splineAnimate.enabled = false;
            }
        }
    }
}