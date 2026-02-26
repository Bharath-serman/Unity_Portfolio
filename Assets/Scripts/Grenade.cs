using UnityEngine;
using UnityEngine.Audio;

public class Grenade : MonoBehaviour
{

    //delay
    public float delay = 3f;
    bool isexploded = false;
    float countdown;
    public GameObject effect;
    float radius = 1f;
    [Range(0f,600f)]
    public float force = 300f;

    public AudioSource audiosource;

    void Start()
    {
        //set the countdown to delay
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;  // Timer reverse

        //check if it is 0
        if (countdown <= 0f && !isexploded)
        {
            Explode();
            isexploded = true;
        }

    }

    #region ExplosionLogic
    void Explode()
    {
        Debug.LogError("Boom!");
        //add effect
        Instantiate(effect, transform.position, transform.rotation);
        audiosource.Play();

        //get nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        //iterate through colliders array
        foreach (Collider nearobjects in colliders)
        {
            //get the rigidbody
            Rigidbody rb = nearobjects.GetComponent<Rigidbody>();
            //check if rigidbody exist
            if (rb != null)
            {
                //add force
                rb.AddExplosionForce(force, transform.position, radius);

            }
        }
        //destroy the grenade
        Destroy(gameObject);

    } 
    #endregion
}
