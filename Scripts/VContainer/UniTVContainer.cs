#nullable enable
namespace UniT
{
    using Audio.Default.DI;
    using Data.Converters.Default.DI;
    using Data.Default.DI;
    using Data.Serializers.Default.DI;
    using Data.Serializers.Unity.DI;
    using Data.Storages.Asset.DI;
    using Entities.Default.DI;
    using Lifecycle.Default.DI;
    using Logging.Unity.DI;
    using Pooling.Default.DI;
    using ResourceManagement.Addressables.DI;
    using ResourceManagement.Unity.DI;
    using UI.Default.DI;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using VContainer;
#if !UNITY_WEBGL
    using Data.Storages.File.DI;
#else
    using Data.Storages.PlayerPrefs.DI;
#endif

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