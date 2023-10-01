using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class ParallaxEffect : MonoBehaviour
{   
    public float parallaxSpeed;
    private Transform cameraTransform;
    private float StartPositionX;
    private float spriteSizeX;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        StartPositionX = transform.position.x;
        spriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;

    }
    private void Update(){
        float relativeDist = cameraTransform.position.x * parallaxSpeed;
        transform.position = new Vector3(StartPositionX + relativeDist , transform.position.y , transform.position.z);

        //loop parallax effect
        float relativeCameraDist = cameraTransform.position.x * (1 - parallaxSpeed);
        if(relativeCameraDist > (StartPositionX + spriteSizeX)){
            StartPositionX += spriteSizeX;
        }
        else if(relativeCameraDist < (StartPositionX - spriteSizeX)){
            StartPositionX -= spriteSizeX;
        }
    }
    
}
