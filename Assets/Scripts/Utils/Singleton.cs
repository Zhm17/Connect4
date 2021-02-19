using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T: Singleton<T>
{
    private static T instance = null;

    // Game Instance Singleton
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.LogError("Singleton not found ... " + typeof(T).Name);
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else if (instance != (this as T))
        {
            DestroyImmediate(this);
            return;
        }
    }

    protected void OnDestroy()
    {
        if (instance == (this as T))
        {
            instance = null;
        }
    }

}
