using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Camera targetCamera;

    public float offsetY = 10f;
    public float zoomMultiplier = 0.5f;

    void Update()
    {
        // 1. หาจุดกึ่งกลาง
        Vector3 center = (player1.position + player2.position) / 2f;

        // 2. ขยับกล้องไปตรงกลาง
        transform.position = new Vector3(center.x, offsetY, center.z);

        // 3. คำนวณระยะห่าง
        float distance = Vector3.Distance(player1.position, player2.position);

        // 4. ปรับ zoom
        targetCamera.orthographicSize = distance * zoomMultiplier;
    }
}