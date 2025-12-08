using NUnit.Framework.Internal;
using UnityEditor.Build.Content;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dog_Script : MonoBehaviour
{
    //Sound
    public AudioSource AS;
    public AudioClip[] Barks;

    //Misc.
    public ParticleSystem PS;
    public SpriteRenderer SR;

    //Food System
    public Food_script food_script;
    public int maxHunger = 100;
    public int CurrentHunger;


    //Movement
    public float Speed = 2f;
    public float goingX;
    public Vector3 Dest;
    public Vector3 startpos;

    void Start()
    {
        CurrentHunger = maxHunger;
        food_script.HungerMax(maxHunger);
        InvokeRepeating("Starve", 0f, 3f);

        //Move
        startpos = transform.position;
        Dest.y = startpos.y;
        goingX = Random.Range(-7, 7);
        Dest.x = goingX;
    }
    void Update()
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
    }
    void Starve()
    {
        CurrentHunger -= 10;
        food_script.HungerValue(CurrentHunger);
    }

}
