using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        // Singleton Init

        if (Instance)
        {
            if (Instance.Equals((T)this))
            {
                return;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Instance = (T)this;
            DontDestroyOnLoad(this);
        }
    }
}
