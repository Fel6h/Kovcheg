using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private PlayerExperience _playerExperience;

    private void Start()
    {
        _playerExperience.SetExperience();
    }
}
