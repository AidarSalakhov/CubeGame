using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
   public void SelectCharacter(int selectedCharacter)
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }
}
