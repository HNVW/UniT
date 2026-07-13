#nullable enable
namespace UniT
{
    using Audio.Default.DI;
    using Data.Converters.Default.DI;
    using Data.Default.DI;
    using Data.Serializers.Default.DI;
    using Data.Serializers.Unity.DI;
    using Data.Storages.Asset.DI;
    using InternalDI;
    using Entities.Default.DI;
    using Lifecycle.Default.DI;
    using Logging.Unity.DI;
    using Pooling.Default.DI;
    using ResourceManagement.Addressables.DI;
    using ResourceManagement.Unity.DI;
    using UI.Default.DI;
    using UnityEngine;
    using UnityEngine.EventSystems;
#if !UNITY_WEBGL
    using Data.Storages.File.DI;
#else
    using Data.Storages.PlayerPrefs.DI;
#endif

    public static class UniTInternalDI
    {
        public static void AddUniT(this DependencyContainer container, Canvas canvasPrefab, EventSystem eventSystemPrefab)
        {
            container.AddUnityLoggerManager();
            container.AddAddressablesAssetManager();
            container.AddAddressablesSceneManager();
            container.AddUnityExternalAssetManager();
            container.AddConverterManager();
            container.AddDefaultSerializer();
            container.AddUnitySerializer();
            container.AddAssetStorage();
#if !UNITY_WEBGL
            container.AddFileStorage();
#else
            container.AddPlayerPrefsStorage();
#endif
            container.AddDataManager();
            container.AddObjectPoolManager();
            container.AddEntityManager();
            container.AddUIManager(canvasPrefab, eventSystemPrefab);
            container.AddAudioManager();
            container.AddLifecycleManager();
        }
    }
}