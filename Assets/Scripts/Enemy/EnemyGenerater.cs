using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGenerater : MonoBehaviour,IPause
{
    [SerializeField] GameObject[] _enemys = default;
    [SerializeField] Transform[] _spawnpoint = default;
    [SerializeField] float _time = 0;
    [SerializeField] float _intervalTime = 2;
    [SerializeField] int _gameLevel;
    bool isPause = false;

     void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        for (int i = 0;i <= _spawnpoint.Length;i++)
        {
            if (_intervalTime <= _time && !isPause)
            {
                Instantiate(_enemys[i], _spawnpoint[i]);
                _time = 0;
            }
        }
    }

    public void Pause(float time)
    {
        isPause = true;
    }
    public void Resume()
    {
        isPause = false;
    }
}
