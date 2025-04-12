using UnityEngine;
using UnityEngine.UI;

public class SwitchViews : MonoBehaviour
{
    [SerializeField] private GameObject disable_scene;
    [SerializeField] private GameObject enable_scene;


    public void disableScene(){
        enable_scene.SetActive(true);
        if (enable_scene.activeSelf == true){
            disable_scene.SetActive(false);
        }
    }

}
