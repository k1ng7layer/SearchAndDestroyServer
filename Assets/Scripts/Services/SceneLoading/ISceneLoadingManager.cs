using System;
using UniRx.Async;

namespace Services.SceneLoading
{
    public interface ISceneLoadingManager
    {
        event Action Loaded;
        void LoadGameLevel(ELevelName levelName);
        UniTask LoadGameLevelAsync(ELevelName levelName);
        void LoadGameFromMenu();
        void LoadGameFromSplash();
        UniTask LoadGameLevelFromSplashAsync();
        float GetProgress();
    }
}