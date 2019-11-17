using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maps : MonoBehaviour
{
    //public AudioClip confirm;
    // public AudioClip cancel;
    public AudioClip music;
    //public Sprite start;
    
    public GameObject buttonPrefabRed; // bouton rouge indiquant un lieu a visiter
    public GameObject canvas; // this

    public static int level = 5; // numero du level permettant de determine le nombre de points a faire apparaitre

    public static Maps instance = null; // variable permettant de rendre la classe static

    //permet de rendre la classe static
    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }



    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlaySingle(music);

        GameObject lastButton =  createButton(generatePointInMaps(),"1"); // on creer un 1er boutton
        for (int i = 2; i < level; i++) // pour chaque niveau on genere un boutton proche de l'ancien
        {
            lastButton = createButton(generatePointNear(new Vector2(lastButton.transform.position.x, lastButton.transform.position.y),80), i.ToString());
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void generateCombatScene()
    {

        Debug.Log(" -- scene de Combat crée --");

    }
    /**
     * utlisé pour creer un nouveau lieu a visiter
     * @param position = position du button sur le background
     * @param text = texte du boutton 
     * */
    private GameObject createButton(Vector2 position,string text)
    {

        GameObject button = (GameObject)Instantiate(buttonPrefabRed);

        //button.transform.position = new Vector3(position.x, position.y, 0);

        button.transform.SetPositionAndRotation(new Vector3(position.x, position.y, 0), new Quaternion(0,0,0,0));

        button.transform.SetParent(canvas.transform);//Setting button parent
        

        //button.transform.position = new Vector3(position.x,position.y,0);

        
     
        button.GetComponent<Button>().onClick.AddListener(generateCombatScene);//Setting what button does when clicked
        button.transform.GetChild(0).GetComponent<Text>().text = text;//Changing text

        return button;
    }
    /**
     * utilisé pour genere la position du 1er point
     * */
    private Vector2 generatePointInMaps()
    {
        Vector2 position;

        do
        {
            position = new Vector2(Random.Range(100, 550), Random.Range(25, 350)); // on creer un pts random
          

        } while (!canvas.GetComponent<PolygonCollider2D>().OverlapPoint(position)); // on verifie qu'il est dans le canevas
       
        
        // canvas.GetComponent<PolygonCollider2D>().OverlapPoint(position);


        return position;

    }
    /**
     * permet de generer un position proche d'une position donnée
     * */
    private Vector2 generatePointNear(Vector2 pts,float distanceMax)
    {
        Vector2 position;

        do
        {
            position = pts + Random.insideUnitCircle * distanceMax;
            Debug.Log(" position x : "+position.x+" position y "+position.y);

        } while (!canvas.GetComponent<PolygonCollider2D>().OverlapPoint(position));

        Debug.Log(" ------ FIN ------ position x : " + position.x + " position y " + position.y);
        return position;
    }

    public void zoneCombat()
    {
        // algorithme aleratoire qui definit la scene
        Debug.Log(" -- scene de Combat --");

    }


    /*
     * //  Globals which should be set before calling this function:
//
//  int    polyCorners  =  how many corners the polygon has
//  float  polyX[]      =  horizontal coordinates of corners
//  float  polyY[]      =  vertical coordinates of corners
//  float  x, y         =  point to be tested
//
//  (Globals are used in this example for purposes of speed.  Change as
//  desired.)
//
//  The function will return YES if the point x,y is inside the polygon, or
//  NO if it is not.  If the point is exactly on the edge of the polygon,
//  then the function may return YES or NO.
//
//  Note that division by zero is avoided because the division is protected
//  by the "if" clause which surrounds it.

bool pointInPolygon() {

  int   i, j=polyCorners-1 ;
  bool  oddNodes=NO      ;

  for (i=0; i<polyCorners; i++) {
    if ((polyY[i]< y && polyY[j]>=y
    ||   polyY[j]< y && polyY[i]>=y)
    &&  (polyX[i]<=x || polyX[j]<=x)) {
      oddNodes^=(polyX[i]+(y-polyY[i])/(polyY[j]-polyY[i])*(polyX[j]-polyX[i])<x); }
    j=i; }

  return oddNodes; }*/

}
