using UnityEngine;

public class packspawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform depositSpot; 
    void OnMouseUp()
    {
        SpawnObj();
    }
    private void SpawnObj(){
        Instantiate(prefab, depositSpot.position, Quaternion.identity);
    }
}
