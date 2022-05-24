using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,IPause
{
    [SerializeField] float _movePower = 3;
    [SerializeField] Transform _muzzle;
    Rigidbody _rb = default;
    /// <summary>入力された方向の XZ 平面でのベクトル</summary>
    Vector3 _dir;

    // エディタから「BulletGenerator」スクリプトを設定
    public BulletGenerator _bulletGenerator;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _dir = Vector3.forward * v + Vector3.right * h;
        // カメラのローカル座標系を基準に dir を変換する
        _dir = Camera.main.transform.TransformDirection(_dir);
        // カメラは斜め下に向いているので、Y 軸の値を 0 にして「XZ 平面上のベクトル」にする
        _dir.y = 0;
        // キャラクターを「現在の（XZ 平面上の）進行方向」に向ける
        Vector3 forward = _rb.velocity;
        forward.y = 0;

        if (forward != Vector3.zero)
        {
            this.transform.forward = forward;
        }

        // スペースキーを押した時、「Player」の位置から弾を発射する
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _bulletGenerator.FireBullet(_muzzle.position);
        }
    }

    void FixedUpdate()
    {
        // 「力を加える」処理は力学的処理なので FixedUpdate で行うこと
        _rb.AddForce(_dir.normalized * _movePower, ForceMode.Force);
    }

    public void Pause()
    {
        _rb.Sleep();
        _rb.isKinematic = true;
    }
    public void Resume()
    {
        // Rigidbody の活動を再開し、保存しておいた速度・回転を戻す
        _rb.isKinematic = false;
        _rb.WakeUp();
    }

}
