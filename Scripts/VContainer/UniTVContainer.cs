#nullable enable
namespace UniT
{
    using Audio.DI;
    using Data.DI;
    using DI;
    using Entities.DI;
    using Lifecycle.DI;
    using Logging.DI;
    using Pooling.DI;
    using ResourceManagement.DI;
    using UI.DI;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using VContainer;

    public static class UniTVContainer
    {
        public static void RegisterUniT(this IContainerBuilder builder, Canvas canvasPrefab, EventSystem eventSystemPrefab)
        {
            builder.RegisterDependencyContainer();
            builder.RegisterUnityLoggerManager();
            builder.RegisterAddressablesAssetManager();
            builder.RegisterAddressablesSceneManager();
            builder.RegisterUnityExternalAssetManager();
            builder.RegisterConverterManager();
            builder.RegisterDefaultSerializer();
            builder.RegisterUnitySerializer();
            builder.RegisterAssetStorage();
#if !UNITY_WEBGL
            builder.RegisterFileStorage();
#else
            builder.RegisterPlayerPrefsStorage();
#endif
            builder.RegisterDataManager();
            builder.RegisterObjectPoolManager();
            builder.RegisterEntityManager();
            builder.RegisterUIManager(canvasPrefab, eventSystemPrefab);
            builder.RegisterAudioManager();
            builder.RegisterLifecycleManager();
        }
    }
}