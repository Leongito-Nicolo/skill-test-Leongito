using UnityEngine;

[CreateAssetMenu(fileName = "NewCollectibleData", menuName = "Game/Collectible Data")]
public class CollectibleData : ScriptableObject
{
    [Header("Properties")]
    new public string name;
    public int points;

    //[Header("Special Effect")]
    //public EffectType specialEffect;
}
