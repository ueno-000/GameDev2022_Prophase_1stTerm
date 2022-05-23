using UnityEngine;
using System.Collections.Generic; // .Generic��Y�ꂸ�ɁI

public class BulletGenerator : MonoBehaviour
{

    // �G�f�B�^����e�Ƃ��Ďg���v���n�u��ݒ�
    public GameObject pf_Bullet;
    // �e����~���Ă���List
    List<BulletController> list_Bullets = new List<BulletController>();
    // ���~���Ă����e�̐�
    const int MAX_BULLETS = 10;

    void Start()
    {
        BulletController bullet;
        // �ŏ��Ɉ�萔�̒e����~���Ă���
        for (int i = 0; i < MAX_BULLETS; i++)
        {
            // �e�̐���
            bullet = ((GameObject)Instantiate(pf_Bullet)).GetComponent<BulletController>();
            // �e���A���́uBulletGenerator�v�I�u�W�F�N�g�̎q�ɂ��Ă���
            bullet.transform.parent = this.transform;
            // ���ˑO�͔�A�N�e�B�u�ɂ��Ă���
            bullet.gameObject.SetActive(false);
            // List�ɒǉ�
            list_Bullets.Add(bullet);
        }
    }

    public void FireBullet(Vector3 startPos)
    {
        // List�̒��g���ŏ�����m�F���Ă����A��A�N�e�B�u�̃I�u�W�F�N�g��T��
        for (int i = 0; i < list_Bullets.Count; i++)
        {
            if (list_Bullets[i].gameObject.activeSelf == false)
            {
                // ��A�N�e�B�u�̒e�𔭎˂�����
                list_Bullets[i].Init(startPos);
                return;
            }
        }
        // LINQ��m���Ă���΂���ł���k�Busing System.Linq;��Y�ꂸ�ɁB
        // BulletScript bullet = list_Bullets.FirstOrDefault(b => !b.gameObject.activeSelf);
        // if(bullet) bullet.Init(startPos);
    }
}