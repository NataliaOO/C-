using UnityEngine;
public class PlayerLook : MonoBehaviour
{
    float mouseSense = 0.5f;   
    void Update()
    {       
        foreach (var touch in Input.touches)
        {
            if (touch.position.x >= Screen.width / 2)
            {
                float rotateX = touch.deltaPosition.x * mouseSense; 
                float rotateY = touch.deltaPosition.y * mouseSense; 

                Vector3 rotPlayer = transform.rotation.eulerAngles;
                
                rotPlayer.x = (rotPlayer.x > 180) ? rotPlayer.x - 360 : rotPlayer.x;
                rotPlayer.x = Mathf.Clamp(rotPlayer.x, -40, 50);
                rotPlayer.x -= rotateY;               
                rotPlayer.y += rotateX;

                transform.rotation = Quaternion.Euler(rotPlayer);  
            }
        }
    }
}