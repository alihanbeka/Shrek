using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek hedef (karakter)
    public Vector3 offset = new Vector3(0, 0, -10); // Kameran�n karaktere g�re konumu

    private void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
