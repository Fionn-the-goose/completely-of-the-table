using System.Collections.Generic;
using UnityEngine;

public class Package : Item {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip packing;
    private List<GameObject> ings = new();
    private bool box_sent = false;
    [SerializeField] Transform box_pos;
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
        base.Update();
        if(box_sent == true && transform.position != box_pos.position){
            transform.position = Vector3.MoveTowards(transform.position, box_pos.position, box_speed*Time.deltaTime);
        }
        if(box_sent == true && transform.position == box_pos.position){
            box_sent = false;
        }
    }

    public void sendBox(){
        box_sent = true;
    }

}
