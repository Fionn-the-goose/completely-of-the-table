using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Item : MonoBehaviour  {
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip pickup_sound;
    [SerializeField] private AudioClip dropdown_sound;
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
    }

    void OnMouseUp(){
        //transform.position = original_pos;
        dragging = false;
        _audioSource.PlayOneShot(dropdown_sound);
    }
    Vector2 GetMousePos() {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
