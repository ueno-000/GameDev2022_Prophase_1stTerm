using UnityEngine;

public class EnemyMoveBase: MonoBehaviour
{
    //移動速度
    [SerializeField] float _speed;

    GameObject _player;
    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        // 変数 targetPos を作成してターゲットオブジェクトの座標を格納
        Vector3 targetPos = _player.transform.position;
        //プレイヤーのX、Zのみ参照
        targetPos.y = transform.position.y;
        // プレイヤーに向かせる
        transform.LookAt(targetPos);

        //オブジェクトの位置とターゲットオブジェクトの距離を格納
        float distance = Vector3.Distance(transform.position, _player.transform.position);

        //オブジェクトを前方向に移動する
        transform.position = transform.position + transform.forward * _speed * Time.deltaTime;
        
    }
}