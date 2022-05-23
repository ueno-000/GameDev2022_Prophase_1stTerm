using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSystem : MonoBehaviour
{
    [SerializeField] Scenemanager _sceneManager;
    [Header("FadePanelをアクティブにしてアタッチ"), SerializeField] Image _fadePanel;
    void Start()
    {
        _fadePanel.color = Color.black;
        _sceneManager.Fade(true, null);
    }
}