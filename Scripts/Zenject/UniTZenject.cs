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
    using Zenject;
#if !UNITY_WEBGL
    using Data.Storages.File.DI;
#else
    using Data.Storages.PlayerPrefs.DI;
#endif

    public static class UniTZenject
    {
        public static void BindUniT(this DiContainer container, Canvas canvasPrefab, EventSystem eventSystemPrefab)
        {
            container.BindDependencyContainer();
            container.BindUnityLoggerManager();
            container.BindAddressablesAssetManager();
            container.BindAddressablesSceneManager();
            container.BindUnityExternalAssetManager();
            container.BindConverterManager();
            container.BindDefaultSerializer();
            container.BindUnitySerializer();
            container.BindAssetStorage();
#if !UNITY_WEBGL
            container.BindFileStorage();
#else
            container.BindPlayerPrefsStorage();
#endif
            container.BindDataManager();
            container.BindObjectPoolManager();
            container.BindEntityManager();
            container.BindUIManager(canvasPrefab, eventSystemPrefab);
            container.BindAudioManager();
            container.BindLifecycleManager();
        }
    }
}