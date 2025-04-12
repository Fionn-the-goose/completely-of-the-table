using UnityEngine;

[CreateAssetMenu(fileName = "Plant", menuName = "Scriptable Objects/Plant")]
public class PlantSO : ScriptableObject
{
    public Sprite spriteSappling;
    public Sprite spriteGrowing;
    public Sprite spriteReady;
    public AudioClip Sound;
}
