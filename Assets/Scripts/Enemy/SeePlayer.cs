using UnityEngine;

public class SeePlayer : MonoBehaviour
{

    private Transform playerTransform;
    public GameObject Arrow;
    public bool isSeeing;
    public float seeDistance;
    public float countDown;
    public float countDownOver;
    public bool shooting;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        FlipPosition();
        if (shooting == false)
        {
            countDown += Time.deltaTime;
            if (countDown > countDownOver)
            {
                shooting = true;
                countDown = 0;
            }
        }

        if (isSeeing == true && shooting == true)
        {
            ShootPlayer();
            shooting = false;
            return;
        }
        isSeeing = false;
        isSeeing = Vector2.Distance(transform.position, playerTransform.position) < seeDistance;
    }

    private void ShootPlayer()
    {
        _ = Instantiate(Arrow, transform.position, transform.rotation);
        shooting = false;
    }
    private void FlipPosition()
    {
        if (transform.position.x > playerTransform.position.x && isSeeing == true)
        {
            transform.localScale = new Vector3(1, 1, 1);
            return;
        }
        transform.localScale = new Vector3(-1, 1, 1);
    }
}
