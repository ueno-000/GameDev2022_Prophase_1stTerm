using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour, IReceiveDamage
{
    [Header("�o���l��Prefab���A�^�b�`����"), SerializeField] GameObject _retentionExpPrefab;

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


    /// <summary> �_���[�W����</summary>
    /// <param name="damage"></param>
    public void ReceiveDamage(int damage)
    {
        _hp -= damage;
        Debug.Log("Enemyhp: " + _hp);       
    }
}