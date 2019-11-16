using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maps : MonoBehaviour
{
    //public AudioClip confirm;
    // public AudioClip cancel;

    public Sprite start;
    public PolygonCollider2D maps;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  /**
   * permet de creer un point de demarage dans la map
   * */
    void initMap()
    {
        Vector2 positionStart;

        do
        {
            positionStart = new Vector2(Random.value, Random.value);

        } while (maps.OverlapPoint(positionStart));
      //  float random = UnityEngine.Random.Range(0, 20);
      //  start.transform.position = 
      //  start.tr


    }

    

    private static Vector3 RandomPointInBox(Vector3 center, Vector3 size)
    {

        return center + new Vector3(
           (Random.value - 0.5f) * size.x,
           (Random.value - 0.5f) * size.y,
           (Random.value - 0.5f) * size.z
        );
    }

}
