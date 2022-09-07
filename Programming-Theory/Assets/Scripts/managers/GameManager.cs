using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gemCounterText;
    [SerializeField] GameObject gemCounterObject;
    [SerializeField] TextMeshProUGUI missingGemsText;
    [SerializeField] GameObject missingGemsObject;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] List<GameObject> CharacterPrefabs;
    Vector3 spawnPos = new Vector3(-3,-9, 13);
    public bool isGameActive;    
    public static int gemsCollected;
    public static GameManager instance { get; private set; }
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        isGameActive = true;
        gemCounterObject.SetActive(true);
        gemCounterText.text = "Gems : " + 0;
        gemsCollected = 0;
        Time.timeScale = 1;

        if (MainManager.instance.playerCharacter == 1)
        {
            Instantiate(CharacterPrefabs[0], spawnPos, CharacterPrefabs[0].transform.rotation);
        }
        if (MainManager.instance.playerCharacter == 2)
        {
            Instantiate(CharacterPrefabs[1], spawnPos, CharacterPrefabs[0].transform.rotation);
        }
        if (MainManager.instance.playerCharacter == 3)
        {
            Instantiate(CharacterPrefabs[2], spawnPos, CharacterPrefabs[0].transform.rotation);
        }
    }

    public void UpdateGemCounter(int gemsToAdd)
    {
        gemsCollected += gemsToAdd;
        gemCounterText.text = "Gems : " + gemsCollected;
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        gemCounterObject.SetActive(false);
        isGameActive = false;
        Time.timeScale = 0;
    }
    public IEnumerator ShowMessage (string message, float delay)
    {
        gemCounterText.text = message;
        gemCounterObject.SetActive(true);
        yield return new WaitForSeconds(3);
        gemCounterObject.SetActive(false);
    }
}
