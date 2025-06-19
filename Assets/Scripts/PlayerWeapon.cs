using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    GameObject []lasers;

    [SerializeField]
    RectTransform crosshairTransform;

    [SerializeField]
    Transform targetPoint;


    bool isFiring;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
        MoveCrosshair();
        MoveTargetPoint();
        AimLaser();

    }

    void OnFire(InputValue inputValue)
    {
        //Debug.Log("Button pressed is ");
        isFiring = inputValue.isPressed;
        Debug.Log("isFiring " + isFiring);
    }

    void Shooting()
    {
        foreach (var weapon in lasers)
        {
            var mEmission = weapon.GetComponent<ParticleSystem>().emission;
            mEmission.enabled = isFiring;
        }

    }

    void MoveCrosshair()
    {
        crosshairTransform.position = Input.mousePosition;
    }

    void MoveTargetPoint()
    {
        Vector3 aimPosition = Input.mousePosition;
        aimPosition.z = 50;
        targetPoint.position = Camera.main.ScreenToWorldPoint(aimPosition);
    }

    void AimLaser()
    {
        foreach (var laser in lasers)
        {
            Vector3 aimDirection = targetPoint.position - this.transform.position; //get distance and direction
            Quaternion targetRotation = Quaternion.LookRotation(aimDirection); //rotate to directon
            laser.transform.rotation = targetRotation; // aim laser to direction

        }
        
    }
}
