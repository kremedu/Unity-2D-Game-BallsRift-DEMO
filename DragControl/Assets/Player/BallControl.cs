using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BallControl : MonoBehaviour
{
    public float power = 10f;
    public float maxDrag = 5f;
    public Rigidbody2D rb;
    public LineRenderer lr;


    public GameObject endMenu;
    public GameObject levelEndMenu;

    public int ownCoins;

    

    Vector3 dragStartPos;
    
    Touch touch;


    public float areaOfEffect;
    public LayerMask whatIsDestructible;
    public float damage;
    //public GameObject effect;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaOfEffect);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DestructibleTag")) //Destroy Destructibles -> Ground
        {
            Collider2D[] objectsToDamage = Physics2D.OverlapCircleAll(transform.position, areaOfEffect, whatIsDestructible);
            for (int i = 0; i < objectsToDamage.Length; i++)
            {
                objectsToDamage[i].GetComponent<DestroyThis>().hp -= damage;
            }
            //Instantiate(effect, transform.position, Quaternion.identity);
        }

        float Xvel = rb.velocity.x;

        if (other.CompareTag("SlowTag"))
        { 
            rb.velocity = new Vector2(Xvel, 0);
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Killer"))
        {
            endMenu.SetActive(true);
            Destroy(gameObject);
            
            //Spawn DeathParticle
            //Watch ad for revive
            //EndMenu
        }
        if(other.CompareTag("LevelEnd"))
        {
            levelEndMenu.SetActive(true);
            Destroy(gameObject);
        }
    }


    public float maxSpeed = 200f;//Replace with your max speed
    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void Update()
    {
        //lr.SetPosition(0, transform.position);
        //Mobile Touch
        if (Input.touchCount > 0)
        {
            
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                rb.velocity = Vector3.zero;
                DragStart(touch.position);
            }
            if(touch.phase == TouchPhase.Moved)
            {
                rb.velocity = Vector3.zero;
                Dragging(touch.position);
            }
            if(touch.phase == TouchPhase.Ended)
            {
                
                DragRelease(touch.position);
            }
        }
        //Mouse
        if (Input.GetMouseButtonDown(0)) 
        {
            rb.velocity = Vector3.zero;
            DragStart(Input.mousePosition);
        }
        if(Input.GetMouseButton(0))
        {
            rb.velocity = Vector3.zero;
            Dragging(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            
            DragRelease(Input.mousePosition);
        }


        if (Input.GetKeyDown("u"))
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
    void DragStart(Vector3 cPos) 
    {
        lr.enabled = true;
        dragStartPos = Camera.main.ScreenToWorldPoint(cPos);
        dragStartPos.z = 0f;
        lr.positionCount = 1; 
        lr.SetPosition(0, dragStartPos);

    }
    void Dragging(Vector3 cPos) 
    {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(cPos);
        draggingPos.z = 0f;
        lr.positionCount = 2;
        lr.SetPosition(1, draggingPos); //lr.SetPosition(1, draggingPos);
    }
    void DragRelease(Vector3 cPos) 
    {
        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(cPos);
        dragReleasePos.z = 0f;

        Vector3 force = (dragStartPos - dragReleasePos) *-1; //Ters Cevirmek icin sonucu -1 ile carp ve LineRenderer yönünün zittini al
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);
        lr.enabled = false;
    }
}
