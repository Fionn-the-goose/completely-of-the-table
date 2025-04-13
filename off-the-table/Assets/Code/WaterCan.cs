using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class WaterCan : Tool{
    [SerializeField] private ParticleSystem particleSystem;

    protected override void Update()
    {
        base.Update();
        if (doesSmth){
            //transform.rotation = quaternion.identity;
        }
    }
    private void SyncRotation(){
        this.transform.eulerAngles = new Vector3(0, 0, 0);
    }
    protected override void HoldAction(){
        Debug.Log($"i poor water");
        SyncRotation();
        this.transform.Rotate(Vector3.forward,-60);
    }
    protected override void ReleaseAction(){
        SyncRotation();
        //this.transform.Rotate(Vector3.forward,-60);
    }
}