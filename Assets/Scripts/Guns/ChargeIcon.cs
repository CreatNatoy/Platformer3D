using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
    [SerializeField] private Image _background; 
    [SerializeField] private Image _foreground;
    [SerializeField] private Text _textTimer; 

    public void ChangeState(bool state, float alpha)
    {
        _background.color = new Color(1,1,1, alpha);
        _foreground.enabled = state;
        _textTimer.enabled = state;
    }

    public void SetChargeValue(float _currentCharge, float _maxCharge)
    {
        _foreground.fillAmount = _currentCharge / _maxCharge;
        _textTimer.text = Mathf.Ceil(_maxCharge - _currentCharge).ToString(); 
    }
}
