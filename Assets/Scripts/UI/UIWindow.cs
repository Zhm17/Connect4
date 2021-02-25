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
        set
        {
            _id = value;
        }
    }


    private void Start()
    {
        Init();
    }

    protected abstract void Init();

    public virtual void Show(UIWindowID id)
    {
        //Debug.Log(transform.name + " : Show event ID = " + id );
        
        if (id != ID)
        {
            Hide();
            return;
        }

        foreach (Transform t in GetComponentsInChildren<Transform>(true))
        {
            if(t != transform)
                t.gameObject.SetActive(true);
        }
       
    }

    private void Hide()
    {
        foreach (Transform t in GetComponentsInChildren<Transform>(true))
        {
            if (t != transform)
                t.gameObject.SetActive(false);
        }
    }
}
