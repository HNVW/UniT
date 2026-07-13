#nullable enable
namespace UniT
{
    using Audio.DI;
    using Data.Converters.DI;
    using Data.DI;
    using Data.Serializers.DI;
    using Data.Storages.DI;
    using Entities.DI;
    using InternalDI;
    using Lifecycle.DI;
    using Logging.DI;
    using Pooling.DI;
    using ResourceManagement.DI;
    using UI.DI;
    using UnityEngine;
    using UnityEngine.EventSystems;

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