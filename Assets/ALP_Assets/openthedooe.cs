using System.Collections;
using UnityEngine;

public class Opener : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask Layer;
    [SerializeField] private float distance;
    [SerializeField] private GameObject cam;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out hit, distance, Layer))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("IsOpen", true);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                anim.SetBool("IsOpen", false);
            }
        }
    }
}