using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Package : Item {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //[SerializeField] private AudioClip packing;
    [SerializeField] private List<GameObject> content;
    //private bool box_sent = false;
    //SerializeField] Transform box_pos;
    //public int box_speed;
    private int clicCounter = 0;
    private float timeToClick = 3;
    private bool coroutineIsActive = false;
    //private float delay = 0.3f;
    [SerializeField] private bool can_open = false;
    

    //private TeleportItem tele;

    public  void SetCanOpen(bool value) {
        can_open = value;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.GetComponent<Ingredient>()){
            if(collision.gameObject.GetComponent<Ingredient>().isShopVarient == false){
                //Debug.Log(collision.gameObject.GetComponent<Ingredient>().name_);
                if(can_open == false){
                    content.Add(collision.gameObject);
                    Debug.Log($"Cool Item: "+ content);
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }

    void Update()
    {
        base.Update();
        if(clicCounter >= 5){
            clicCounter = 0;
            if(can_open == true){
                UnpackBox();
            }
        }
/*         if(box_sent == true){
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
            clicked = 0; */
        
    }
    
    /* 
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<TeleportItem>() != null){
            if(collision.gameObject.GetComponent<TeleportItem>().is_destination == true){
                tele = collision.gameObject.GetComponent<TeleportItem>();
                box_sent = false;
            }
        }
    }
 */
    public void UnpackBox(){
        Debug.Log($"good job");
        foreach(GameObject obj in content){
            obj.SetActive(true);
            obj.transform.position = this.transform.position;
        }
        Destroy(this.gameObject);
    }
    
    public List<GameObject> GetList(){
        return content;
    }

    //public void SetCanOpen(bool canopen){
    //    can_open = canopen;
    //}

 /*    public void sendBox(){
        box_sent = true;
    } */

    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        Debug.Log($"clic: !!!" + clicCounter);
        clicCounter++;
        if(!coroutineIsActive){
            coroutineIsActive = true;
            StartCoroutine(Open_Box());
        }
        
    }
    
    public IEnumerator Open_Box() {
        yield return new WaitForSeconds(timeToClick);
        //gameObject.SetActive(false);
        clicCounter = 0;
    }

}
