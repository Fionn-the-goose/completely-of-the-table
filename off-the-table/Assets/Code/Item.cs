using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Item : MonoBehaviour  {
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] public AudioClip pickup_sound;
    [SerializeField] public AudioClip dropdown_sound;
    public string _name;
    protected bool dragging;
    private Vector2 offset, original_pos;
    private SpriteRenderer visuals;
    private bool justBeenTeleport = false; 
    protected Rigidbody2D rigidbody_;
    //[SerializeField] private Transform teleport;
    //[SerializeField] private Transform destination;
    void Awake() {
        original_pos = transform.position;
        visuals = GetComponent<SpriteRenderer>();
    }
    protected virtual void Update() {
        if(!dragging) return;

        var mousepos = GetMousePos();
        if(!justBeenTeleport){
            transform.position = mousepos - offset*new Vector2(0.1f,0.1f);
        }
    }
    public virtual void OnMouseDown(){
        dragging = true;
        offset = GetMousePos() - (Vector2)transform.position;
        _audioSource.PlayOneShot(pickup_sound);
        GetComponent<Rigidbody2D>().gravityScale=0;
    }

    public virtual void OnMouseUp(){
        //transform.position = original_pos;
        justBeenTeleport = false;
        dragging = false;
        _audioSource.PlayOneShot(dropdown_sound);
        GetComponent<Rigidbody2D>().gravityScale=1;
    }
    Vector2 GetMousePos() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public void SetTeleportStatus(bool on){
        justBeenTeleport = on;
    }
    public void SwapVisuals(Sprite sprite){
        if(sprite != null)
        visuals.sprite = sprite;
    }
}
