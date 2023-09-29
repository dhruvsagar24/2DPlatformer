using UnityEngine;

public class InfinteScrolling : MonoBehaviour
{
    private Transform backgroundTransform;
    private float backgroundWidth;
    public Transform player;

    private void Start()
    {
        backgroundTransform = transform.GetChild(0); // Assuming the background is the only child.
        backgroundWidth = backgroundTransform.GetComponent<SpriteRenderer>().bounds.size.x;

        // Find the player object (you can set it manually or find it using a tag or another method).
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Calculate the speed based on the player's movement.
        float speed = player.GetComponent<Rigidbody2D>().velocity.x;

        // Move the background with the player's speed.
        Vector3 newPosition = backgroundTransform.position + new Vector3(speed * Time.deltaTime, 0f, 0f);
        backgroundTransform.position = newPosition;

        // If the background goes off-screen, move it to the right.
        if (backgroundTransform.position.x > backgroundWidth)
        {
            backgroundTransform.position -= new Vector3(backgroundWidth, 0f, 0f);
        }
        else if (backgroundTransform.position.x < -backgroundWidth)
        {
            backgroundTransform.position += new Vector3(backgroundWidth, 0f, 0f);
        }
    }
}
