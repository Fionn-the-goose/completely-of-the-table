using UnityEngine;

public class packspawner : MonoBehaviour
{
    public GameObject prefab;
    void OnMouseUp()
    {
        SpawnObj();
    }
    private void SpawnObj(){
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
