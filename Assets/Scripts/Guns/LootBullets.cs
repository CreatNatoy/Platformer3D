using UnityEngine;

public class LootBullets : MonoBehaviour
{
    [SerializeField] private int _gunIndex;
    [SerializeField] private int _numberOfBullets; 

    private void OnTriggerEnter(Collider other)
    {
        PlayerArmory playerArmory = other.gameObject.GetComponentInParent<PlayerArmory>();
        if (playerArmory)
        {
            playerArmory.AddBullets(_gunIndex,_numberOfBullets);
            Destroy(gameObject);
        }
    }
}
