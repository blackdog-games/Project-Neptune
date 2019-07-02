using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating : MonoBehaviour
{
    public GameObject Water;
    public GameObject Floaty;
    Vector3 force = new Vector3(0, 20, 0);
    public Rigidbody rb;
    public float viscosity = .5f;
    public BoxCollider B;
    Vector3 LocalPoint = new Vector3(2.3f,0,0);
    // Start is called before the first frame update
    void Start()
    {
        Vector3 size = B.size;
        Vector3 WorldPoint = Floaty.transform.TransformPoint(LocalPoint);
        //rigidbody.AddForce(300, 1, 0);
        Debug.Log(size);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y<Water.transform.position.y)
        {
            rb.AddForce(force);
            rb.AddForce(rb.velocity * -1 * viscosity);
        }
    }
    void NewCenter()
    {

    }
}
