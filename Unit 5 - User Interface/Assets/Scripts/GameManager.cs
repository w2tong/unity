using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> targets;
    private float spawnRate = 1.0f;
    [SerializeField] TextMeshProUGUI scoreText;
    private int score;
    [SerializeField] TextMeshProUGUI livesText;
    private int lives = 3;
    [SerializeField] TextMeshProUGUI gameOverText;
    private bool isGameActive;
    [SerializeField] Button restartButton;
    [SerializeField] GameObject titleScreen;
    private bool paused = false;
    [SerializeField] GameObject pausedPanel;
    private bool isMouseDown = false;
    [SerializeField] TrailRenderer trail;

    // Start is called before the first frame update
    void Start()
    {
        trail.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            if (lives <= 0)
            {
                GameOver();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
            trail.Clear();
            trail.enabled = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            trail.enabled = false;
        }

        if (isMouseDown)
        {
            trail.gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(targets[Random.Range(0, targets.Count)]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public bool GetIsGameActive()
    {
        return isGameActive;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        scoreText.gameObject.SetActive(true);
        UpdateScore(0);
        livesText.gameObject.SetActive(true);
        livesText.text = "Lives: " + lives;
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
    }

    public void UpdateLives(int num)
    {
        lives += num;
        livesText.text = "Lives: " + lives;
    }

    private void PauseGame()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
            pausedPanel.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausedPanel.gameObject.SetActive(false);
        }
    }

    public bool GetIsGamePaused()
    {
        return paused;
    }

    public bool GetIsMouseDown()
    {
        return isMouseDown;
    }
}
