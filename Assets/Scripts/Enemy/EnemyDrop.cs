using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour, IReceiveDamage
{
   
    [Header("経験値のPrefabをアタッチする"), SerializeField] GameObject _retentionExpPrefab;

    [Header("HP"), SerializeField] int _hp = 5;
    
    //Vector3 _pos;
    bool isLive = true;

    private void Update()
    {
        if (_hp <= 0 && isLive)
        {
            Instantiate(_retentionExpPrefab,this.transform.position,Quaternion.identity);
            this.gameObject.SetActive(false);
            isLive = false;
        }
    }


    /// <summary> ダメージ処理</summary>
    /// <param name="damage"></param>
    public void ReceiveDamage(int damage)
    {
        _hp -= damage;
    }
}
