using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Text dogruSayisiText, yanlisSayisiText, puanText;


    [SerializeField]
    private GameObject birinciYildiz, ikinciYildiz, ucuncuYildiz;

    public void sonuclariYazdir(int dogruAdet, int yanlisAdet, int puan)
    {
        dogruSayisiText.text = dogruAdet + "";
        yanlisSayisiText.text = yanlisAdet + "";
        puanText.text = puan + "";

        birinciYildiz.SetActive(false);
        ikinciYildiz.SetActive(false);
        ucuncuYildiz.SetActive(false);


        if(dogruAdet == 1)
        {
            birinciYildiz.SetActive(true);
            ikinciYildiz.SetActive(false);
            ucuncuYildiz.SetActive(false);
        }
        else if( dogruAdet == 2)
        {
            birinciYildiz.SetActive(true);
            ikinciYildiz.SetActive(true);
            ucuncuYildiz.SetActive(false);
        }
        else if(dogruAdet == 3)
        {
            birinciYildiz.SetActive(true);
            ikinciYildiz.SetActive(true);
            ucuncuYildiz.SetActive(true);
        }
        else if(dogruAdet == 0)
        {
            birinciYildiz.SetActive(false);
            ikinciYildiz.SetActive(false);
            ucuncuYildiz.SetActive(false);
        }

    }
    

    
}
