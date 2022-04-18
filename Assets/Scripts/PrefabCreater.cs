using UnityEngine;

public class PrefabCreater : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawnPoint; 

    public void Create()
    {
        Instantiate(_prefab, _spawnPoint.position, _spawnPoint.rotation); 
    }
}
