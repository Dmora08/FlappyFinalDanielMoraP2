using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public float upforce = 200f;
    
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {

            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upforce));
                anim.SetTrigger("Flap");
            }
        }
      }

    void OnCollisionEnter2D()
    {
        isDead = true;
        anim.SetTrigger("Die");
        GameController.instance.BirdDied();
    }

}
