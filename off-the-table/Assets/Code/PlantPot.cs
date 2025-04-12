using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPot : MonoBehaviour
{
    private PlantSO plantInfo;
    private bool isBlocked;
    private bool canYealdProduce;

    public SpriteRenderer plantVisuals;     
    [SerializeField] private SpriteRenderer Showcase;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"There is something: " + collision.gameObject.name);
        if(collision.gameObject.GetComponent<Sapling>()!=null && !isBlocked){
            plantInfo = collision.gameObject.GetComponent<Sapling>().destroy_sap();
            isBlocked = true;
            StartCoroutine(GrowCoroutine());
        }
    }
    public IEnumerator GrowCoroutine(){
        
        plantVisuals.sprite = plantInfo.spriteSappling;
        yield return new WaitForSeconds(plantInfo.timeToGrow);
        plantVisuals.sprite = plantInfo.spriteGrowing;
        yield return new WaitForSeconds(plantInfo.timeToMature);
        plantVisuals.sprite = plantInfo.spriteReady;
    }

}
