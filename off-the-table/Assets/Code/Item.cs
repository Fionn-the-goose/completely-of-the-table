using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Item : MonoBehaviour  {
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip pickup_sound;
    [SerializeField] private AudioClip dropdown_sound;


    public string _name;
    private bool dragging;
    private Vector2 offset, original_pos;


    void Awake() {
        original_pos = transform.position;
    }
    void Update() {
        if(!dragging) return;

        var mousepos = GetMousePos();
        transform.position = mousepos - offset;
    }
    void OnMouseDown(){
        dragging = true;
        offset = GetMousePos() - (Vector2)transform.position;
        _audioSource.PlayOneShot(pickup_sound);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }

    void OnMouseUp(){
        //transform.position = original_pos;
        dragging = false;
        _audioSource.PlayOneShot(dropdown_sound);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    Vector2 GetMousePos() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    
}
