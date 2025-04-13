using UnityEngine;

public class Sapling : Item
{
    [SerializeField] private PlantSO plant;
    public PlantSO destroy_sap(){
        Debug.Log($"Sapling Destroyed");
        Destroy(this.gameObject);
        return plant;
    }

    public void setPlantType(PlantSO type){
        plant = type;
    }
}
