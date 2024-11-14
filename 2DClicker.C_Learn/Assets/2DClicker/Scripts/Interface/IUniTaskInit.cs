using Cysharp.Threading.Tasks;

/// <summary>
/// 비동기 전용 Init 인터페이스
/// </summary>
public interface IUniTaskInit
{
    /// <summary>
    /// 비동기 -> 동기 Init
    /// </summary>
    public UniTask Init();
}