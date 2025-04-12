using UnityEngine;

public class Sapling : Item
{
    [SerializeField] private Plant plant;
    [SerializeField] private SpriteRenderer sap_sprite;

    public Plant destroy_sap(){
        Destroy(this);
        return plant;
    }

}
