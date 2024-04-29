using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : GameManager
{
    public void Update()
    {
        if(TitleScreenStateObject == true)
        {
            if (Input.anyKey == true)
            {

                ActivateMainMenu();
            }
        }

    }
 
}
