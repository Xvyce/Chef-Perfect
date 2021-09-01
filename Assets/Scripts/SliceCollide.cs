using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceCollide : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    //public void isCollided(bool isCollided)
    //{
    //    animator.SetBool("isCollided", true);

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementUpdate>())// CDheck if it isapple
        {
            FindObjectOfType<AudioManagerScript>().Play("Cut_Fruit");
            animator.SetBool("isCollided", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementUpdate>())// CDheck if it isapple
        {
            animator.SetBool("isCollided", false);
            StartCoroutine("invisible");
        }


    }

    IEnumerator invisible()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(this);

    }
}
