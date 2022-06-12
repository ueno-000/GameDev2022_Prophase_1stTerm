using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour,IPause
{
    [SerializeField] float _timelimit = 30f;
    [SerializeField] Text _timeText;

    [Header("SceneManagerを格納"), SerializeField] GameObject _sceneManager;

    Scenemanager scenemanager;

    bool isPause;
    void Start()
    {

        scenemanager = _sceneManager.GetComponent<Scenemanager>();

    }

    // Update is called once per frame
    void Update()
    {
      
        if (_timelimit <= 0)
        {
            scenemanager.Fade(false, "ResultScene");
        }
    }

    private void FixedUpdate()
    {
        _timelimit = Mathf.Clamp(_timelimit, 0, _timelimit);

        if (!isPause)
        {
            _timelimit -= Time.deltaTime;
            _timeText.text = _timelimit.ToString("f1") + "s";
        }
    }

    /// <summary>一時停止のための処理</summary>
    public void Pause(float time)
    {
        isPause = true;
    }
    /// <summary>再開のための処理</summary>
    public void Resume()
    {
        isPause = false;
    }
}
