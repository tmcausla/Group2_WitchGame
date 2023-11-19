using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject Bullet1;
    private Vector3 mousePos;
    private Camera mainCam;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force;
    [SerializeField] private float projectileLife;

    
    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);

        Physics2D.IgnoreLayerCollision(7, 11, true);
    }
    private void Update()
    {
        projectileLife -= Time.deltaTime;
        if(projectileLife <= 0) //destroys bullet after time expires
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Bullet"))  //bullets do not disappear if colliding with player character or other bullets
        {
            Destroy(gameObject);
        }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);  //Rework if giving health to enemies
        }
    }

}
