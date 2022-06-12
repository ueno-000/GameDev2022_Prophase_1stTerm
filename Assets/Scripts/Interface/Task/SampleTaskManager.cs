using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �Q�[����̃`���[�g���A�����Ǘ�����}�l�[�W���N���X
/// </summary>
public class SampleTaskManager : MonoBehaviour
{
    // �`���[�g���A���pUI
    protected RectTransform TaskTextArea;
    protected Text TaskText;

    // �`���[�g���A���^�X�N
    protected ITaskInterface currentTask;
    protected List<ITaskInterface> _task;


    void Start()
    {
        // �`���[�g���A���\���pUI�̃C���X�^���X�擾
        TaskTextArea = GameObject.Find("SkillName").GetComponent<RectTransform>();
        TaskText = TaskTextArea.Find("Text").GetComponentInChildren<Text>();

        // �`���[�g���A���̈ꗗ
        _task = new List<ITaskInterface>()
        {
            new FishTask1()
        };

        // �ŏ��̃`���[�g���A����ݒ�
        StartCoroutine(SetCurrentTask(_task.First()));

    }

    void Update()
    {
        // �`���[�g���A�������݂����s����Ă��Ȃ��ꍇ�ɏ���
        if (currentTask != null )
        {
            // ���݂̃`���[�g���A�������s���ꂽ������
            if (currentTask._isCheckTask())
            {  
                _task.RemoveAt(0);

                var nextTask = _task.FirstOrDefault();
                if (nextTask != null)
                {
                    StartCoroutine(SetCurrentTask(nextTask, 1f));
                }
            }
        }

    }
    /// <summary>
    /// �V�����`���[�g���A���^�X�N��ݒ肷��
    /// </summary>
    /// <param name="task"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    protected IEnumerator SetCurrentTask(ITaskInterface task, float time = 0)
    {
        // time���w�肳��Ă���ꍇ�͑ҋ@
        yield return new WaitForSeconds(time);

        currentTask = task;

        // UI�Ƀ^�C�g���Ɛ�������ݒ�
        TaskText.text = task._getText();

        // �`���[�g���A���^�X�N�ݒ莞�p�̊֐������s
        task.OnTaskSetting();

    }

}