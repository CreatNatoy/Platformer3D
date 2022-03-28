using UnityEngine;

public class CarrotCreater : MonoBehaviour
{
    [SerializeField] private Carrot _carrotPrefabs;
    [SerializeField] private Transform _spawnPoint; 

    public void Create()
    {
        Instantiate(_carrotPrefabs, _spawnPoint.position, Quaternion.identity); 
    }
}
