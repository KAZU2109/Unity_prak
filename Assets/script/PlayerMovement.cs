using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body; 
    public float speed;
    public float jump;
    public float stomp;
    private Animator animato;
    private bool landed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animato =  GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hinput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(hinput*speed , body.velocity.y);

        if(hinput > 0.01f)
            transform.localScale = new Vector2(2, 2);
        else if(hinput < -0.01f)
            transform.localScale = new Vector2(-2, 2);

        if(Input.GetKey(KeyCode.W) && landed)
            Jump();

        if(Input.GetKey(KeyCode.S))
            body.velocity = new Vector2(body.velocity.x, stomp);

        animato.SetBool("run", hinput != 0);
        animato.SetBool("landed", landed);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump);
        animato.SetTrigger("jump");
        landed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
            landed = true;
        else if(collision.gameObject.tag == "Water")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
