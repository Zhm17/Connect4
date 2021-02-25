using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public delegate void ShowWindowHandler(UIWindowID id);
    public event ShowWindowHandler ShowEvent;

    [SerializeField]
    private MainMenuWindow MainMenuWindow;
    [SerializeField]
    private InGameWindow InGameWindow;
    [SerializeField]
    private GameOverWindow GameOverWindow;

    [SerializeField]
    private UIWindowID currentWindow = UIWindowID.MAIN_MENU;
    public UIWindowID CurrentWindow
    {
        get
        {
            return currentWindow;
        }

        private set
        {
            currentWindow = value;
        }
    }

    protected override void Init()
    {
        ShowEvent += OnChangeCurrentWindow;
        ShowEvent += MainMenuWindow.Show;
        ShowEvent += InGameWindow.Show;
        ShowEvent += GameOverWindow.Show;
    }

    private void OnDestroy()
    {
        ShowEvent -= OnChangeCurrentWindow;
        ShowEvent -= MainMenuWindow.Show;
        ShowEvent -= InGameWindow.Show;
        ShowEvent -= GameOverWindow.Show;
    }

    private void Start()
    {
        ShowEvent(UIWindowID.MAIN_MENU);
    }

    public void ShowWindow(UIWindowID id)
    {
        OnShow(id);
    }

    protected void OnShow(UIWindowID id)
    {
        if (ShowEvent != null)
        {
            ShowEvent(id);
        } 
    }

    private void OnChangeCurrentWindow(UIWindowID id)
    {
        /*Debug.Log(transform.name + " : Show event ID = " + id);*/
        CurrentWindow = id;
    } 

}
