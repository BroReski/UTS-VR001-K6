using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI txtBoxesDelivered;
    public TextMeshProUGUI txtInstruction;

   public void UpdateDelivered(int current, int total)
{
    Debug.Log($"[UI] Update UI Boxes Delivered: {current}/{total}");
    txtBoxesDelivered.text = $"Boxes Delivered: {current}/{total}";
}


    public void SetInstruction(string text)
    {
        txtInstruction.text = text;
    }
}
