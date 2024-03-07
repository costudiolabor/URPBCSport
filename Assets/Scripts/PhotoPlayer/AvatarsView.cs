using UnityEngine;

public class AvatarsView : View {
    [SerializeField] private GameObject[] avatars;

    private int _lastIndex;
    private const int IdleAvatar = 0;
    private const int KickBallAvatar = 1;
    private const int BallIdleAvatar = 2;
    private const int BallWaitingAvatar = 3;
    
    public void Initialize() => HideAvatars();
    private void HideAvatars() {
        foreach (var avatar in avatars) {
            avatar.SetActive(false);
        }
    }
    public void Idle() => SetActiveObject(IdleAvatar);
    public void KickBall() => SetActiveObject(KickBallAvatar);
    public void BallIdle() => SetActiveObject(BallIdleAvatar);
    public void BallWaiting() => SetActiveObject(BallWaitingAvatar);

    private void SetActiveObject(int currentIndex) {
        if (_lastIndex == currentIndex) return;
        avatars[_lastIndex].SetActive(false);
        avatars[currentIndex].SetActive(true);
        _lastIndex = currentIndex;
    }
}
