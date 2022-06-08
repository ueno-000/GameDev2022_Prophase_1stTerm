using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    int StageSize = 80;
    int StageIndex;

    /// <summary> Player </summary>
    [SerializeField] Transform Target;
    /// <summary> �X�e�[�W�̃v���n�u </summary>
    [Header("�X�e�[�W�̃v���n�u"),SerializeField] GameObject[] stagenum;
    /// <summary>//�X�^�[�g���ɐ�������X�e�[�W�̃C���f�b�N�X</summary>
    [Header("�X�^�[�g���ɐ�������X�e�[�W�̃C���f�b�N�X"), SerializeField] int FirstStageIndex;
    /// <summary> ���O�ɐ������Ă����X�e�[�W�̃C���f�b�N�X </summary>
    [Header("���O�ɐ������Ă����X�e�[�W�̃C���f�b�N�X"), SerializeField] int aheadStage; //���O�ɐ������Ă����X�e�[�W
    /// <summary> ���������X�e�[�W�̃��X�g</summary>
    [Header("���������X�e�[�W�̃��X�g"), SerializeField] List<GameObject> StageList = new List<GameObject>();//���������X�e�[�W�̃��X�g

    // Start is called before the first frame update
    void Start()
    {
        StageIndex = FirstStageIndex - 1;
        StageManager(aheadStage);
    }

    // Update is called once per frame
    void Update()
    {
        int targetPosIndex = (int)(Target.position.z / StageSize);

        if (targetPosIndex + aheadStage > StageIndex)
        {
            StageManager(targetPosIndex + aheadStage);
        }
    }
    void StageManager(int maps)
    {
        if (maps <= StageIndex)
        {
            return;
        }

        for (int i = StageIndex + 1; i <= maps; i++)//�w�肵���X�e�[�W�܂ō쐬����
        {
            GameObject stage = MakeStage(i);
            StageList.Add(stage);
        }

        while (StageList.Count > aheadStage + 1)//�Â��X�e�[�W���폜����
        {
            DestroyStage();
        }

        StageIndex = maps;
    }

    /// <summary>
    /// �X�e�[�W�����̃��\�b�h
    /// </summary>
    /// <param name="index">�X�e�[�W�̃C���f�b�N�X</param>
    /// <returns></returns>
    GameObject MakeStage(int index)
    {
        int nextStage = Random.Range(0, stagenum.Length);

        GameObject stageObject = (GameObject)Instantiate(stagenum[nextStage], new Vector3(0, 0, index * StageSize), Quaternion.identity);

        return stageObject;
    }
        /// <summary>
        /// �X�e�[�W���������\�b�h
        /// </summary>
    void DestroyStage()
    {
        GameObject oldStage = StageList[0];
        StageList.RemoveAt(0);
        oldStage.SetActive(false);
    }

}
