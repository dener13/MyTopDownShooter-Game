using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Referência ao jogador
    public Vector3 offset;    // Offset da posição da câmera em relação ao jogador
    public float smoothSpeed; // Velocidade de suavização

    // Limites da câmera
    public float minX, maxX, minY, maxY;

    void LateUpdate()
    {
        // Calcula a posição desejada com o offset
        Vector3 desiredPosition = player.position + offset;

        // Limita a posição da câmera para que não ultrapasse os limites
        float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(desiredPosition.y, minY, maxY);

        // Aplica os limites à posição da câmera
        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        // Suaviza o movimento da câmera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);

        // Atualiza a posição da câmera
        transform.position = smoothedPosition;
    }
}
