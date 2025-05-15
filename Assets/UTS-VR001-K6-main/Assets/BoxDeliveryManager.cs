using UnityEngine;
using TMPro;

public class BoxDeliveryManager : MonoBehaviour
{
    public int totalBoxes = 3;
    private int deliveredCount = 0;

    public TMP_Text boxDelivered;

    void Start()
    {
        UpdateUI();
    }

    public void BoxDelivered()
    {
        if (deliveredCount < totalBoxes)
        {
            deliveredCount++;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        boxDelivered.text = "Box Delivered: " + deliveredCount + "/" + totalBoxes;
    }
}
