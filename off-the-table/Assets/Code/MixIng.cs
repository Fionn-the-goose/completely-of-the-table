using System.Collections.Generic;
using UnityEngine;

public class MixIng : MonoBehaviour {

    private int collision_count;
    private string ing_A;
    private string ing_B;
    public List<PlantSO> plantList;

    void Update() {
        if(collision_count == 2){
            Sapling sap = mix_ing(ing_A, ing_B);
            createItem((Vector2)transform.position, sap);
            collision_count = 0;
        }
    }
    public void createItem(Vector2 pos, Sapling item){
        Instantiate(item, pos, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)  {
        
        if(collision_count == 0){
            Debug.Log(collision_count);
            GameObject tmp = collision.gameObject;
            ing_A = tmp.GetComponent<Ingediens>().name;
            collision_count += 1;
            Destroy(collision.gameObject);
        }
        if(collision_count == 1){
            GameObject tmp = collision.gameObject;
            ing_B = tmp.GetComponent<Ingediens>().name;
            collision_count += 1;
            Destroy(collision.gameObject);
        }
        
    }

    private Sapling mix_ing(string A, string B){
        PlantSO pee;
        Sapling seed = new Sapling();
        foreach(var plant in plantList){
            if((plant.firstIng.name == A || plant.firstIng.name == B) && (plant.secondIng.name == A || plant.secondIng.name == B) ){
                pee = plant;
                seed.setPlantType(pee);
            }
        }
        
        return seed;
    }

}
