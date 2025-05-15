using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public BoxDeliveryManager deliveryManager;

    private bool hasDelivered = false; // mencegah dobel hitung

    private void OnTriggerEnter(Collider other)
    {
        if (!hasDelivered && other.CompareTag("Pallet"))
        {
            hasDelivered = true; // hanya bisa hitung 1x
            deliveryManager.BoxDelivered();
           // Destroy(other.gameObject); // hapus pallet setelah dikirim (jika mau)
        }
    }
}
