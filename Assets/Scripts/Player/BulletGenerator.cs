using UnityEngine;
using System.Collections.Generic; // .Genericを忘れずに！

public class BulletGenerator : MonoBehaviour
{

    // エディタから弾として使うプレハブを設定
    public GameObject pf_Bullet;
    // 弾を備蓄しておくList
    List<BulletController> list_Bullets = new List<BulletController>();
    // 備蓄しておく弾の数
    const int MAX_BULLETS = 10;

    void Start()
    {
        BulletController bullet;
        // 最初に一定数の弾を備蓄しておく
        for (int i = 0; i < MAX_BULLETS; i++)
        {
            // 弾の生成
            bullet = ((GameObject)Instantiate(pf_Bullet)).GetComponent<BulletController>();
            // 弾を、この「BulletGenerator」オブジェクトの子にしておく
            bullet.transform.parent = this.transform;
            // 発射前は非アクティブにしておく
            bullet.gameObject.SetActive(false);
            // Listに追加
            list_Bullets.Add(bullet);
        }
    }

    public void FireBullet(Vector3 startPos)
    {
        // Listの中身を最初から確認していき、非アクティブのオブジェクトを探す
        for (int i = 0; i < list_Bullets.Count; i++)
        {
            if (list_Bullets[i].gameObject.activeSelf == false)
            {
                // 非アクティブの弾を発射させる
                list_Bullets[i].Init(startPos);
                return;
            }
        }
        // LINQを知っていればこれでもおk。using System.Linq;を忘れずに。
        // BulletScript bullet = list_Bullets.FirstOrDefault(b => !b.gameObject.activeSelf);
        // if(bullet) bullet.Init(startPos);
    }
}