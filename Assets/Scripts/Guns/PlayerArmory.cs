using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] private Gun[] _guns;
    [SerializeField] private int _currentGunIndex = 0; 

    private void Start()
    {
        TakeGunByIndex(_currentGunIndex);
    }

    public void TakeGunByIndex(int gunIndex)
    {
        _currentGunIndex = gunIndex;
        for (int i = 0; i < _guns.Length; i++)
        {
            if (i == gunIndex)
                _guns[i].ChangeState(true); 
            else
                _guns[i].ChangeState(false);
        }
    }

    public void AddBullets(int gunIndex, int numberOfBullets)
    {
        _guns[gunIndex].AddBullets(numberOfBullets);
    }
}
