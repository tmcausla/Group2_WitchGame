using UnityEngine;

public class DropBoulder : MonoBehaviour
{
    private float timer;
    public GameObject boulder;

    private void Start()
    {
        timer = Random.Range(15, 30);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            _ = Instantiate(boulder, transform.position, transform.rotation);
            timer = Random.Range(7, 21);
        }
    }
}
