
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector2 mousePos;
    [SerializeField] private Vector2 minClamp;
    [SerializeField] private Vector2 maxClamp;
   

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePos.x = Mathf.Clamp(mousePos.x, minClamp.x, maxClamp.x);
            mousePos.y = Mathf.Clamp(mousePos.y, minClamp.y, maxClamp.y);
            player.gameObject.transform.position = mousePos;


/*            return;
            if (mousePos.y <= upLeft.y && mousePos.y >= downRight.y && mousePos.x <= upLeft.x && mousePos.x >= downRight.x)
             {
                player.gameObject.transform.position = mousePos;
             }*/
        }
    }
}
