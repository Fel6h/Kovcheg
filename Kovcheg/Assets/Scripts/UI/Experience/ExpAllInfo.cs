using UnityEngine;

public class ExpAllInfo : MonoBehaviour
{
    [SerializeField] private GameObject _allExpImage;

    public void ChangeVisibilityInfo()
    {
        if(_allExpImage.activeSelf)
            _allExpImage.SetActive(false);
        else
            _allExpImage.SetActive(true);
    }
}