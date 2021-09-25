using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class BallCont : MonoBehaviour
{
    public float forceMultiplier;

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, z: forceInit.y)) * forceMultiplier;

        if (!isShoot)
            TrajectoryLine.Instance.GetTraj(forcevector: forceV, rb, startingPoint: transform.position);
    }

    private void OnMouseUp()
    {

        TrajectoryLine.Instance.HideLine();
        mouseReleasePos = Input.mousePosition;
        Shoot(Force: mousePressDownPos - mouseReleasePos);

    }

    

    void Shoot(Vector3 Force)
    {

        if (isShoot)
            return;

        rb.AddForce(new Vector3(Force.x, Force.y, z: Force.y) * forceMultiplier);
        isShoot = true;
        
    }
}
