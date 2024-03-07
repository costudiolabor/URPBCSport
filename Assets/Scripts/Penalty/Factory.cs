using System;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class Factory {
    public T Get<T>(T original, Vector3 position, Quaternion rotation) where T : Object {
        return (T)Object.Instantiate((Object)original, position, rotation);
    }
    public T Get<T>(T original, Vector3 position) where T : Object {
        return (T)Object.Instantiate((Object)original, position, Quaternion.identity);
    }
    
}