using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private Button btnReLoad;
    private void Awake()
    {
        btnReLoad.onClick.AddListener(ReloadScene);
    }

    public void InitGameOverPanel(float lastScore)
    {
        this.gameObject.SetActive(true);
        txtScore.text = lastScore.ToString();
    }

    

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}