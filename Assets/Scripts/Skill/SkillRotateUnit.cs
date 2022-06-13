using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SkillRotateUnit : SkillBase
{
    /// <summary> 攻撃力 </summary>
    [SerializeField]int  _damageValue = 1;
    //数
    [SerializeField] int _num = 1;
    //　現在の角度
    private float angle;
    //　回転するスピード
    [Header("回転するスピード"),SerializeField] private float _rotateSpeed = 180f;
    //　ターゲットからの距離
    [Header("ターゲットからの距離"),SerializeField] private Vector3 _distanceFromTarget = new Vector3(0f, 1f, 2f);

     [SerializeField] private GameObject _player;

    void Awake()
    {
      // _player = transform.root.gameObject;
    }

    void Update()
    {
        //　ユニットの位置 = ターゲットの位置 ＋ ターゲットから見たユニットの角度 ×　ターゲットからの距離
        transform.position = _player.transform.position + Quaternion.Euler(0f, angle, 0f) * _distanceFromTarget;
        //　ユニット自身の角度 = ターゲットから見たユニットの方向の角度を計算しそれをユニットの角度に設定する
        transform.rotation = Quaternion.LookRotation
            (transform.position - new Vector3(_player.transform.position.x, transform.position.y-90, _player.transform.position.z), Vector3.up);
        //　ユニットの角度を変更
        angle += _rotateSpeed * Time.deltaTime;
        //　角度を0～360度の間で繰り返す
        angle = Mathf.Repeat(angle, 360f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<IReceiveDamage>().ReceiveDamage(_damageValue);
        }
    }
}