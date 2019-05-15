using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiseasePicker : MonoBehaviour
{
   public string[] levelNames;

    public void DiseaseScene()
    {
        SceneManager.LoadScene(levelNames[Random.Range(0,3)]);
    }




}
