public interface IPause 
{
    /// <summary>一時停止のための処理を実装する</summary>
    void Pause(float time);
    /// <summary>再開のための処理を実装する</summary>
    void Resume();
}
