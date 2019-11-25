using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAnimation : MonoBehaviour
{
    public Sprite[] sprite;
    private Vector3 end = new Vector3(10,10,0);
    private Vector3 start;
    private Vector3 direction;
    public bool go = false;

    private SpriteRenderer spriteRenderer;

    private float time = 0;
    public float frameRate = 2;
    public float speed = 5;

    void Start()
    {
        start = transform.position;
    }

    // Start is called before the first frame update
    private void Setup()
    {
        direction = (end - start).normalized;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite[0];
        transform.rotation = Quaternion.Euler(0,0, 180 + Vector3.SignedAngle(Vector3.right, direction, Vector3.forward));
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            direction = (end - start).normalized;
            time += Time.deltaTime;
            if (time > 1 / frameRate)
            {
                spriteRenderer.sprite = sprite[Random.Range(0, sprite.Length)];
                time = 0;
            }
            float dist = Vector3.Distance(transform.position, end);
            // Debug.Log("distance : " + dist);
            if (dist > 5)
            {
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                AtDestination();
            }
        }
    }

    private void AtDestination()
    {
        go = false;
        Debug.Log("BOOM");
        Destroy(this.gameObject);
    }

    public void SetTarget(Vector3 target)
    {
        end = target;
        Setup();
        go = true;
    }
}
