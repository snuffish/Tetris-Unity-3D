using UnityEngine;
using UnityEngine.Splines;

public class GameManager : MonoBehaviour {
    #region Singleton
        public static GameManager Instance { get; private set; }

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(this.gameObject);
            }
            else {
                Instance = this;
            }
        }
    #endregion
        
    public TetrominoQueue[] TetrominoPrefabs;

    public SplineContainer IncomingBlockSpline;
    
    public Transform FirstInQueue;
    public Transform SecondInQueue;
    public Transform ThirdInQueue;
    public Transform TetrominoDeployer;

    public bool TetrominoOnSplinePath;

    private TetrominoController currentTetromino;

    private bool FirstIsFree => FirstInQueue.childCount == 0;
    private bool SecondIsFree => SecondInQueue.childCount == 0;
    private bool ThirdIsFree => ThirdInQueue.childCount == 0;
    private bool AllSlotsFilled => !FirstIsFree && !SecondIsFree && !ThirdIsFree;

    private void Update() {
        var queueSlotAvailable = ThirdInQueue.childCount == 0 && !TetrominoOnSplinePath;
        if (queueSlotAvailable)
            SpawnTetromino();

        MoveTheQueue();
        
        if (FirstInQueue.childCount == 1 && currentTetromino == null && AllSlotsFilled)
            DeployTetromino();

        if (currentTetromino && !currentTetromino.enabled)
            currentTetromino = null;
    }

    private void DeployTetromino() {
        var tetromino = FirstInQueue.GetChild(0);
        tetromino.SetParent(null);
        tetromino.position = TetrominoDeployer.position;
        
        if (tetromino.TryGetComponent(out TetrominoController tetrominoController)) {
            tetrominoController.enabled = true;
            tetrominoController.EnableRagdoll();
        }

        if (tetromino.TryGetComponent(out TetrominoQueue tetrominoQueue)) {
            tetrominoQueue.enabled = false;
        }

        currentTetromino = tetrominoController;
    }

    private void MoveTheQueue() {
        #region SecondSlot
            if (SecondIsFree) {
                if (!ThirdIsFree) {
                    var tetromino = ThirdInQueue.GetChild(0);
                    tetromino.SetParent(SecondInQueue);
                    tetromino.position = SecondInQueue.position;
                }
            }
        #endregion
        
        #region FirstSlot
            if (FirstIsFree) {
                if (!SecondIsFree) {
                    var tetromino = SecondInQueue.GetChild(0);
                    tetromino.SetParent(FirstInQueue);
                    tetromino.position = FirstInQueue.position;
                }
            }
        #endregion
    }

    private void SpawnTetromino() {
        var prefab = TetrominoPrefabs[Random.Range(0, TetrominoPrefabs.Length)];
        var outsideFromView = new Vector3(0, 0, -100);
        var tetromino = Instantiate(prefab, outsideFromView, Quaternion.identity);
        tetromino.Spline = IncomingBlockSpline;
        tetromino.QueueSlot = ThirdInQueue;

        if (tetromino.TryGetComponent(out TetrominoQueue queue))
            queue.enabled = true;
    }
}