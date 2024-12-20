using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToGameScene : MonoBehaviour
{
    public GameObject gameIntroScene;
    public GameObject gameScene;
    public void toGameScreen()
    {
        gameIntroScene.SetActive(false);
        gameScene.SetActive(true);
    }
}
