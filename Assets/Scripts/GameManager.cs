using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _timelimit = 30f;
    [SerializeField] Text _timeText;

    Scenemanager scenemanager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timelimit -= Time.deltaTime;


        if (_timelimit <= 0)
        {
            scenemanager.Fade(true,"ResultScene");
        }
    }

    private void FixedUpdate()
    {
        _timeText.text = _timelimit.ToString();
    }
}
