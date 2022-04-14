using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _timeScale = 0.2f;

    private float _startFixedDeltaTime;

    private void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime; 
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
            Time.timeScale = _timeScale;
        else
            Time.timeScale = 1; 

        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }
}
