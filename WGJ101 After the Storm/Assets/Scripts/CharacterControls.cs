using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    private Camera main;
    public GameObject handLocation;
    private GameObject heldObject;
    private FixedJoint joint;
    public float throwPower;
    public float throwPowerDrunk;
    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        InputCheck();
    }

    void InputCheck()
    {
        if(Input.GetButtonDown("Pick Up"))
        {
            Ray ray = main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 2.5f))
            {
                Pickup obj = hit.transform.gameObject.GetComponent<Pickup>();
                if(obj != null && heldObject == null)
                {
                    obj.transform.position = handLocation.transform.position;
                    Rigidbody rb = obj.GetComponent<Rigidbody>();
                    rb.useGravity = false;
                    if(obj.gameObject.tag == "Drunk")
                    {
                        rb.isKinematic = true;
                    }
                    heldObject = obj.gameObject;
                    if (obj.gameObject.tag != "Drunk")
                    {
                        joint = obj.gameObject.AddComponent<FixedJoint>();
                        joint.connectedBody = handLocation.gameObject.GetComponent<Rigidbody>();
                        joint.enableCollision = false;
                    }
                    obj.transform.SetParent(handLocation.transform);
                }
                else if(heldObject != null)
                {
                    Rigidbody rb = heldObject.GetComponent<Rigidbody>();
                    rb.useGravity = true;
                    rb.isKinematic = false;
                    if (joint != null)
                    {
                        Destroy(joint);
                    }
                    heldObject.transform.SetParent(null);
                    heldObject = null;

                }
                else
                {

                }
            }
        }
        if(Input.GetButtonDown("Throw"))
        {
            if(heldObject != null)
            {
                Rigidbody rb = heldObject.GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.isKinematic = false;
                if (heldObject.gameObject.tag == "Drunk")
                {
                    rb.AddForce(main.transform.forward * throwPowerDrunk);
                }
                else
                {
                    rb.AddForce(main.transform.forward * throwPower);
                }
                if (joint != null)
                {
                    Destroy(joint);
                }
                heldObject.transform.SetParent(null);
                heldObject = null;
                Debug.Log("YEET!");
            }
            else
            {

            }
        }
    }
}
