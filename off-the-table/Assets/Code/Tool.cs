using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Tool : Item{
    protected bool doesSmth = false;
    protected virtual void Update(){
       base.Update();
       if(dragging&&!doesSmth){
           doesSmth=true;
           HoldAction();
       }
       else if(!dragging&&doesSmth){
           doesSmth=false;
           ReleaseAction();
       }
    }
    protected virtual void HoldAction(){
        return;
    }
    protected virtual void ReleaseAction(){
        return;
    }
}