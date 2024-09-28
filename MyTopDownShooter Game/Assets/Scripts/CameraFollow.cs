using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Refer�ncia ao jogador
    public Vector3 offset;    // Offset da posi��o da c�mera em rela��o ao jogador
    public float smoothSpeed; // Velocidade de suaviza��o

    // Limites da c�mera
    public float minX, maxX, minY, maxY;

    void LateUpdate()
    {
        // Calcula a posi��o desejada com o offset
        Vector3 desiredPosition = player.position + offset;

        // Limita a posi��o da c�mera para que n�o ultrapasse os limites
        float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(desiredPosition.y, minY, maxY);

        // Aplica os limites � posi��o da c�mera
        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        // Suaviza o movimento da c�mera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);

        // Atualiza a posi��o da c�mera
        transform.position = smoothedPosition;
    }
}
