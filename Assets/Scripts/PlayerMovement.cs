using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float Speed;

    [SerializeField]
    float xRange;

    [SerializeField]
    float angleRotation = 30f;

    [SerializeField]
    float currentRotationUp = 30f;


    Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRotation();
    }

    private void OnMove(InputValue value)// get direction from InputSystem;
    {
        direction = value.Get<Vector2>();
        //Debug.Log(direction);
    }

    void PlayerMove()
    {
        float xOffset = direction.x * Speed * Time.deltaTime;
        float yOffset = direction.y * Speed * Time.deltaTime;

        float newXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange); // limit the move on X
        float newYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -xRange, xRange); // limit the move on Y


        //Debug.Log(newXPos);

        transform.localPosition = new Vector3(newXPos, newYPos, 0);
    }

    void PlayerRotation()
    {
        float currentRotation = angleRotation * direction.x;
        float currentRotationUp = angleRotation * direction.y;
        Debug.Log("Rotation " + currentRotation);
        //Debug.Log("Direction " + direction.x);
        Quaternion targetRotaton = Quaternion.Euler(currentRotationUp, 0, currentRotation);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotaton, Time.deltaTime*2);

    }


}
