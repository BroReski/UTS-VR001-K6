using UnityEngine;

public class LifterControl : MonoBehaviour
{
    // Kecepatan naik/turun lifter
    public float liftSpeed = 2f;
    
    // Tombol untuk menggerakkan lifter naik dan turun (bisa diubah di Inspector)
    public string liftUpButton = "q";
    public string liftDownButton = "e";

    // Batas posisi Y minimum dan maksimum lifter (relatif terhadap posisi awal)
    public float minYPosition = 0f;
    public float maxYPosition = 2f;

    // Menyimpan posisi awal lifter
    private Vector3 initialPosition;

    // Transform objek lifter untuk memudahkan manipulasi posisi
    private Transform lifterTransform;

    void Start()
    {
        // Mendapatkan transform dari objek yang memiliki script ini
        lifterTransform = transform;

        // Menyimpan posisi awal objek lifter dalam koordinat lokal
        initialPosition = lifterTransform.localPosition; // localPosition digunakan agar relatif terhadap parent
    }

    void Update()
    {
        // Variabel untuk input vertikal (naik/turun)
        float verticalInput = 0f;

        // Mengecek input untuk pergerakan naik
        if (Input.GetKey(liftUpButton))
        {
            verticalInput = 1f;
        }
        // Mengecek input untuk pergerakan turun
        else if (Input.GetKey(liftDownButton))
        {
            verticalInput = -1f;
        }

        // Menghitung perubahan posisi berdasarkan input dan kecepatan lifter
        float liftChange = verticalInput * liftSpeed * Time.deltaTime;

        // Mengambil posisi lokal saat ini dan menambahkannya dengan perubahan posisi
        Vector3 newLocalPosition = lifterTransform.localPosition;
        newLocalPosition.y += liftChange;

        // Membatasi posisi lifter agar tidak melebihi batas minimum dan maksimum
        newLocalPosition.y = Mathf.Clamp(newLocalPosition.y, initialPosition.y + minYPosition, initialPosition.y + maxYPosition);

        // Menerapkan posisi baru ke transform lifter
        lifterTransform.localPosition = newLocalPosition;
    }
}