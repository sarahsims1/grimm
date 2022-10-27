using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class snowevent : MonoBehaviour
{
    public Renderer snow;

    public Material ahhh;

    private bool chase;

    public GameObject player;

    public float speed;

    public delegate void Run();
    public static Run limpStart;

    static snowevent run;

    public GameObject runGraphic;

    private bool runFade;

    private Color color;

    public Beginning beg;

    public FirstPersonController fps;

    public MusicChange ms;

    public AudioClip whispers;

    public float fadeTime = 1;
    private void Start()
    {
        run = gameObject.GetComponent<snowevent>();
        color = runGraphic.GetComponent<SpriteRenderer>().color;
    }
    public static void Begin()
    {
        run.Runn(true);
    }

    private void Update()
    {
        if(runFade && color.a < 1)
        {
            color.a += fadeTime * Time.deltaTime;
            runGraphic.GetComponent<SpriteRenderer>().color = color;
        }

        if(chase)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        }
    }
    void Runn(bool start)
    {
        if (start)
        {
            staticStuff.runSoured = true;
            snow.material = ahhh;
            fps.Frozen(false);
            runFade = true;
            StartCoroutine(ChaseScene());
            StartCoroutine(ms.ChangeMusicFade(whispers, 1f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(chase && other.tag.Equals("Player"))
        {
            //Reset
            staticStuff.badFlags++;
            beg.ResetController("//$5b**#^//____`~%. //$5b**#^fgh$$5b**#^_`~//$5b**000*4@@3#//$5b**#^//____`~%.//$5b**#^//____`~%.");
        }
    }

    private IEnumerator ChaseScene()
    {
        yield return new WaitForSecondsRealtime(7f);
        chase = true;
    }

}
