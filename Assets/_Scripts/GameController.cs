using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    private int playerLives;
    private int playerPoints;

    private AudioSource audioSource;
    [SerializeField] AudioClip pointSound;
    [SerializeField] AudioClip loseLifeSound;

    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI livesText;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level01")
        {
            playerLives = 5;
            playerPoints = 0;
        }
        else
        {
            playerLives = PlayerPrefs.GetInt("lives");
            playerPoints = PlayerPrefs.GetInt("score");
        }

        pointsText.text = playerPoints.ToString();
        livesText.text = playerLives.ToString();
    }

    private void Update()
    {
        WinLose();
    }

    public void AddPoints(int points)
    {
        audioSource.pitch = Random.Range(0.85f, 1.15f);
        audioSource.PlayOneShot(pointSound);
        playerPoints += points;
        pointsText.text = "Points: " + playerPoints.ToString();
    }

    public void TakeLife()
    {
        audioSource.pitch = Random.Range(0.85f, 1.15f);
        audioSource.PlayOneShot(loseLifeSound);
        playerLives--;
        livesText.text = "Lives: " + playerLives.ToString();
    }

    private void WinLose()
    {
        if (playerLives <= 0)
        {
            SceneManager.LoadScene("Level01");
        }

        PlayerPrefs.SetInt("score", playerPoints);
        PlayerPrefs.SetInt("lives", playerLives);
        
        if ((GameObject.FindGameObjectsWithTag("Brick")).Length == 0)
        {
            if (SceneManager.GetActiveScene().name == "Level02")
            {
                SceneManager.LoadScene("Level01");
            }

            string curLevelName = SceneManager.GetActiveScene().name;
            string nextLevelName;
            int curLevelNumber;

            int.TryParse(curLevelName.Substring(5, 2), out curLevelNumber);

            curLevelNumber++;

            if (curLevelNumber < 10)
            {
                nextLevelName = "Level0" + curLevelNumber.ToString();
            }
            else if (curLevelNumber < 100)
            {
                nextLevelName = "Level" + curLevelNumber.ToString();
            }
            else
            {
                nextLevelName = "Level" + curLevelNumber.ToString();
            }
            SceneManager.LoadScene(nextLevelName);
        }
    }
}
