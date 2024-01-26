using TMPro;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _countLevelText;

    public void ChangeLevel(int level) => _countLevelText.text = level.ToString();
}