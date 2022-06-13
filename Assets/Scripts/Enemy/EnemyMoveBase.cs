using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBase : MonoBehaviour, IPause
{
    [SerializeField] int _damageValue = 2;
    //�ړ����x
    [SerializeField] float _speed = 0.5f;
    GameObject _player;
    [SerializeField] Animator _anim;

    float _time;
    private void Start()
    {
        _player = GameObject.Find("Player");
        _anim = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 _playerPos = _player.transform.position;
        //y���̓v���C���[�Ɠ����ɂ���
        _playerPos.y = transform.position.y;
        // �v���C���[�Ɍ�������
        transform.LookAt(_playerPos);

        //�I�u�W�F�N�g��O�����Ɉړ�����
        transform.position = transform.position + transform.forward * _speed * Time.deltaTime;

    }
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            _player.GetComponent<IReceiveDamage>().ReceiveDamage(_damageValue);
        }
    }

    public void Pause(float time)
    {
        _time = time;
        _speed = 0;
        _anim.SetBool("isPause", true);
        StartCoroutine("PauseTime");
    }
    public void Resume()
    {
        _anim.SetBool("isPause", false);
        _speed = 2;
    }

    IEnumerator PauseTime()
    {
        yield return new WaitForSeconds(_time);
        Resume();
    }


}