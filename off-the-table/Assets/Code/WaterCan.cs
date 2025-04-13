using System.Threading;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class WaterCan : Item{
    [SerializeField] private ParticleSystem particleSystem;
    private bool isPooring = false;
    void Update()
    {
        if(dragging && !isPooring){
            isPooring = true;
            TogglePooring(true);
        }
        else{
            isPooring = false;
            TogglePooring(false);
        }   
    }
    private void SyncRotation(){
        this.transform.eulerAngles = new Vector3(0, 0, 0);
    }
    private void TogglePooring(bool value){
        if(value){
            SyncRotation();
            this.transform.Rotate(Vector3.forward,60);
        }
        else{
            SyncRotation();
        }
    }
}