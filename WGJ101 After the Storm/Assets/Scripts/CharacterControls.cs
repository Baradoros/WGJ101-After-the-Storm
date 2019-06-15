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
                    heldObject = obj.gameObject;
                    joint = obj.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = handLocation.gameObject.GetComponent<Rigidbody>();
                    joint.enableCollision = false;
                    obj.transform.SetParent(handLocation.transform);
                }
                else if(heldObject != null)
                {
                    Rigidbody rb = heldObject.GetComponent<Rigidbody>();
                    rb.useGravity = true;
                    Destroy(joint);
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
                rb.AddForce(main.transform.forward * throwPower);
                Destroy(joint);
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
