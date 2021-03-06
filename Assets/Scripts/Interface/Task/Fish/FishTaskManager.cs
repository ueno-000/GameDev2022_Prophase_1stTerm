using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲーム上のチュートリアルを管理するマネージャクラス
/// </summary>
public class FishTaskManager : MonoBehaviour
{

    // UI
    [SerializeField] RectTransform TaskTextArea;
    [SerializeField] Text TaskText;

    // チュートリアルタスク
    protected ITaskInterface currentTask;
    protected List<ITaskInterface> _task;


    void Start()
    {

        // チュートリアルの一覧
        _task = new List<ITaskInterface>()
        {
            new FishTask1(),
            new FishTask2(),
            new FishTask3(),
            new FishTask4(),
            new FishTask5(),
        };

        // 最初のチュートリアルを設定
        StartCoroutine(SetCurrentTask(_task.First()));

    }

    void Update()
    {
        // チュートリアルが存在し実行されていない場合に処理
        if (currentTask != null )
        {
            // 現在のチュートリアルが実行されたか判定
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
    /// 新しいチュートリアルタスクを設定する
    /// </summary>
    /// <param name="task"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    protected IEnumerator SetCurrentTask(ITaskInterface task, float time = 0)
    {
        // timeが指定されている場合は待機
        yield return new WaitForSeconds(time);

        currentTask = task;

        // UIにタイトルと説明文を設定
        TaskText.text = task._getText();

        // チュートリアルタスク設定時用の関数を実行
        task.OnTaskSetting();

    }

}