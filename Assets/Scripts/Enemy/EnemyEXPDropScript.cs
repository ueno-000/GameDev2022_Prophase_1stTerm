using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy���S���Ɍo���l���h���b�v������script
/// </summary>

public class EnemyEXPDropScript : MonoBehaviour, IReceiveDamage
{
   
    [Header("�o���l��Prefab���A�^�b�`����"), SerializeField] private GameObject _retentionExpPrefab;

    [Header("�p�����[�^�[")]
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
    /// �̗͒l���O��؂����ꍇ�Ɍo���l���h���b�v�����郁�\�b�h
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


    /// <summary> �_���[�W����</summary>
    /// <param name="damage"></param>
    public void ReceiveDamage(int damage)
    {
        HP -= damage;
    }
}
