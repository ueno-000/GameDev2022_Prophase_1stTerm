using UnityEngine;

public class EnemyMoveBase: MonoBehaviour,IPause
{
    [SerializeField] int _damageValue = 2;
    //�ړ����x
    [SerializeField] float _speed;
    GameObject _player;
    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        // �쐬���ăv���C���[�̍��W���i�[
        Vector3 _playerPos = _player.transform.position;
        //�v���C���[��X�AZ�̂ݎQ��
        _playerPos.y = transform.position.y;
        // �v���C���[�Ɍ�������
        transform.LookAt(_playerPos);

        //�I�u�W�F�N�g��O�����Ɉړ�����
        transform.position = transform.position + transform.forward * _speed * Time.deltaTime;
        
    }
    private void OnCollisionStay(Collision collision)
    {
        var damagetarget = _player.GetComponent<IReceiveDamage>();
        
        if (collision.gameObject.tag == "Player"  && damagetarget != null)
        {
            _player.GetComponent<IReceiveDamage>().ReceiveDamage(_damageValue);
        }
    }

    public void Pause()
    {
        _speed = 0;
    }
    public void Resume()
    {
        _speed = 2;
    }
}