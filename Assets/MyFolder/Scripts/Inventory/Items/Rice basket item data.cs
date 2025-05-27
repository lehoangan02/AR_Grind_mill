using UnityEngine;

[CreateAssetMenu(fileName = "Rice basket item data", menuName = "Scriptable Objects/Ricebasketitemdata")]
public class RiceBasketItemData : ItemData
{
    private bool isFull = false;
    public Sprite filledSprite;
    public bool IsFull()
    {
        return isFull;
    }
    public void SetFull(bool value)
    {
        isFull = value;
    }
    public Sprite GetSprite(bool filled)
    {
        if (filled)
        {
            return filledSprite;
        }
        else
        {
            return image;
        }
    }
}
