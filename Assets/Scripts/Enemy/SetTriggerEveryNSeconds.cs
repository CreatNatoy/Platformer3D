using UnityEngine;

public class SetTriggerEveryNSeconds : MonoBehaviour
{
    [SerializeField] private float _attackPeriod = 7f;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _triggerName = "Attack"; 

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _attackPeriod)
        {
            _timer = 0;
            _animator.SetTrigger(_triggerName);
        }
    }
}
