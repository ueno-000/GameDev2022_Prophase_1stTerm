using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    /// <summary> Player </summary>
    [SerializeField] Transform Target;
    /// <summary> ステージのプレハブ </summary>
    [Header("ステージのプレハブ"), SerializeField] GameObject[] stagenum;
    /// <summary>//スタート前のステージの数</summary>
    [Header("スタート前のステージの数"), SerializeField] int FirstStageIndex;
    /// <summary> 生成するステージの数 </summary>
    [Header("生成するステージの列"), SerializeField] int aheadStage;
    /// <summary> 生成したステージのリスト</summary>
    [Header("生成したステージのリスト"), SerializeField] List<GameObject> StageList = new List<GameObject>();
    /// <summary> 非アクティブにしたステージのリスト</summary>
    [Header("非アクティブにしたステージのリスト"), SerializeField] List<GameObject> FalseList = new List<GameObject>();

    [Header("ステージグリットリスト"), SerializeField]
    private List<stageList> GritList = new List<stageList>();

    [System.Serializable]
    class stageList
    {
        public List<int> StageGrit = new List<int>();
    }

    [SerializeField] int _mapXnum = 2;
    [SerializeField] int _mapZnum = 2;


    [SerializeField] int targetPosIndexX;
    [SerializeField] int targetPosIndexZ;

    int StageSize = 84;

    int StageIndex;

    /// <summary>
    /// ステージ生成時の回転に使う
    /// </summary>
    float[] _mapRotates = new float[4] { 0, 90, 180, -90 };

    // Start is called before the first frame update
    void Start()
    {
        StageIndex = FirstStageIndex - 1;/*new int[FirstStageIndex - 1, FirstStageIndex - 1];*/
        StageManager(aheadStage);
    }


    void Update()
    {
        targetPosIndexX = (int)(Target.position.x / StageSize);
        targetPosIndexZ = (int)(Target.position.z / StageSize);

        //プレイヤーがステージ移動したらの処理
        //
        if (targetPosIndexZ + aheadStage > StageIndex)
        {
            StageManager(targetPosIndexZ + aheadStage);
        }
    }

    /// <param name="maps">今あるステージの数</param>
    void StageManager(int maps)
    {
        if (maps <= StageIndex)
        {
            return;
        }

        for (int i = StageIndex + 1; i <= maps; i++)//指定したステージまで作成する
        {
            GameObject stage = MakeStage(i);
            StageList.Add(stage);
        }

        while (StageList.Count > aheadStage + 2)//古いステージを削除する
        {
            DestroyStage();
        }

        StageIndex = maps;
    }

    /// <summary>
    /// ステージ生成のメソッド
    /// </summary>
    /// <param name="index">ステージのインデックス</param>
    /// <returns></returns>
    GameObject MakeStage(int index)
    {
        //生成するステージをランダムに選択する
        int nextStage = Random.Range(0, stagenum.Length);
        //生成する角度をランダムに選択する
        int rotateStage = Random.Range(0, _mapRotates.Length);

        GameObject stageObject =
            Instantiate(stagenum[nextStage], new Vector3(0, 0, index * StageSize), Quaternion.Euler(0, _mapRotates[rotateStage], 0));

        return stageObject;
    }
    /// <summary>
    /// ステージを消すメソッド
    /// </summary>
    void DestroyStage()
    {
        GameObject oldStage = StageList[0];
        StageList.RemoveAt(0);
        oldStage.SetActive(false);
        FalseList.Add(oldStage);
    }

}
