using UnityEngine;

namespace _Project.Services
{
    public sealed class EntryPoint 
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void SetUp()
        {
            Application.targetFrameRate = Constants.TARGET_FRAME_RATE;
            Debug.Log($"</color=green>target framerate: {Application.targetFrameRate}</color>");
        }
    }
}
