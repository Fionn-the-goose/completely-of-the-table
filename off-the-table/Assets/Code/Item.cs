using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    private SpriteRenderer sprite;

    public void OnBeginDrag(PointerEventData eventData)
    {
        sprite.color = new Color32(255, 255, 255, 170);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        sprite.color = new Color32(255, 255, 255, 255);
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

}
