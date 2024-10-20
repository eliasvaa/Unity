using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    
    public void LoadMap()
    {
        //Play Painettu Valikossa
        SceneManager.LoadScene("Map");
    }

    public void Save()
    {
        //ajetaan menusta savella
        GameManager.manager.Save();
    }

    public void Load()
    {
        //ajetaan menusta loadilla
        GameManager.manager.Load();
    }


}
