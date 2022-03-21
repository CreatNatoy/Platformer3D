using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _spawnTransofrm;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _shotPeriod = 0.2f;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private GameObject _flash; 

    private float _timer; 

    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _shotPeriod)
        {
            if(Input.GetMouseButton(0))
            {
                Shot();
                _timer = 0f; 
            }
        }
    }

    private void Shot()
    {
        Bullet newBullet = Instantiate(_bulletPrefab, _spawnTransofrm.position, _spawnTransofrm.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = _spawnTransofrm.forward * _bulletSpeed;
        _shotSound.Play();
        _flash.SetActive(true);
        Invoke("HideFlash", 0.12f); 
    }

    private void HideFlash()
    {
        _flash.SetActive(false); 
    }
}