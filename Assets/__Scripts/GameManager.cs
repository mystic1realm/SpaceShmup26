using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
        public static GameManager S;

    [Header("UI Panels")]
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    private bool gameOver = false;

    void Awake()
    {
        S = this;

        Time.timeScale = 0f;

        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void StartGame()
    {
        gameOver = false;

        startPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        if (gameOver)
        {
            return;
        }

        gameOver = true;

        if (ScoreManager.S != null)
        {
            finalScoreText.text = "Final Score: " + ScoreManager.S.score;
        }

        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
