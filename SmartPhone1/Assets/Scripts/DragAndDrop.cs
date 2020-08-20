using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool moveAllowed;
    Collider2D collider;
    public GameObject selectionEffect;
    public GameObject deathEffect;
    [SerializeField]
    private AudioSource[] source;

    private GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponents<AudioSource>();
        collider = GetComponent<Collider2D>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if(collider == touchedCollider)
                {
                    Instantiate(selectionEffect, transform.position, Quaternion.identity);
                    source[0].Play();
                    moveAllowed = true;
                }
            }
            if(touch.phase == TouchPhase.Moved)
            {
                if(moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }
            if(touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }
        }
    }

        private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.tag == "Atomos")
        {
            source[1].Play();
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            gm.GameOver();
        }
    }
}
