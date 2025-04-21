using System.Collections.Generic;
using UnityEngine;

public class TeleportItem : MonoBehaviour
{
    [SerializeField] List<string> can_teleport = new();
    [SerializeField] private Transform destination;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource source;
    //public bool is_destination = false;
    //public Transform ing_spawn;
    //private bool box_opened = false;
    

    void OnCollisionEnter2D(Collision2D collision){
        foreach (string item in can_teleport){
            if(collision.gameObject.GetComponent<Item>()._name == item){
                if(collision.gameObject.GetComponent<Package>() != null){
                    collision.gameObject.GetComponent<Package>().SetCanOpen(true);
                }
                collision.gameObject.GetComponent<Item>().SetTeleportStatus(true);
                Teleport_Item(collision.gameObject);
                source.PlayOneShot(clip);
            }
        }
    }
    /* void OnTriggerEnter2D(Collider2D collision)
    {
        if(is_destination == true){
            if(collision.gameObject.GetComponent<Package>()){

                List<GameObject> ing = new();
                ing = collision.gameObject.GetComponent<Package>().GetList();
                collision.gameObject.GetComponent<Package>().SetCanOpen(true);
                foreach(GameObject item in ing){
                    Debug.Log(item);
                    if(box_opened == true){
                        Debug.Log("hey");
                        item.SetActive(true);  

                        item.transform.position = ing_spawn.position;
                    }
                    
                }
            }
        }
    } */
/*     public void CanUnlockItems(bool open){
        box_opened = open;
    } */
    public void Teleport_Item(GameObject item){
        if(destination != null){
            item.transform.position = destination.position;
        }
    }
}
