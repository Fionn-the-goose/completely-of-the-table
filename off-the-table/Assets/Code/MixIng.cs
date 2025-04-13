using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MixIng : MonoBehaviour {

    [SerializeField] private GameObject defaultSeedling;
    [SerializeField] private List<PlantSO> allPossibillitys;
    private string firstComponent = "";
    private string secondComponent = "";
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Ingredient>()){
            if(firstComponent != ""){
                firstComponent = other.gameObject.GetComponent<Ingredient>().name_;
            }
            else if(secondComponent != ""){
                secondComponent = other.gameObject.GetComponent<Ingredient>().name_;
                
            }
        }
    }
    private void DetermineType(){
        foreach(PlantSO plant in allPossibillitys){
            if(firstComponent==plant.firstIng&&secondComponent==plant.secondIng){

            }
        }
    }
/*
    private string ing_A;
    private string ing_B;
    public List<PlantSO> plantList;
    public Sapling sed;
    private bool item_created = false;
    private bool first_item = false;
    private bool second_item = false;
    PlantSO pee;
    void Update() {
        if(first_item == true && second_item == true){
            Debug.Log("Both true");
            if(item_created == false){
                if(ing_A != null && ing_B != null){
                    mix_ing(ing_A, ing_B);
                }
                
                Sapling seed = Instantiate(sed, (Vector2)transform.position, Quaternion.identity);
                seed.setPlantType(pee);
                item_created = true;
            }
            
            first_item = false;
            second_item = false;
        }
        if(first_item == false && second_item == false){
            item_created = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         if(first_item == false && second_item == false){
            GameObject tmp = collision.gameObject;
            ing_A = tmp.GetComponent<Ingediens>()._name;
            }
        if(first_item == true && second_item == false){
            GameObject tmp = collision.gameObject;
            ing_B = tmp.GetComponent<Ingediens>()._name;
        }
        Destroy(collision.gameObject);
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(first_item == false && second_item == false){
            first_item = true;
        }
        if(first_item == true && second_item == false){
            second_item = true;
        }
    }



    private void mix_ing(string A, string B){
        Debug.Log("Ingredient A: " + A);
        Debug.Log("Ingredient B: " + B);
        foreach(var plant in plantList){
            Debug.Log(plant.firstIng._name + " " + plant.secondIng._name);
            if((plant.firstIng._name == A || plant.firstIng._name == B) && (plant.secondIng._name == A || plant.secondIng._name == B) ){
                pee = plant;
                Debug.Log(pee.name);
                
            }
            else Debug.Log("no plant found");
        }
    }
*/
}
