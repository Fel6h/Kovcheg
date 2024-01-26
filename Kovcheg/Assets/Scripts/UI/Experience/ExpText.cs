using TMPro;
using UnityEngine;

public class ExpText : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentExperienceText;
    [SerializeField] private TMP_Text _maxExperienceText;
    [SerializeField] private TMP_Text _allExperienceText;

    public void ChangeTextCurrentExperience(int currentExpirience)
    {
        _currentExperienceText.text = currentExpirience.ToString();
    }

    public void ChangeTextAllExpirience(int allExpirience)
    {
        _allExperienceText.text = allExpirience.ToString();
    }

    public void ChangeMaxExperience(int maxExperience)
    {
        _maxExperienceText.text = maxExperience.ToString();
    }
}