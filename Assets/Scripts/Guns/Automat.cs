using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    [Header("Automat")]
    [SerializeField] private int _numberOfBullets = 30;
    [SerializeField] private Text _bulletsText;
    [SerializeField] private PlayerArmory _playerArmory; 

    public override void Shot()
    {
        base.Shot();
        _numberOfBullets--;
        UpdateText();

        if (_numberOfBullets == 0)
            _playerArmory.TakeGunByIndex(0); 
    }

    public override void ChangeState(bool state)
    {
        base.ChangeState(state);
        UpdateText();
        _bulletsText.enabled = state;
    }

    private void UpdateText()
    {
        _bulletsText.text = "Bullet: " + _numberOfBullets.ToString();
    }
}
