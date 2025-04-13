using UnityEngine;

public class PlantVisualizer : MonoBehaviour
{
    private PlantPot plantPot;
    void Start()
    {
        plantPot = GetComponentInParent<PlantPot>();
    }
    public void InitiateHarvest(){
        plantPot.HarvestPlant();
    }
}
