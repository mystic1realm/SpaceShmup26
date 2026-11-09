using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip explosionSound;
    public AudioClip heroDeathSound;

    private AudioSource audioSource;

    public static ScoreManager S;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        S = this;

        audioSource = GetComponent<AudioSource>();

        UpdateScore();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }
    
    public void PlayExplosion()
    {
        if (audioSource != null && explosionSound != null)
        {
            audioSource.PlayOneShot(explosionSound);
        }
    }

    public void PlayHeroDeath()
    {
        if (audioSource != null && heroDeathSound != null)
        {
            audioSource.PlayOneShot(heroDeathSound);
        }
    }

    void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
