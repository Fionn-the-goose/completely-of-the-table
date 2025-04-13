using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlantPot : MonoBehaviour
{
    private PlantSO plantInfo;
    private bool isBlocked;
    private bool canYealdProduce;
    private bool readyToGrow;
    private bool readyToMature;
    [SerializeField] private AudioSource growAudio;
    [SerializeField] private AudioSource matureAudio;
    [SerializeField] private SpriteRenderer plantVisuals;    
    [SerializeField] private GameObject prodPrefab;
    [SerializeField] private bool accillerateGroth = true;
    [SerializeField] private Transform produceOutput;
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
        if(accillerateGroth){
            yield return new WaitForSeconds(plantInfo.timeToGrow/10);
        }
        else{
            yield return new WaitForSeconds(plantInfo.timeToGrow);
        }
        growAudio.Play();
        plantVisuals.sprite = plantInfo.spriteGrowing;
        if(accillerateGroth){
            yield return new WaitForSeconds(plantInfo.timeToMature/10);
        }
        else{
            yield return new WaitForSeconds(plantInfo.timeToMature);
        }
        growAudio.Play(); 
        plantVisuals.sprite = plantInfo.spriteReady;
        canYealdProduce = true;
        matureAudio.clip = plantInfo.Sound;
        SoundRoutine();
    }

    public IEnumerator SoundRoutine(){
        while(canYealdProduce){
            matureAudio.Play();
            yield return new WaitForSeconds(UnityEngine.Random.Range(2f, 8f));
        }
    }
    public void HarvestPlant(){
        Debug.Log($"try initiate harvest");
        if(canYealdProduce){
            matureAudio.Stop();
            Debug.Log($"initiate harvest");
            for(int i = 1; i <= plantInfo.numberOfProduce; i++){   
                GameObject prod = Instantiate(prodPrefab ,produceOutput.position, Quaternion.identity);
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
