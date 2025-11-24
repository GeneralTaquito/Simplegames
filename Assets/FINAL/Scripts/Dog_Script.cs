using UnityEngine;

public class Dog_Script : MonoBehaviour
{
    //Misc.
    public ParticleSystem PS;
    public SpriteRenderer SR;
    public AudioSource AS;

    //Movement
    public int decideMove;
    public Vector3 startPos;
    public Vector3 endPos;
    public float delta = 1f;
    public float Speed = 1f;

    void Start()
    {
        startPos = transform.position;
        decideMove = Random.Range(1, 3);
        endPos.x = Random.Range(-3, 7);
        endPos.y = startPos.y;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPos, Speed * Time.deltaTime);

        
    }

    public void Moveback()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPos, Speed * Time.deltaTime);
    }

    void OnMouseDown()
    {

    }
}
