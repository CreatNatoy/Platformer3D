using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuButton;
    [SerializeField] private GameObject _menuWindows;
    [SerializeField] private GameObject _menuFisnih; 
    [SerializeField] private TimeManager _timeManager; 
    [SerializeField] private MonoBehaviour[] _componentsToDisable;
    public void OpenMenuWindow()
    {
        _menuButton.SetActive(false);
        _menuWindows.SetActive(true);
        SwitchStateComponents(false);
    }

    public void CloseMenuWindow()
    {
        _menuButton.SetActive(true);
        _menuWindows.SetActive(false);
        SwitchStateComponents(true);
    }

    public void OpenMenuFisnih()
    {
        _menuFisnih.SetActive(true);
        SwitchStateComponents(false );
    }

    private void SwitchStateComponents(bool state)
    {
        for(int i = 0; i < _componentsToDisable.Length; i++)
        {
            _componentsToDisable[i].enabled = state;
        }

        _timeManager.IsPause(!state); 
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
