using UnityEngine;

public class EnemyMoveBase: MonoBehaviour,IPause
{
    [SerializeField] int _damageValue = 2;
    //移動速度
    [SerializeField] float _speed;
    GameObject _player;
    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        // 作成してプレイヤーの座標を格納
        Vector3 _playerPos = _player.transform.position;
        //プレイヤーのX、Zのみ参照
        _playerPos.y = transform.position.y;
        // プレイヤーに向かせる
        transform.LookAt(_playerPos);

        //オブジェクトを前方向に移動する
        transform.position = transform.position + transform.forward * _speed * Time.deltaTime;
        
    }
    private void OnCollisionStay(Collision collision)
    {
        var damagetarget = _player.GetComponent<IReceiveDamage>();
        
        if (collision.gameObject.tag == "Player"  && damagetarget != null)
        {
            _player.GetComponent<IReceiveDamage>().ReceiveDamage(_damageValue);
        }
    }

    public void Pause()
    {
        _speed = 0;
    }
    public void Resume()
    {
        _speed = 2;
    }
}