using UnityEngine;

[RequireComponent(typeof(PlayerJump))]
public class PlayrSitDown : MonoBehaviour
{
    [SerializeField] private Transform _colliderTransform;
    [SerializeField] private float _speedSitDown;

    private PlayerJump _playerJump;

    private void Start()
    {
        _playerJump = GetComponent<PlayerJump>(); 
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || !_playerJump.IsGround)
        {
            SitDown(0.5f); 
        }
        else
        {
            SitDown(1f);
        }
    }

    private void SitDown(float state)
    {
        _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1f, state, 1f), Time.deltaTime * _speedSitDown); 
    }
}
