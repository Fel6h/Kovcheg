using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float shootForce = 100f;

    private Vector3 startRotation;

    private void Start()
    {
        startRotation = transform.eulerAngles;
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
        Shoot();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            bool isRun;

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                isRun = true;
            }
            else
            {
                isRun = false;
            }

            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
            rb.AddRelativeForce(moveDirection * (isRun ? moveSpeed * 2 : moveSpeed));
        }
    }

    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 50))
            {
                Vector3 target = hit.point - transform.position;
                transform.forward = target;
                transform.rotation = Quaternion.Euler(startRotation.x, transform.eulerAngles.y, startRotation.z);
            }
        }
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Ïîëó÷àåì êîìïîíåíò Rigidbody ñíàðÿäà
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

            // Ïðèìåíÿåì ñèëó ñòðåëüáû, îñíîâàííóþ íà ðîòàöèè îáúåêòà
            projectileRigidbody.AddForce(firePoint.forward * shootForce, ForceMode.Impulse);
        }
    }
}
