public interface ITaskInterface
{

    /// <summary>
    /// ���������擾����
    /// </summary>
    /// <returns></returns>
    string _getText();

    /// <summary>
    /// �`���[�g���A���̃^�X�N���ݒ肳�ꂽ�Ƃ����s�����
    /// </summary>
    void OnTaskSetting();

    /// <summary>
    ///�`���[�g���A�����B�����ꂽ������ 
    /// </summary>
    /// <returns></returns>
    bool _isCheckTask();
}
