using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Maps : MonoBehaviour
{
    public AudioClip confirm;
    public AudioClip cancel;
    public AudioClip music;
    //public Sprite start;

    public GameObject buttonPrefabRed; // bouton rouge indiquant un lieu a visiter
    public GameObject canvas; // this
    public GameObject buttonGreen; // bouton vert d'event

    public GameObject BoxDialog, TextDialog;

    public static int level = 0; // numero du level permettant de determine le nombre de points a faire apparaitre

    public static Maps instance = null; // variable permettant de rendre la classe static

    bool boolean = false;
    GameObject button;
    int scene = 0;
    //permet de rendre la classe static


    void Awake()
    {

        /*
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
        
        buttonPrefabRed.SetActive(true);*/
        Debug.Log("Awake");
        
    }



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start maps scene ");
        button = new GameObject();
        //SoundManager.instance.PlaySingle(music);

        //GameObject lastButton =  createButton(generatePointInMaps(),""); // on creer un 1er boutton
        for (int i = 2; i < level; i++) // pour chaque niveau on genere un boutton proche de l'ancien
        {
            //lastButton = createButton(generatePointNear(new Vector2(lastButton.transform.position.x, lastButton.transform.position.y),80), "");
        }
        BoxDialog.SetActive(false);

        // createButtonCombat(generatePointInMaps(), "");

        Debug.Log("end start maps scene  for level" + level);
        buttonGreen.SetActive(false);
        if (level >= 1)
        {
            buttonGreen.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        /*
        Debug.Log("update maps scene ");
        if (boolean== true)
        {
            createButton(generatePointInMaps(), "");
            boolean = false;
        }
        Debug.Log("update end map scene ");*/
    }

    public void ShowDialog()
    {
        BoxDialog.SetActive(true);
    }

    private void createButtonCombat(Vector2 position, string text)
    {
        boolean = true;
        /*
        GameObject button = (GameObject)Instantiate(buttonPrefabRed);

        //button.transform.position = new Vector3(position.x, position.y, 0);

        button.transform.SetPositionAndRotation(new Vector3(position.x, position.y, 0), new Quaternion(0, 0, 0, 0));

        button.transform.SetParent(canvas.transform);//Setting button parent


        //button.transform.position = new Vector3(position.x,position.y,0);



        button.GetComponent<Button>().onClick.AddListener(generateCombatScene);//Setting what button does when clicked
        button.transform.GetChild(0).GetComponent<Text>().text = text;//Changing text

 */
    }

    /**
     * utlisé pour creer un nouveau lieu a visiter
     * @param position = position du button sur le background
     * @param text = texte du boutton 
     * */
    private GameObject createButton(Vector2 position, string text)
    {
        Debug.Log("create button ");
        button = Instantiate(buttonPrefabRed) as GameObject;
        Debug.Log("instantiate ");
        //button.transform.position = new Vector3(position.x, position.y, 0);

        button.transform.SetPositionAndRotation(new Vector3(position.x, position.y, 0), new Quaternion(0, 0, 0, 0));
        Debug.Log("position maps scene ");
        button.transform.SetParent(canvas.transform);//Setting button parent
        Debug.Log("canvas set parent ");


        //button.transform.position = new Vector3(position.x,position.y,0);



        button.GetComponent<Button>().onClick.AddListener(generateCombatScene);//Setting what button does when clicked
        button.transform.GetChild(0).GetComponent<Text>().text = text;//Changing text
        Debug.Log("Text maps scene ");

        return button;
    }
    /**
     * utilisé pour genere la position du 1er point
     *//*
    private Vector2 generatePointInMaps()
    {
        Vector2 position = new Vector2(150,150);
        Debug.Log("generte point maps scene ");
     
        do
        {
            position = new Vector2(Random.Range(100, 550), Random.Range(25, 350)); // on creer un pts random
        
            Debug.Log("NEW POSITION X :"+position.x+" Y:"+position.y);

        } while (!canvas.GetComponent<PolygonCollider2D>().OverlapPoint(position)); // on verifie qu'il est dans le canevas
        //canvas.GetComponent<PolygonCollider2D>().bounds.Contains(position);
        Debug.Log("position found and Overlap =  " + canvas.GetComponent<PolygonCollider2D>().OverlapPoint(position));
        // canvas.GetComponent<PolygonCollider2D>().OverlapPoint(position);


        return position;

    }*/
       /**
        * permet de generer un position proche d'une position donnée
        * *//*
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
       }*/





   public void generateCombatScene()
    {
        // algorithme aleratoire qui definit la scene
        SoundManager.instance.RandomizeSfx(confirm);

        BoxDialog.SetActive(true);
        TextDialog.transform.GetComponent<Text>().text = "Vous vous reveillé avec un mal de crâne ....";//Changing text
        scene = 1;
        Debug.Log(" -- scene de Combat crée --");

    }

    public void generateEventScene()
    {
        // algorithme aleratoire qui definit la scene
        SoundManager.instance.RandomizeSfx(confirm);
        scene = 2;
        BoxDialog.SetActive(true);
        string text = "";
        switch (Random.Range(0, 2))
        {
            case 0:
                text = "C'est calme, trop calme.....";
                break;
            case 1:
                text = "Vous entendez quelqu'un approcher";
                break;
            case 2:
                text = "il y a quelque chose sur la route";
                break;

        }

        TextDialog.transform.GetComponent<Text>().text = text;//Changing text

        Debug.Log(" -- scene de Combat crée --");

    }

    public void dialogButtonYes()
    {

        SoundManager.instance.RandomizeSfx(confirm);
        BoxDialog.SetActive(false);
        BoxDialog.SetActive(false);
        //canvas.SetActive(false);
        buttonPrefabRed.SetActive(false);

        switch (scene)
        {
            case 1:
                SceneManager.LoadScene("Combat");
                break;
            case 2:
                SceneManager.LoadScene("Event");
                break;

            default:
                Debug.Log(" -- ERROR selection scene  --");
                break;
        }
    }


    public void dialogButtonNo()
    {
        SoundManager.instance.RandomizeSfx(cancel);
        BoxDialog.SetActive(false);

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
