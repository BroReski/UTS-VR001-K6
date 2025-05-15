using UnityEngine;
using UnityEngine.UI;
using TMPro;

 // gunakan ini jika pakai Text biasa
// gunakan ini jika pakai TextMeshPro


public class BoxDeliveryManager : MonoBehaviour
{
    public int totalBoxes = 3;
    private int deliveredCount = 0;

    public TMP_Text boxDelivered; // Jika pakai Text UI biasa
    // public TMP_Text boxDeliveredText; // Jika pakai TextMeshPro

    void Start()
    {
        UpdateUI();
    }

    public void BoxDelivered()
    {
        deliveredCount++;

        if (deliveredCount > totalBoxes)
            deliveredCount = totalBoxes;

        UpdateUI();
    }

    void UpdateUI()
    {
        boxDelivered.text = "Box Delivered: " + deliveredCount + "/" + totalBoxes;
    }
}
