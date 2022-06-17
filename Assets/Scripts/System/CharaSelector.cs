using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Cinemachine;

/// <summary>
/// �L�����N�^�[�I��
/// </summary>
public class CharaSelector : MonoBehaviour
{
    [SerializeField] EventSystem _eventSystem;
    [SerializeField] Text[] _texts;
    [SerializeField] GameObject _firstObj;

    // �o�[�`�����J�����ꗗ
    [SerializeField] private CinemachineVirtualCamera[] _virtualCameraList;
    // ��I�����̃o�[�`�����J�����̗D��x
    [SerializeField] private int _unselectedPriority = 0;
    // �I�����̃o�[�`�����J�����̗D��x
    [SerializeField] private int _selectedPriority = 10;
    // �I�𒆂̃o�[�`�����J�����̃C���f�b�N�X
    private int _currentCamera = 0;

    // �o�[�`�����J�����̗D��x������
    private void Awake()
    {
        // �o�[�`�����J�������ݒ肳��Ă��Ȃ���΁A�������Ȃ�
        if (_virtualCameraList == null || _virtualCameraList.Length <= 0)
            return;

        // �o�[�`�����J�����̗D��x��������
        for (var i = 0; i < _virtualCameraList.Length; ++i)
        {
            _virtualCameraList[i].Priority =
                (i == _currentCamera ? _selectedPriority : _unselectedPriority);
        }
    }
    private void Start()
    {
        TextMethod(_firstObj);
    }
    // �t���[���X�V
    private void Update()
    {
        // �o�[�`�����J�������ݒ肳��Ă��Ȃ���΁A�������Ȃ�
        if (_virtualCameraList == null || _virtualCameraList.Length <= 0)
            return;

    }

    public void ChangeCamera(int num)
    {
        // �ȑO�̃o�[�`�����J�������I��
        var vCamPrev = _virtualCameraList[_currentCamera];
        vCamPrev.Priority = _unselectedPriority;

        // �Ǐ]�Ώۂ����Ԃɐ؂�ւ�

         _currentCamera = num;

        // ���̃o�[�`�����J������I��
        var vCamCurrent = _virtualCameraList[_currentCamera];
        vCamCurrent.Priority = _selectedPriority;
    }
    public void TextMethod(GameObject obj)
    {
        _texts[0].text = obj.GetComponent<State>().NAME.ToString();
        _texts[1].text = "SPD:+" + obj.GetComponent<State>().SPD.ToString();
        _texts[2].text = "HP:+" + obj.GetComponent<State>().HP.ToString();
        _texts[3].text = obj.GetComponent<State>().FlavorText.ToString();
    }
}