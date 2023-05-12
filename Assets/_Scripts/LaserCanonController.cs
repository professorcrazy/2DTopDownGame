using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCanonController : MonoBehaviour
{
    LineRenderer line;
    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(transform.position, transform.right);
//        Debug.DrawLine(transform.position, hit.point,Color.green);
        if (hit) {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, hit.point);
            hit.collider.GetComponent<PlayerController>()?.KillPlayer();
        }
    }
    
}
