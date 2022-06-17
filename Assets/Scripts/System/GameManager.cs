using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour,IPause
{
    /// <summary>�ŏI�I�ȃX�R�A�F�������т�����</summary>
    static public float _survivalTime;
    /// <summary>��������</summary>
    [SerializeField] public float _timelimit = 30f;
    /// <summary>�\�����邽�߂̃e�L�X�g</summary>
    [SerializeField] Text _timeText;

    [Header("SceneManager���i�["), SerializeField] GameObject _sceneManager;

    Scenemanager scenemanager;

    float _time;

    /// <summary>GameOver�̃t���O</summary>
    static public bool isGameOver;
    /// <summary>Pause���ǂ����̃t���O</summary>
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

    /// <summary>�ꎞ��~�̂��߂̏���</summary>
    public void Pause(float time)
    {
        isPause = true;
    }
    /// <summary>�ĊJ�̂��߂̏���</summary>
    public void Resume()
    {
        isPause = false;
    }
}
