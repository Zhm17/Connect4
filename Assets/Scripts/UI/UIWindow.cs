using UnityEngine;

public abstract class UIWindow : MonoBehaviour
{
    [SerializeField]
    private UIWindowID _id;
    public UIWindowID ID
    {
        get
        {
            return _id;
        }
    }

    private void Awake()
    {
        UIManager.Show += Show;
        Init();
    }

    private void OnDisable()
    {
        UIManager.Show -= Show;
    }

    private void OnDestroy()
    {
        UIManager.Show -= Show;
    }


    protected abstract void Init();

    protected virtual void Show(UIWindowID id)
    {
        foreach (GameObject g in GetComponentsInChildren<GameObject>())
        {
            if(g!=this)
                g.SetActive(true);
        }
       
    }

    protected virtual void Hide()
    {
        foreach (GameObject g in GetComponentsInChildren<GameObject>())
        {
            if(g!=this)
                g.SetActive(false);
        }
    }
}
