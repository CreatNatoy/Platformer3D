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
            _guns[i].ChangeState(i == gunIndex);
        }
    }

    public void AddBullets(int gunIndex, int numberOfBullets)
    {
        _guns[gunIndex].AddBullets(numberOfBullets);
    }
}
