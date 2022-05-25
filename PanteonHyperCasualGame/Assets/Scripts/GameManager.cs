using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isPlaying = false;
    [SerializeField] private GameObject[] opponents;
    GameObject[] players;
    List<GameObject> list;
    GameObject temp;
    [SerializeField] private Text txt;
    string rank;
    public GameObject startPanel;
    public GameObject rankPanel;
    public GameObject finishPanel;
    
    void Start() // find opponent/add array with player // 
    {
        opponents = GameObject.FindGameObjectsWithTag("Opponent");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        players =(GameObject[]) AddToArray(opponents,player);
        startPanel.SetActive(true);
        finishPanel.SetActive(false);
        rankPanel.SetActive(true);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying)
        {
            for (int i = 0; i < players.Length - 1; i++){
                for (int j = 0; j < players.Length - i - 1; j++)
                {
                    if (players[j].transform.position.z < players[j + 1].transform.position.z) {
                        temp = players[j];
                        players[j] = players[j + 1];
                        players[j + 1] = temp;
                    }
                }   
            }
            for (int i = 0; i < players.Length; i++)
            {
                rank += (i+1).ToString() + "-" + players[i].transform.name.ToString() + System.Environment.NewLine;
            }
            txt.text = rank;
            rank="";
        }   
    }

     public static Array AddToArray(Array a, object o)
    {
        if (a.GetType().GetElementType() == o.GetType())
        {
            Array b = Array.CreateInstance(a.GetType().GetElementType(), a.Length + 1);
            a.CopyTo(b, 1);
            b.SetValue(o, 0);

            a = b;
        }
        else
        {
            Debug.Log("Type mismatch, object not added. -- (Type) "
                + a.GetType().GetElementType() + " != (Type) " + o.GetType());
        }
        return a;
    }
    public void StartGame()
    {
        startPanel.SetActive(false);
        isPlaying = true;
        rankPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
