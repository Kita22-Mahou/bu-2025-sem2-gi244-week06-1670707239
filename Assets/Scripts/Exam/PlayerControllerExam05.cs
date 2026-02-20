using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam05 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;


    // Exam 05 ...
    public int maxBulletCount = 10;
    public int currentBulletCount;
    public float coolDownTime = 0f;
    public float bulletRegenerateCooldown = 4f;
    
    // ...

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
        currentBulletCount = maxBulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        if (shootAction.triggered && currentBulletCount > 0)
        {
            currentBulletCount--; 
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }

        if (currentBulletCount <= 0)
        {
            coolDownTime += Time.deltaTime;
        }

        if (coolDownTime >= bulletRegenerateCooldown)
        {
            currentBulletCount = maxBulletCount;
            coolDownTime = 0;
        }

    }
}
