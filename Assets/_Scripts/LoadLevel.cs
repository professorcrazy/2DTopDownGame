using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadSpecificLevel(int index) {
        SceneManager.LoadScene(index);
    }
    public void LoadNextLevel() {
        LoadSpecificLevel(SceneManager.GetActiveScene().buildIndex + 1 % SceneManager.sceneCountInBuildSettings);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            LoadNextLevel();
        }
    }
}
