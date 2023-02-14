using UnityEngine;

public class LateralMovement : MonoBehaviour
{
    public float speed = 1.0f; // Vitesse de déplacement
    public float amplitude = 2.0f;
    private Vector3 startPos; // Position de départ
    private bool movingRight = true; // Direction de déplacement (droite ou gauche)

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime; // Calcule la distance à parcourir

        if (movingRight)
        {
            // Se déplace vers la droite
            transform.position = Vector3.MoveTowards(transform.position, startPos + Vector3.right * amplitude, step);
            if (transform.position.x >= startPos.x + amplitude)
            {
                movingRight = false; // Change la direction de déplacement
            }
        }
        else
        {
            // Se déplace vers la gauche
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
            if (transform.position.x <= startPos.x)
            {
                movingRight = true; // Change la direction de déplacement
            }
        }
    }
}
