using UnityEngine;

public class JumpGun : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRigidBody;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private Gun _pistol;
    [SerializeField] private float _maxCharge = 3;
    [SerializeField] private ChargeIcon _chargeIcon;

    private float _currentCharge;
    private bool _isCharged; 

    private void Update()
    {
        if (_isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                JumpGunPlayer();
                _chargeIcon.ChangeState(true, 0.2f);
            }
        }
        else
        {
            LoadCharge();
        }
    }

    private void JumpGunPlayer()
    {
        _playerRigidBody.AddForce(-transform.forward * _speed, ForceMode.VelocityChange);
        _pistol.Shot();

        _currentCharge = 0; 
        _isCharged = false;
    }

    private void LoadCharge()
    {
        _currentCharge += Time.unscaledDeltaTime;
        _chargeIcon.SetChargeValue(_currentCharge, _maxCharge);
        if (_currentCharge >= _maxCharge)
        {
            _isCharged = true;
            _chargeIcon.ChangeState(false, 1f);
        }
    }

}
