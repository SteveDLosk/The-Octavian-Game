using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    // Values to keep camera 'in bounds'
    public Transform TopWall, BottomWall, RightWall, LeftWall;
    private float yMax, yMin, xMax, xMin;
    
    // Use this for initialization
	void Start ()
    {
        offset = transform.position - player.transform.position;



        yMax = TopWall.transform.position.y;
        yMin = BottomWall.transform.position.y;
        xMax = RightWall.transform.position.x;
        xMin = LeftWall.transform.position.x;

    }
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = player.transform.position + offset;

        // Monitor player x position, follow camera accordingly
        float xPos = player.transform.position.x;

        if (xPos > xMax)
            xPos = xMax;
        else if (xPos < xMin)
            xPos = xMin;
        // New Code
        {
            // Player toward center of map; direct camera follow
            if (player.transform.position.y > yMin &&
                player.transform.position.y < yMax)
            {
                transform.position = new Vector3(xPos, 
                    player.transform.position.y, -110.0f);
            }

            // Player not within y bounds, camera locks
            else if (player.transform.position.y < yMin)
            {
                transform.position = new Vector3(xPos,
                    yMin, -110.0f);
               
            }
            else if (player.transform.position.y > yMax)
            {
                transform.position = new Vector3(xPos,
                    yMax, -110.0f);
               
            }
            
        }

    }


}
