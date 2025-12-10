using NUnit.Framework.Internal;
using UnityEditor.Build.Content;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using JetBrains.Annotations;

public class Dog_Script : MonoBehaviour
{
    //Sound
    public AudioSource AS;
    public AudioClip[] Barks;

    //Misc.
    public Bowl_Script Bowlisfull;
    public bool Nothungry;
    public SpriteRenderer SR;
    public Sprite cheerful;
    public Sprite normal;

    //Food System
    public Food_script food_script;
    public int maxHunger = 100;
    public int CurrentHunger;


    //Movement
    public float Speed = 2f;
    public float goingX;
    public Vector3 Dest;
    public Vector3 startpos;
    public Vector3 Bowldes;

    void Start()
    {
        CurrentHunger = maxHunger;
        food_script.HungerMax(maxHunger);
        InvokeRepeating("Starve", 0f, 3f);

        //Move
        startpos = transform.position;
        Dest.y = startpos.y;
        Bowldes.y = startpos.y;
        goingX = Random.Range(-7, 7);
        Dest.x = goingX;
        Bowldes.x = 7;

        //Food stuff
        Bowlisfull.BowlFull += gotoFood;
        Nothungry = true;
    }
    void Update()
    {
        if (Nothungry)
        {


            if (transform.position == Dest)
            {
                goingX = Random.Range(-7, 7);
                Dest.x = goingX;
                transform.Rotate(0, 180, 0);
            }
            else if (transform.position != Dest)
            {
                transform.position = Vector3.MoveTowards(transform.position, Dest, Speed * Time.deltaTime);
            }
        }
        else if (Nothungry == false)
        {
            Debug.Log("walking");
            if (transform.position != Bowldes)
            {
                transform.position = Vector3.MoveTowards(transform.position, Bowldes, Speed * Time.deltaTime);
            }
            else
            {
                CurrentHunger += 20;
                Benormal();
            }
            food_script.HungerValue(CurrentHunger);
        }
        // dies
        if (CurrentHunger == 0)
        {
            SceneManager.LoadScene("End");
        }
    }
    public void OnMouseDown()
    {
        AudioClip randomclip = Barks[Random.Range(0, 4)];
        AS.PlayOneShot(randomclip);
        SR.sprite = cheerful;
        StartCoroutine(NoCheer());
    }
    IEnumerator NoCheer()
    {
        yield return new WaitForSeconds(1);
        SR.sprite = normal;
    }
    void Starve()
    {
        CurrentHunger -= 10;
        food_script.HungerValue(CurrentHunger);
    }
    void gotoFood()
    {
        Nothungry = false;
    }
    void Benormal()
    {
        Nothungry = true;
        Bowlisfull.Lickedclean();
    }
    

}
