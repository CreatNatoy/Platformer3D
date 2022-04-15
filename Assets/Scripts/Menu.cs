using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuButton;
    [SerializeField] private GameObject _menuWindows;
    [SerializeField] private MonoBehaviour[] _componentsToDisable; 

    public void OpenMenuWindow()
    {
        _menuButton.SetActive(false);
        _menuWindows.SetActive(true);

        for (int i = 0; i < _componentsToDisable.Length; i++)
        {
            _componentsToDisable[i].enabled = false; 
        }

        Time.timeScale = 0.02f;
    }

    public void CloseMenuWindow()
    {
        _menuButton.SetActive(true);
        _menuWindows.SetActive(false);

        for(int i = 0; i < _componentsToDisable.Length; i++)
        {
            _componentsToDisable[i].enabled = true;
        }

        Time.timeScale = 1f; 
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
