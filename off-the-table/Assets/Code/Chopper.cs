using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Chopper : Tool{
    private bool isLeathal = false;
    protected override void HoldAction(){
        StartCoroutine(ChopRoutine());
    }

    protected override void ReleaseAction(){
        StopAllCoroutines();
    }

    private IEnumerator ChopRoutine(){
        while(dragging){
            transform.Rotate(Vector3.forward, 40);
            isLeathal = true;
            yield return new WaitForSeconds(.3f);
            transform.Rotate(Vector3.forward, -40);
            isLeathal = false;
        }
        yield return new WaitForEndOfFrame();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<PlantVisualizer>()!=null && isLeathal && doesSmth){
            other.gameObject.GetComponent<PlantVisualizer>().InitiateHarvest();
        }
    }
}