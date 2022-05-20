using UnityEngine;

public class EnemyMoveBase: MonoBehaviour
{
    //�ړ����x
    [SerializeField] float _speed;

    GameObject _player;
    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        // �ϐ� targetPos ���쐬���ă^�[�Q�b�g�I�u�W�F�N�g�̍��W���i�[
        Vector3 targetPos = _player.transform.position;
        //�v���C���[��X�AZ�̂ݎQ��
        targetPos.y = transform.position.y;
        // �v���C���[�Ɍ�������
        transform.LookAt(targetPos);

        //�I�u�W�F�N�g�̈ʒu�ƃ^�[�Q�b�g�I�u�W�F�N�g�̋������i�[
        float distance = Vector3.Distance(transform.position, _player.transform.position);

        //�I�u�W�F�N�g��O�����Ɉړ�����
        transform.position = transform.position + transform.forward * _speed * Time.deltaTime;
        
    }
}