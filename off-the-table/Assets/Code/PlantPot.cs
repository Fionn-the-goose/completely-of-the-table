using UnityEngine;

public class PlantPot : MonoBehaviour
{
    private Plant plantInfo;
    [SerializeField] private SpriteRenderer Showcase;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Item>()){

        }
    }
}
