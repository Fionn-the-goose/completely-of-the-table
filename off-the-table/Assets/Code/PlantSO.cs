using UnityEngine;

[CreateAssetMenu(fileName = "Plant", menuName = "Scriptable Objects/Plant")]
public class PlantSO : ScriptableObject
{
    [Header("visual stuff")]
    public Sprite spriteSappling;
    public Sprite spriteGrowing;
    public Sprite spriteReady;
    [Header("growing infos")]
    public float timeToGrow;
    public float timeToMature;
    public AudioClip Sound;
    [Header("produce infos")]
    public int value;
    public int numberOfProduce;
    public Sprite produceSprite;
    [Header("Combination infos")]
    public Ingediens firstIng;
    public Ingediens secondIng;
}
