using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] private float _distanceToActibate = 20f;

    private bool _isActive = true; 

    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

        if(_isActive)
        {
            if(distance > _distanceToActibate + 2f)
                ChangeState(false);
        }
        else
        {
            if(distance < _distanceToActibate )
                ChangeState(true);
        }
    }

    private void ChangeState(bool state)
    {
        _isActive = state;
        gameObject.SetActive(state);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, _distanceToActibate);
    }
#endif

}
