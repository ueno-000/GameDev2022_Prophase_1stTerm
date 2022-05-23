using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Transform transf_Bullet;

    const float BULLET_LIFE_TIME = 3;
    float bulletLifeTimer;
    float moveSpeed = 10;

    public void Init(Vector3 startPos)
    {
        // Transform���L���b�V�����Ă���
        transf_Bullet = GetComponent<Transform>();
        // �e�̈ʒu�𔭎ˏꏊ�ɐݒ�
        transf_Bullet.position = startPos;
        // �e�����ł����鎞�Ԃ�ݒ�
        bulletLifeTimer = BULLET_LIFE_TIME;
        // �e���A�N�e�B�u�ɂ���
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // �e�̈ړ�
        transf_Bullet.Translate(transf_Bullet.forward * Time.deltaTime * moveSpeed);
        // �e�̎������Ԃ��J�E���g
        bulletLifeTimer -= Time.deltaTime;
        // ��莞�Ԃ�������e�͔�A�N�e�B�u�ɂ���
        if (bulletLifeTimer < 0) this.gameObject.SetActive(false);
    }

}
