using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] private GameObject selectedSlotImage;
    [SerializeField] private Image itemImage;
    [SerializeField] private Text itemCount;
    
    public void InitSlotUI(GrenadeType grenadeType, int grenadeCount)
    {
        switch (grenadeType)
        {
            case GrenadeType.RED:
                itemImage.color = Color.red;
                break;
            case GrenadeType.GREEN:
                itemImage.color = Color.green;
                break;
            case GrenadeType.BLUE:
                itemImage.color = Color.blue;
                break;
            default:
                break;
        }

        itemCount.text = grenadeCount.ToString();
    }

    public void SetItemCount(int itemCount)
    {
        this.itemCount.text = itemCount.ToString();
    }

    public void SetSlotSelectedUI(bool isSelected)
    {
        selectedSlotImage.SetActive(isSelected);
    }
}
