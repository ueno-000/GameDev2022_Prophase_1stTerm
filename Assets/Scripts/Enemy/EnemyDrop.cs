using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour, IReceiveDamage
{
    [Header("経験値のPrefabをアタッチする"), SerializeField] GameObject _retentionExpPrefab;

    [Header("HP"), SerializeField] int _hp = 5;

    bool isLive = true;

    private void Update()
    {
        if (_hp <= 0 && isLive)
        {
            Instantiate(_retentionExpPrefab,this.transform,false);
            Destroy(this.gameObject,1f);
            isLive = false;
        }
    }


    /// <summary> ダメージ処理</summary>
    /// <param name="damage"></param>
    public void ReceiveDamage(int damage)
    {
        _hp -= damage;
        Debug.Log("Enemyhp: " + _hp);       
    }
}
