using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Rigidbody rb;
    public float shootForce = 100f;
    private void FixedUpdate()
    {
        Move();
        Shoot();
        
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        rb.MovePosition(transform.position + moveDirection * moveSpeed) ;
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Получаем компонент Rigidbody снаряда
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

            // Применяем силу стрельбы, основанную на ротации объекта
            projectileRigidbody.AddForce(firePoint.forward * shootForce, ForceMode.Impulse);
        }
    }
}
