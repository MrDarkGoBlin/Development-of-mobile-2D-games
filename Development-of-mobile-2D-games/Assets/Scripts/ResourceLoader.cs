using UnityEngine;

public static class ResourceLoader 
{
   public static GameObject LoadPrefabs(ResourcePath path)
    {
        return Resources.Load<GameObject>( path.PathResource);
    }
}
