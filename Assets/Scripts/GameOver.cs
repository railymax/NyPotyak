using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI result;
    public TextMeshProUGUI finalScore;
    public GameObject scoreUI;
    public GameObject controls;

    public void Show(string message, int score)
    {
        scoreUI.SetActive(false);
        controls.SetActive(false);
        gameOverPanel.SetActive(true);
        result.text = message;
        finalScore.text = "В ИТОГЕ ТВОЯ МАССА СОСТАВИЛА: " + score;

        Time.timeScale = 0f;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    
}
