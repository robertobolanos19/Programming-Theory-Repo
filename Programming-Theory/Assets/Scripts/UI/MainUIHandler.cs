using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MainUIHandler : MonoBehaviour
{
    int characterSelected = 0;

    public void StartGame()
    {
        if(characterSelected < 1)
        {
            Debug.Log("Please choose a character");
        }
        else
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }

    public void ExitGame()
    {

    }

    public void DropDownVal(int value)
    {
        characterSelected = value;
        MainManager.instance.playerCharacter = value;
        Debug.Log("Character Selected: " + value);
    }
}
