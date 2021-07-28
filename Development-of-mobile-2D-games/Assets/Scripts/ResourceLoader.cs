using UnityEngine;
namespace Tools
{
    public static class ResourceLoader
    {
        public static Sprite LoadSprite(ResourcePath path)
        {
            return Resources.Load<Sprite>(path.PathResource);
        }

        public static GameObject LoadPrefabs(ResourcePath path)
        {
            return Resources.Load<GameObject>(path.PathResource);
        }
        public static T InstantiateObject<T>(T prefab, Transform parent, bool worldPositionStays) where T : Object
        {
            return Object.Instantiate(prefab, parent, worldPositionStays);
        }

        public static T LoadAndInstantiateObject<T>(ResourcePath path, Transform parent, bool worldPositionStays) where T : Object
        {
            var prefab = LoadObject<T>(path);
            return InstantiateObject(prefab, parent, worldPositionStays);
        }

    }
}
