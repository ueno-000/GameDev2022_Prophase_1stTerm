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
        // Transformをキャッシュしておく
        transf_Bullet = GetComponent<Transform>();
        // 弾の位置を発射場所に設定
        transf_Bullet.position = startPos;
        // 弾が飛んでいられる時間を設定
        bulletLifeTimer = BULLET_LIFE_TIME;
        // 弾をアクティブにする
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // 弾の移動
        transf_Bullet.Translate(transf_Bullet.forward * Time.deltaTime * moveSpeed);
        // 弾の持続時間をカウント
        bulletLifeTimer -= Time.deltaTime;
        // 一定時間たったら弾は非アクティブにする
        if (bulletLifeTimer < 0) this.gameObject.SetActive(false);
    }

}
