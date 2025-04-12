using UnityEngine;

public class ThaPit : MonoBehaviour
{
    [SerializeField] private Wallet wallet;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Produce>() != null){
            Debug.Log(collision.gameObject.name+ " was Consumed");
            GainWealth(collision.gameObject.GetComponent<Produce>().value);
            Destroy(collision.gameObject);
        }
    }

    private void GainWealth(int cash){
        Debug.Log($"Sold For: " + cash);
        wallet.money += cash;
    } 
}
