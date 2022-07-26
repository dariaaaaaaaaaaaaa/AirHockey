
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector2 mousePos;
    [SerializeField] private Vector2 minClamp;
    [SerializeField] private Vector2 maxClamp;
    private bool canMove;


   
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            canMove = true;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePos.x = Mathf.Clamp(mousePos.x, minClamp.x, maxClamp.x);
            mousePos.y = Mathf.Clamp(mousePos.y, minClamp.y, maxClamp.y);
            player.gameObject.transform.position = mousePos;
           
        }
        else
        {
            canMove = false;
        }
        if (canMove)
        {
            transform.position = mousePos;
        }

        
    }
}
