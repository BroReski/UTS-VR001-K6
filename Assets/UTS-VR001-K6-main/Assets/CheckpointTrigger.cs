using UnityEngine;
using System.Collections.Generic;

public class CheckpointTrigger : MonoBehaviour
{
    public UIController uiController; // Assign dari Inspector
    private int deliveredCount = 0;
    public int totalBoxes = 3;

    private HashSet<GameObject> deliveredPallets = new HashSet<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Masuk checkpoint dengan: " + other.name);

        if (other.CompareTag("Pallet"))
        {
            // Cek apakah pallet ini sudah pernah dihitung
            if (!deliveredPallets.Contains(other.gameObject))
            {
                deliveredCount++;
                deliveredPallets.Add(other.gameObject); // Tambahkan ke set agar tidak dihitung dua kali
                Debug.Log("Pallet diterima. Total: " + deliveredCount);
                uiController.UpdateDelivered(deliveredCount, totalBoxes);
            }
            else
            {
                Debug.Log("Pallet ini sudah dihitung sebelumnya.");
            }
        }
    }
}
