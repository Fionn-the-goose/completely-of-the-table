using System.Collections.Generic;
using UnityEngine;

public class Package : Item {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip packing;
    private List<GameObject> ings = new();
    private bool box_sent = false;
    [SerializeField] Vector3 box_pos;
    public int box_speed;

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.GetComponent<Ingredient>()){
            Debug.Log(collision.gameObject.GetComponent<Ingredient>().name_);
            GameObject tmp = collision.gameObject;
            ings.Add(tmp);
            Destroy(collision.gameObject);
        }

    }

    void Update()
    {
        //if(box_sent == true && transform.position != box_pos){
        //    transform.
        //}
    }

    public void sendBox(){
        box_sent = true;
    }

}
