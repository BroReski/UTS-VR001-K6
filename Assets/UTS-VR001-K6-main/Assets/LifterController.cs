using UnityEngine;

public class LifterControl : MonoBehaviour
{
    public float liftSpeed = 2f; // Kecepatan naik/turun lifter
    public string liftUpButton = "q"; // Tombol untuk naik (bisa diubah di Inspector)
    public string liftDownButton = "e"; // Tombol untuk turun (bisa diubah di Inspector)
    public float minYPosition = 0f; // Batas posisi Y minimum lifter (relatif terhadap posisi awal)
    public float maxYPosition = 2f; // Batas posisi Y maksimum lifter (relatif terhadap posisi awal)

    private Vector3 initialPosition;
    private Transform lifterTransform;

    void Start()
    {
        // Asumsikan script ini terpasang pada objek yang merupakan "lifter" itu sendiri
        lifterTransform = transform;
        initialPosition = lifterTransform.localPosition; // Gunakan localPosition karena lifter mungkin bagian dari hierarki forklift
    }

    void Update()
    {
        float verticalInput = 0f;

        if (Input.GetKey(liftUpButton))
        {
            verticalInput = 1f;
        }
        else if (Input.GetKey(liftDownButton))
        {
            verticalInput = -1f;
        }

        // Hitung perubahan posisi berdasarkan input dan kecepatan
        float liftChange = verticalInput * liftSpeed * Time.deltaTime;

        // Aplikasikan perubahan posisi pada sumbu Y lokal
        Vector3 newLocalPosition = lifterTransform.localPosition;
        newLocalPosition.y += liftChange;

        // Batasi posisi lifter agar tidak melebihi batas minimum dan maksimum
        newLocalPosition.y = Mathf.Clamp(newLocalPosition.y, initialPosition.y + minYPosition, initialPosition.y + maxYPosition);

        // Terapkan posisi baru
        lifterTransform.localPosition = newLocalPosition;
    }
}