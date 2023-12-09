using UniRx.Async;

namespace Services.SceneLoading
{
    public interface ISceneLoadingManager
    {
        void LoadGameLevel(ELevelName levelName);
        UniTask LoadGameLevelAsync(ELevelName levelName);
        void LoadGameFromMenu();
        void LoadGameFromSplash();
        float GetProgress();
    }
}