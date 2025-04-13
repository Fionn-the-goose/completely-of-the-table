using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPot : MonoBehaviour
{
    private PlantSO plantInfo;
    private bool isBlocked;
    private bool canYealdProduce;
    [SerializeField] private SpriteRenderer plantVisuals;
    [SerializeField] private GameObject prodPrefab;
    void Start()
    {
        plantVisuals.sprite = null;
    }

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
        canYealdProduce = true;
    }
    public void HarvestPlant(){
        Debug.Log($"try initiate harvest");
        if(canYealdProduce){
            Debug.Log($"initiate harvest");
            for(int i = 1; i <= plantInfo.numberOfProduce; i++){   
                GameObject prod = Instantiate(prodPrefab ,transform.position,Quaternion.identity);
                Produce bauntifull_harvest = prod.GetComponent<Produce>();
                bauntifull_harvest.value = plantInfo.value;
                bauntifull_harvest.SwapVisuals(plantInfo.produceSprite);
                Debug.Log($"havest successfull");
            }
            isBlocked = false;
            canYealdProduce = false;
            plantVisuals.sprite = null;
        }
    }
}
