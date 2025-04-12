using UnityEngine;

public class PlantPot : MonoBehaviour
{
    private PlantSO plantInfo;
    private bool isBlocked;
    [SerializeField] private SpriteRenderer Showcase;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"There is something: " + collision.gameObject.name);
        if(collision.gameObject.GetComponent<Sapling>()!=null){
            plantInfo = collision.gameObject.GetComponent<Sapling>().destroy_sap();
        }
    }
}
