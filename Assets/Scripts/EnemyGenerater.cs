using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour
{
    [SerializeField] GameObject _enemys = default;
    [SerializeField] Transform[] _spawnpoint = default;
    [SerializeField] float _time = 0;
    [SerializeField] float _intervalTime = 2;
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime; 

        if (_intervalTime <= _time)
        {
            Instantiate(_enemys, _spawnpoint[0]);
            _time = 0;
        }
    }
}
