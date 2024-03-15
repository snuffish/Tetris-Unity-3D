using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SceneManager : MonoBehaviour {
    public GameObject MenuCanvas;

    public void StartGame() {
        StartCoroutine(ExplodeTetroMinosAndLoadGame());
    }

    public void MainMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public IEnumerator ExplodeTetroMinosAndLoadGame() {
        MainMenuManager.Instance.enabled = false;
        MenuCanvas.SetActive(false);

        #region Explode All Tetrominos

        var tetrominos = FindObjectsOfType<DroppingBlockController>();
        foreach (var item in tetrominos) {
            var component = item.AddComponent<ExplodeTetrominoBlock>();
            component.ExplosionPosition = item.transform.position;
            component.ExplodeOnStart = true;
        }

        #endregion

        Camera.main.AddComponent<MoveObject>();

        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    #region Singleton

    public static SceneManager Instance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this.gameObject);
        }
        else {
            Instance = this;
        }
    }

    #endregion
}