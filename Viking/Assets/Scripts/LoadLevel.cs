using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    
    public string levelToLoad;
    
    public bool cleared;



// Start is called before the first frame update
    void Start()
    {
        // katsotaan aina map scene avattaessa, ett‰ onko gamemanagerissa merkaatu, ett‰ kyseinen taso l‰p‰isty
        //Jos on, ajetaan cleared flunkio. eli n‰ytt‰‰ stage clear ja poistaa collider

        if(GameManager.manager.GetType().GetField(levelToLoad).GetValue(GameManager.manager).ToString() == "True")
        {
            Cleared(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cleared(bool isClear)
    {
        if(isClear == true)
        {
            cleared = true;
            // Asetetaan GameManagerissa oikea boolean arvo trueksi
            GameManager.manager.GetType().GetField(levelToLoad).SetValue(GameManager.manager, true);
            //Laitetaan Stage Clear kyltti n‰kyviin.
            transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            //Koska taso l‰p‰isty, poistetaan objektilta circle collider
           GetComponent<CircleCollider2D>().enabled = false;
        }


    }
}
