using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy死亡時に経験値をドロップさせるscript
/// </summary>

public class EnemyEXPDropScript : MonoBehaviour, IReceiveDamage
{
   
    [Header("経験値のPrefabをアタッチする"), SerializeField] private GameObject _retentionExpPrefab;

    [Header("パラメーター")]
    [Tooltip("HP"), SerializeField] private int _hp = 5;
    public int HP
        { get { return _hp; } set { _hp = value; } }

    //Vector3 _pos;
    private bool isLive = true;

    private void Update()
    {
        DropEXP();
    }

    /// <summary>
    /// 体力値が０を切った場合に経験値をドロップさせるメソッド
    /// </summary>
    private void DropEXP()
    {
        if (HP <= 0 && isLive)
        {
            Instantiate(_retentionExpPrefab, new Vector3(this.transform.position.x, 0, this.transform.position.z), Quaternion.identity);
            this.gameObject.SetActive(false);
            isLive = false;
        }
    }


    /// <summary> ダメージ処理</summary>
    /// <param name="damage"></param>
    public void ReceiveDamage(int damage)
    {
        HP -= damage;
    }
}
