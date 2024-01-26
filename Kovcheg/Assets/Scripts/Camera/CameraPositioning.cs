using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform cameraParent;
    [SerializeField] private Transform axisRotationÑameraParent;
    [SerializeField] private Transform player;
    [SerializeField] private int minScroll = 3;
    [SerializeField] private int maxScroll = 3;
    [SerializeField] private float mouseSensitivity = 10;
    [SerializeField] private float scrollSensitivity = 1.5f;
    [SerializeField] private float cameraSpeed;
    private Vector3 playerPositionLastFrame;
    private Vector3 startCameraPosition;
    private Vector3 target;

    private void Start()
    {
        target = _camera.localPosition;
        playerPositionLastFrame = player.position;
        startCameraPosition = _camera.localPosition;
    }

    private void FixedUpdate()
    {
        Scroll();
        Move();
        Rotate();
    }

    private void Scroll()
    {
        float scrollValue = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;

        float nextScrollDistance = _camera.localPosition.z + scrollValue - startCameraPosition.z;

        if (scrollValue > 0 && nextScrollDistance > minScroll)
        {
            scrollValue -= nextScrollDistance - minScroll;
        }
        else if (scrollValue < 0 && nextScrollDistance < maxScroll * -1)
        {
            scrollValue += maxScroll * -1 - nextScrollDistance;
        }

        if (scrollValue != 0)
        {
            target = new Vector3(_camera.localPosition.x,
                _camera.localPosition.y,
                _camera.localPosition.z + scrollValue);
        }

        _camera.localPosition = Vector3.MoveTowards(_camera.localPosition, target, cameraSpeed);
    }

    private void Move()
    {
        if (playerPositionLastFrame != player.position)
        {
            Vector3 direction = player.position - playerPositionLastFrame;
            direction.y = 0;

            axisRotationÑameraParent.position += direction;
        }

        playerPositionLastFrame = player.position;
    }

    private void Rotate()
    {
        if (Input.GetMouseButton(2))
        {
            float horizontalInput = Input.GetAxis("Mouse X");

            if (horizontalInput != 0)
            {
                axisRotationÑameraParent.eulerAngles = 
                    new Vector3(axisRotationÑameraParent.eulerAngles.x,
                    axisRotationÑameraParent.eulerAngles.y + horizontalInput * mouseSensitivity,
                    axisRotationÑameraParent.eulerAngles.z);
            }
        }
    }
}
