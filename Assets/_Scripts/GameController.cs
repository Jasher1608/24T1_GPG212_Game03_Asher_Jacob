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

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        playerLives = 3;
        playerPoints = 0;
        pointsText.text = playerPoints.ToString();
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
        pointsText.text = playerPoints.ToString();
    }

    public void TakeLife()
    {
        audioSource.pitch = Random.Range(0.85f, 1.15f);
        audioSource.PlayOneShot(loseLifeSound);
        playerLives--;
    }

    private void WinLose()
    {
        if (playerLives <= 0)
        {
            SceneManager.LoadScene("Level01");
        }
    }
}
