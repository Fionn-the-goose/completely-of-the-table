using System.Collections.Generic;
using UnityEngine;

public class TeleportItem : MonoBehaviour
{
    [SerializeField] List<string> can_teleport = new();
    [SerializeField] private Transform destination;
    public bool is_destination = false;

    void OnCollisionEnter2D(Collision2D collision){
        foreach (string item in can_teleport){
            if(collision.gameObject.GetComponent<Item>()._name == item){
                Teleport_Item(collision.gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(is_destination == true){

        }
    }
    public void Teleport_Item(GameObject item){
        if(destination != null){
            item.transform.position = destination.position;
        }
    }
}
