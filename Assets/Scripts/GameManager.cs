using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameIntroScene;
    public GameObject gameScene;
    public void toGameScreen()
    {
        Debug.Log("ff");
        gameIntroScene.SetActive(false);
        gameScene.SetActive(true);
    }
}
