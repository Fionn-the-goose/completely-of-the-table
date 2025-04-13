using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Package : Item {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private AudioClip packing;
    private List<GameObject> ings = new();
    private bool box_sent = false;
    [SerializeField] Transform box_pos;
    public int box_speed;
    private int clicked = 0;
    private float time = 0;
    private float delay = 0.3f;
    [SerializeField] private bool can_open = false;

    private TeleportItem tele;

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.GetComponent<Ingredient>()){
            if(collision.gameObject.GetComponent<Ingredient>().isShopVarient == false){
                Debug.Log(collision.gameObject.GetComponent<Ingredient>().name_);
                ings.Add(collision.gameObject);
                if(can_open == false){
                    collision.gameObject.SetActive(false);
                }
                
            }
            
        }

    }

    void Update()
    {
        base.Update();
        if(box_sent == true){
            transform.position = Vector3.MoveTowards(transform.position, box_pos.position, box_speed*Time.deltaTime);
        }
        
        if(Input.GetMouseButtonUp(0)){
            Debug.Log("clicked");
            clicked+=1;
        }
         if (clicked == 1){
            Debug.Log("1");
            time = Time.time;
        } 
        if (clicked == 2 && Time.time - time < (delay - 0.5f)){
            Debug.Log("2");
        }
        if (clicked > 2 && Time.time - time < delay && can_open == true){
            clicked = 0;
            time = 0;
            tele.CanUnlockItems(true);
            StartCoroutine(Open_Box(0.3f));
        }
        else if (clicked > 3 || Math.Abs(Time.time - time) > delay ){
            clicked = 0;
        } 
        

        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<TeleportItem>() != null){
            if(collision.gameObject.GetComponent<TeleportItem>().is_destination == true){
                tele = collision.gameObject.GetComponent<TeleportItem>();
                box_sent = false;
            }
        }
    }

    public List<GameObject> GetList(){
        return ings;
    }
    public void SetCanOpen(bool canopen){
        can_open = canopen;
    }

    public void sendBox(){
        box_sent = true;
    }
    IEnumerator Open_Box(float waitTime) {
        
        yield return new WaitForSeconds(waitTime);
        Debug.Log("destroy");
        gameObject.SetActive(false);
        
    }

}
