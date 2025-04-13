using System.Threading;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Ingredient : Item {
    [SerializeField] private int price;
    [SerializeField] private Wallet wallet;
    [SerializeField] private Transform depositSpot;
    public string name_;
    public bool isShopVarient=false;


    private void Start()
    {
        rigidbody_ = GetComponent<Rigidbody2D>();
        if(isShopVarient){
            rigidbody_.bodyType = RigidbodyType2D.Kinematic;
        }
        else{
            rigidbody_.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public override void OnMouseDown()
    {
        if(isShopVarient){
        }
        else{
            base.OnMouseDown();
        }
    }
    public override void OnMouseUp()
    {
        if(isShopVarient){
            if(price <= wallet.money){
                wallet.money = wallet.money - price;
                GameObject ingCopy = Instantiate(this.gameObject, depositSpot.position, Quaternion.identity);
                Ingredient freshComponenet = ingCopy.GetComponent<Ingredient>();
                freshComponenet.isShopVarient = false;
                ingCopy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            else{
                Debug.Log($"To expensive for you Idiot");
            }
        }
        else    {
            base.OnMouseUp();
        }
    }
}
