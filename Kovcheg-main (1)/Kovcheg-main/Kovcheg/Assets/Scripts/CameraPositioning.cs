using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraPositioning : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform startCameraPosition;
    [SerializeField] private float scrollDepth = 3;
    [SerializeField] private float smoothScrolling = 10;
    private List<Vector3> positions = new List<Vector3>();
    private float scrollStep;
    private int indexCurrentPostion;

    private int IndexCurrentPostion
    {
        get
        {
            if (indexCurrentPostion < 0)
                indexCurrentPostion = 0;
            if (indexCurrentPostion == positions.Count)
                indexCurrentPostion = positions.Count - 1;

            return indexCurrentPostion;
        }
    }

    private void Start()
    {
        scrollStep = scrollDepth / smoothScrolling;
        indexCurrentPostion = ((int)smoothScrolling);
    }

    private void FixedUpdate()
    {
        FillListPositions();
        SetPosition();
    }

    private void FillListPositions()
    {
        Vector3 target = startCameraPosition.localPosition;
        target.y -= scrollDepth;
        target.z += scrollDepth;

        positions.Clear();

        for (int i = 0; i < smoothScrolling + 1; i++)
        {
            Vector3 newPosition = target;
            newPosition.y += scrollStep * i;
            newPosition.z -= scrollStep * i;
            positions.Add(newPosition);
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

        _camera.localPosition = Vector3.MoveTowards(_camera.localPosition, positions[IndexCurrentPostion], 0.1f);
    }
}
