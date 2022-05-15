using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private Menu _menu; 
    private void OnCollisionEnter(Collision collision)
    {
        PlayerHealth player = collision.gameObject.GetComponentInParent<PlayerHealth>();
        if (player)
        {
            FinishGame();
        }
    }

    private void FinishGame()
    {
        _menu.OpenMenuFisnih();
    }
}
