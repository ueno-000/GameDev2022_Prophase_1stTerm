using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>�ړ����鎞�ɂ������</summary>
    [SerializeField] float _speed = 3f;
    Rigidbody2D _rb = default;
    /// <summary>�̗�</summary>
    public float _life = 5f;

    //HpController _hpController;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //_hpController = GameObject.FindObjectOfType<HpController>();
    }

    // Update is called once per frame
    void Update()
    {
        //WASD�擾

        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 dir = new Vector2(h, v);
        _rb.velocity = dir.normalized * _speed;
    }
}
