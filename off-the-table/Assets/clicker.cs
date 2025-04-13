using UnityEngine;

public class clicker : MonoBehaviour
{
    [SerializeField] private AudioClip down;
    [SerializeField] private AudioClip up;
    private void OnMouseDown() {
        GetComponent<AudioSource>().PlayOneShot(down);
    }
    private void OnMouseUp() {
        GetComponent<AudioSource>().PlayOneShot(up);
    }
}
