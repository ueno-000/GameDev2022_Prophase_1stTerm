using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBase: MonoBehaviour,IPause
{
    [SerializeField] int _damageValue = 2;
    //移動速度
    [SerializeField] float _speed = 0.5f;
    GameObject _player;

    float _time;
    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 _playerPos = _player.transform.position;
        //y軸はプレイヤーと同じにする
        _playerPos.y = transform.position.y;
        // プレイヤーに向かせる
        transform.LookAt(_playerPos);

        //オブジェクトを前方向に移動する
        transform.position = transform.position + transform.forward * _speed * Time.deltaTime;
        
    }
    private void OnCollisionStay(Collision collision)
    {
         
        if (collision.gameObject.tag == "Player" )
        {
            _player.GetComponent<IReceiveDamage>().ReceiveDamage(_damageValue);
        }
    }

    public void Pause(float time)
    {
        _time = time;
        _speed = 0;
        StartCoroutine("PauseTime");
    }
    public void Resume()
    {
        _speed = 2;
    }

    IEnumerator PauseTime()
    {
        yield return new WaitForSeconds(_time);
        Resume();
    }
}