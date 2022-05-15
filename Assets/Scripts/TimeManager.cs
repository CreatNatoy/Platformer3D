using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _timeScale = 0.2f;

    private float _startFixedDeltaTime;
    private bool _isPause;

    private void Start()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
            Time.timeScale = _timeScale;
        else if (_isPause)
            Time.timeScale = 0.02f;
        else
            Time.timeScale = 1;

        Time.fixedDeltaTime = _startFixedDeltaTime * Time.timeScale;
    }

    private void OnDestroy()
    {
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }

    public void IsPause(bool state) => _isPause = state; 
}