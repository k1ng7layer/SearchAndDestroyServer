using UnityEngine.SceneManagement;

namespace Services.SceneLoading
{
    public class SceneLoadingArgs
    {
        
        public SceneLoadingArgs(Scene scene, LoadSceneMode loadSceneMode)
        {
            Scene = scene;
            LoadSceneMode = loadSceneMode;
        }
        
        public Scene Scene { get; }
        public LoadSceneMode LoadSceneMode { get; }
    }
}