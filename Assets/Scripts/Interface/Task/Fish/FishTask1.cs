
public class FishTask1 : ITaskInterface
{
    public string _getText()
    {
        return "効果時間を0.5秒増加";
    }
    public void OnTaskSetting()
    {
    }
    public bool _isCheckTask()
    {
        return true;
    }
}
