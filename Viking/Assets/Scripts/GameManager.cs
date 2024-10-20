using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
   
    public static GameManager manager;

    public string currentLevel;

    public float health;
    public float previousHealth;
    public float maxHealth;

    //Jokaista tasoa varten on muuttuja. Muuttujan nimen pit‰‰ olla sama kuin LoadLevel script olevan LeveltoLoad arvo

    public bool Level1;
    public bool Level2;
    public bool Level3;
    public bool Level4;
    public bool Level5;

    private void Awake()
    {
        //singleton
        if(manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;

        }
        else 
        {
            Destroy(gameObject); 

        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
     
            SceneManager.LoadScene("MainMenu"); 

        }
    } 

    //Save ja Load

    public void Save()
    {
        Debug.Log("Game Saved");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData data = new PlayerData();
        data.health = health; // Data-objektin Health = Game managerin health
        data.previousHealth = previousHealth;
        data.maxHealth = maxHealth;
        data.currentLevel = currentLevel;
        data.Level1 = Level1;   
        data.Level2 = Level2;   
        data.Level3 = Level3;
        bf.Serialize(file, data);
        file.Close();

    }

    public void Load()
    {
        Debug.Log("Game Loaded");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
        PlayerData data = (PlayerData)bf.Deserialize(file);

        //siirrett‰‰n ladattu info Game Manageriin

        health = data.health;
        previousHealth = data.previousHealth;
        maxHealth = data.maxHealth;
        currentLevel = data.currentLevel;
        Level1 = data.Level1;
        Level2 = data.Level2;
        Level3 = data.Level3;
        Level4 = data.Level4;
        Level5 = data.Level5;

    }

}

//Toinen luokka, mit‰ serialisoidaan

[Serializable]

class PlayerData
{
    public string currentLevel;
    public float health;
    public float previousHealth;
    public float maxHealth;
    public bool Level1;
    public bool Level2;
    public bool Level3;
    public bool Level4;
    public bool Level5;

}