using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TMP_Text text;
    int score = 0;
    public static ScoreManager Instance;

    private void Start() {
        Instance = this;
        score = 0;
        UpdateScore(0);
        text = GetComponent<TMP_Text>();
    }

    public void UpdateScore(int value) {
        score += value;
        text.text = "Score :" + score.ToString(); 
    }
}
