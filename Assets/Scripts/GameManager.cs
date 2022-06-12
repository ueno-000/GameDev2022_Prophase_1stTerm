using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour,IPause
{
    [SerializeField] float _timelimit = 30f;
    [SerializeField] Text _timeText;

    [Header("SceneManager‚ğŠi”["), SerializeField] GameObject _sceneManager;

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

    /// <summary>ˆê’â~‚Ì‚½‚ß‚Ìˆ—</summary>
    public void Pause(float time)
    {
        isPause = true;
    }
    /// <summary>ÄŠJ‚Ì‚½‚ß‚Ìˆ—</summary>
    public void Resume()
    {
        isPause = false;
    }
}
