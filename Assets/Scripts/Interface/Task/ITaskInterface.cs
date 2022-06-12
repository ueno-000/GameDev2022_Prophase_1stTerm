public interface ITaskInterface
{

    /// <summary>
    /// 説明文を取得する
    /// </summary>
    /// <returns></returns>
    string _getText();

    /// <summary>
    /// チュートリアルのタスクが設定されたとき実行される
    /// </summary>
    void OnTaskSetting();

    /// <summary>
    ///チュートリアルが達成されたか判定 
    /// </summary>
    /// <returns></returns>
    bool _isCheckTask();
}
