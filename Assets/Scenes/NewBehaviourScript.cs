using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");  // 여기서 "Game"은 게임 씬의 이름입니다.
    }
}