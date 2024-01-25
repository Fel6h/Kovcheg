using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform cameraParent;
    [SerializeField] private Transform axisRotationÑameraParent;
    [SerializeField] private Transform player;
    [SerializeField] private int minScroll = 3;
    [SerializeField] private int maxScroll = 3;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float mouseSensitivity;
    private int numberScrollSteps = 10;
    private List<Vector3> cameraPositions = new List<Vector3>();
    private int indexCurrentPostion;
    private Vector3 playerPositionLastFrame;

    private int IndexCurrentPostion
    {
        get
        {
            if (indexCurrentPostion < 0)
                indexCurrentPostion = 0;
            if (indexCurrentPostion == cameraPositions.Count)
                indexCurrentPostion = cameraPositions.Count - 1;

            return indexCurrentPostion;
        }
    }

    private void Start()
    {
        playerPositionLastFrame = player.position;
        FillListPositions();
    }

    private void FixedUpdate()
    {
        SetPosition();
        Rotate();
    }

    private void FillListPositions()
    {
        Vector3 endCameraPosition = _camera.localPosition;
        endCameraPosition.z += minScroll;
        float scrollStep = minScroll / ((float)numberScrollSteps / 2);

        for (int i = 0; i < numberScrollSteps / 2; i++)
        {
            AddPositions(scrollStep, endCameraPosition, i);
        }

        endCameraPosition = _camera.localPosition;
        scrollStep = maxScroll / ((float)numberScrollSteps / 2);

        for (int i = 0; i < numberScrollSteps / 2 + 1; i++)
        {
            AddPositions(scrollStep, endCameraPosition, i);
        }

        indexCurrentPostion = cameraPositions.Count / 2;
    }

    private void AddPositions(float scrollStep, Vector3 endCameraPosition, int index)
    {
            Vector3 newPosition = endCameraPosition;
            newPosition.z -= scrollStep * index;
            cameraPositions.Add(newPosition);
    }

    private void SetPosition()
    {
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");

        if (scrollValue < 0)
        {
            indexCurrentPostion++;
        }
        else if (scrollValue > 0)
        {
            indexCurrentPostion--;
        }

        if (_camera.localPosition != cameraPositions[IndexCurrentPostion])
        {
            _camera.localPosition = Vector3.MoveTowards(_camera.localPosition, cameraPositions[IndexCurrentPostion], scrollSpeed);
        }

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
