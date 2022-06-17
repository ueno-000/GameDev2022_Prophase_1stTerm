using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour,IPause
{
    /// <summary>最終的なスコア：生き延びた時間</summary>
    static public float _survivalTime;
    /// <summary>制限時間</summary>
    [SerializeField] public float _timelimit = 30f;
    /// <summary>表示するためのテキスト</summary>
    [SerializeField] Text _timeText;

    [Header("SceneManagerを格納"), SerializeField] GameObject _sceneManager;

    Scenemanager scenemanager;

    float _time;

    /// <summary>GameOverのフラグ</summary>
    static public bool isGameOver;
    /// <summary>Pauseかどうかのフラグ</summary>
    bool isPause;
    void Start()
    {
        _time = _timelimit;
        scenemanager = _sceneManager.GetComponent<Scenemanager>();
        isGameOver = false;

    }

    // Update is called once per frame
    void Update()
    {
        isGameOver = PlayerValueScript.isGameOver;

        if (isGameOver||_time <= 0)
        {
            scenemanager.Fade(false, "ResultScene");
        }
    }

    private void FixedUpdate()
    {
        _time = Mathf.Clamp(_time, 0, _timelimit);

        if (!isPause)
        {
            _time -= Time.deltaTime;
            _survivalTime =  _timelimit - _time;
            
            _timeText.text = _time.ToString("f1") + "s";
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
