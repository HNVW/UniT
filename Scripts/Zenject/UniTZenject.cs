#nullable enable
namespace UniT
{
    using Audio.DI;
    using Data.Converters.DI;
    using Data.DI;
    using Data.Serializers.DI;
    using Data.Storages.DI;
    using DI;
    using Entities.DI;
    using Lifecycle.DI;
    using Logging.DI;
    using Pooling.DI;
    using ResourceManagement.DI;
    using UI.DI;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using Zenject;

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