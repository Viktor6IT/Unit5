using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOverText;
    private int score;
    private float Spawnrate = 1.2f;
    public bool IsGameActive;
    public Button RestartButton;
    public GameObject TitleScreen;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTargets()
    {
        while (IsGameActive)
        {
            yield return new WaitForSeconds(Spawnrate);
            int index = Random.Range(0, Targets.Count);
            Instantiate(Targets[index]);
        }
    }
    public void UpdateScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        RestartButton.gameObject.SetActive(true);
        GameOverText.gameObject.SetActive(true);
        IsGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int Difficulty)
    {
        IsGameActive = true;
        Spawnrate /= Difficulty;
        StartCoroutine(SpawnTargets());
        UpdateScore(0);
        TitleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
}
