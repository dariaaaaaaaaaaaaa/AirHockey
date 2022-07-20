using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
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
            enemy.gameObject.transform.position = mousePos;
        }
    }
}
