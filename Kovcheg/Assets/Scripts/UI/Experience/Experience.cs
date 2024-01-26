using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    [SerializeField] private Button _buttonInfoAllExperience;
    [SerializeField] private ExpAllInfo _expAllInfo;
    [SerializeField] private ExpText _expText;
    [SerializeField] private ExpBar _expBar;
    [SerializeField] private LevelPanel _levelPanel;
    [SerializeField] private PlayerExperience _playerExperience;

    private void OnEnable()
    {
        _buttonInfoAllExperience.onClick.AddListener(OnClickButtonInfoAllExperience);
        _playerExperience.ChangedCurrentExperience += OnChangedCurrentExperience;
        _playerExperience.ChangedMaxExperience += OnChangedMaxExperience;
        _playerExperience.ChangedLevel += OnChangedLevel;
    }

    private void OnDisable()
    {
        _buttonInfoAllExperience.onClick.RemoveListener(OnClickButtonInfoAllExperience);
        _playerExperience.ChangedCurrentExperience -= OnChangedCurrentExperience;
        _playerExperience.ChangedMaxExperience -= OnChangedMaxExperience;
        _playerExperience.ChangedLevel -= OnChangedLevel;
    }

    private void OnChangedCurrentExperience(int currentExperience)
    {
        _expText.ChangeTextCurrentExperience(currentExperience);
        _expText.ChangeTextAllExpirience(currentExperience);
        _expBar.ChangeCurrentValue(currentExperience);
    }

    private void OnChangedMaxExperience(int maxExperience)
    {
        _expText.ChangeMaxExperience(maxExperience);
        _expBar.ChangeMaxValue(maxExperience);
    }

    private void OnClickButtonInfoAllExperience()
    {
        _expAllInfo.ChangeVisibilityInfo();
        _expText.ChangeTextAllExpirience(_playerExperience.AllEperience);
    }

    private void OnChangedLevel(int level) 
    {
        _levelPanel.ChangeLevel(level);
    }
}