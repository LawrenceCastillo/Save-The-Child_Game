using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiseasePicker : MonoBehaviour
{
   public string[] levelNames;
   string contracted_disease;
   public Text diseaseText;

   public void Start()
   {
       contracted_disease = levelNames[Random.Range(0,3)];
       Debug.Log("You Got" + contracted_disease);
       diseaseText.text = contracted_disease;
   }


    public void DiseaseScene()
    {
        SceneManager.LoadScene(contracted_disease);
    }




}
