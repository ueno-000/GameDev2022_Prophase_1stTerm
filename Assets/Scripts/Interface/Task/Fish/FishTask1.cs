
public class FishTask1 : ITaskInterface
{
    public string _getText()
    {
        return "スキルを獲得する";
    }
    public void OnTaskSetting()
    {
    }
    public bool _isCheckTask()
    {
        return true;
    }
}
