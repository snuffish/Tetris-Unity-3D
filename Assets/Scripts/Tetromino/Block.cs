using Tetromino.State;
using UnityEngine;

namespace Tetromino {
    public class Block : MonoBehaviour, ITetromino {
        public Rigidbody Rigidbody { get; private set; }

        private TetrominoState State = new MovableState();

        private void Awake() {
            Rigidbody = GetComponent<Rigidbody>();
        }

        private void Update() {
            State.HandleInput();
        }
    }
}