using UnityEngine;

namespace Tetromino.State {
    public class MovableState : TetrominoState, ITetromino {
        public override TetrominoState HandleInput() {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                this.Flip();

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                this.Move(Behaviours.Direction.Left);

            if (Input.GetKeyDown(KeyCode.RightArrow))
                this.Move(Behaviours.Direction.Right);

            return this;
        }
    }
}