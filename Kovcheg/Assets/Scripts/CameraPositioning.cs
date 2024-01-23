using System.Collections.Generic;
using UnityEngine;

public class CameraPositioning : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform cameraParent;
    [SerializeField] private Transform player;
    [SerializeField] private float scrollDepth = 3;
    [SerializeField] private float smoothScrolling = 10;
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
        indexCurrentPostion = ((int)smoothScrolling);
        playerPositionLastFrame = player.position;
        FillListPositions();
    }

    private void FixedUpdate()
    {
        SetPosition();
    }

    private void FillListPositions()
    {
        Vector3 endCameraPosition = _camera.localPosition;
        endCameraPosition.y -= scrollDepth;
        endCameraPosition.z += scrollDepth;

        float scrollStep = scrollDepth / smoothScrolling;

        for (int i = 0; i < smoothScrolling + 1; i++)
        {
            Vector3 newPosition = endCameraPosition;
            newPosition.y += scrollStep * i;
            newPosition.z -= scrollStep * i;
            cameraPositions.Add(newPosition);
        }
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
            _camera.localPosition = Vector3.MoveTowards(_camera.localPosition, cameraPositions[IndexCurrentPostion], 0.1f);
        }

        if (playerPositionLastFrame != player.position)
        {
            Vector3 direction = player.position - playerPositionLastFrame;
            direction.y = 0;

            cameraParent.position += direction;
        }

        playerPositionLastFrame = player.position;
    }
}
