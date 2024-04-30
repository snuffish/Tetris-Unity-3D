namespace Tetromino.State {
    public class RotateState : TetrominoState {
        public override TetrominoState HandleInput() {
            return this;
        }
    }
}