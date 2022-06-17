using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGenerater : MonoBehaviour,IPause
{
    [SerializeField] GameObject[] _enemys = default;

    [SerializeField] float _time = 0;
    /// <summary>生成の間隔</summary>
    [SerializeField] float _intervalTime = 30;
    /// <summary>一回につき生成する個体数</summary>
    [SerializeField] int _population = 10; 
    [SerializeField] int _gameLevel;

    [SerializeField] Transform _player;

    /// <summary> スポーン座標 </summary>
    [SerializeField] Vector3[] _spawnpoint;

    /// <summary> スポーン順</summary>
    int[]  _order = new int[15] {0,1,2,0,2,3,1,3,2,4,3,2,4,3,4};

    bool isPause = false;
    int _enemyNum = 0;
     void Start()
    {

        EnemyDev();

    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        if (_intervalTime <= _time && !isPause)
        {
            EnemyDev();
            _enemyNum++;
            _time = 0;
        }
    }


    private void EnemyDev()
    {
        for (int i = 0; i < _spawnpoint.Length; i++)
        {
            for (int k = 0; k <= _population; k++)
            {
                Instantiate(_enemys[_order[_enemyNum]], _player.position+_spawnpoint[i],Quaternion.identity);
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
