using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform GroundCheck;
    public float EnemySpeed;
    public float EnemyDistance;
    private bool MovingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right*EnemySpeed*Time.deltaTime);
        RaycastHit2D hit = Physics2D.Raycast(GroundCheck.position, Vector2.down, EnemyDistance);
        if(hit.collider == false)
        {
            if(MovingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                MovingRight = false;
            }else{
                transform.eulerAngles = new Vector3(0, 0, 0);
                MovingRight = true;
            }
        }
    }
}
