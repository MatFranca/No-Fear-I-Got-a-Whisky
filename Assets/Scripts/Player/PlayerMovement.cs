using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Animator anim; //referencia ao animator componet
    Rigidbody playerRididbody;
    int floorMask;
    float camRayLength = 100f;

    PlayerShooting ammo;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRididbody = GetComponent<Rigidbody>();
        ammo = GetComponentInChildren<PlayerShooting>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
    }

    void Move(float h, float v)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            movement.Set(0f, 0f, 0f);

            movement = movement.normalized * speed * Time.deltaTime;

            playerRididbody.MovePosition(transform.position + movement);
        }
        else
        {
            movement.Set(h, 0f, v);

            movement = movement.normalized * speed * Time.deltaTime;

            playerRididbody.MovePosition(transform.position + movement);
        }
    }


    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRididbody.MoveRotation(newRotation);
 
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUpAmmo")
        {
            ammo.ammo += 10;

            Destroy(other.gameObject);

        }
    }
}
