﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;

    public void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadScene);
    }

    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
