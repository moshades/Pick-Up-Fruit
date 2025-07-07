using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public int playerScore = 0;
    public float gameStartTime;
    public bool isGameOver = false;

    public Text scoreText;
    public HealthBar healthBar;
    public AudioSource pointSFX;
    public GameObject gameOverScreen;
    public TextMeshProUGUI finalScore, highScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameStartTime = Time.time;
        if(PlayerPrefs.GetInt("HighScore", 0) == 0)
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar.health == 0)
        {
            GameOver();
        }
    }

    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = "Score: " + playerScore.ToString();
        pointSFX.Play();
    } 

    public void MenuReturn()
    {
        SceneManager.LoadSceneAsync("Title Scene");
    }

    public void RestartGame()
    {
        gameStartTime = Time.time;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;
        finalScore.text = playerScore.ToString();
        if(playerScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }
        highScore.text = "High Score\n" + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
