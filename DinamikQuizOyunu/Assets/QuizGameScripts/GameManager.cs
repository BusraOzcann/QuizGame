using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    public Soru[] sorular;
    private static List<Soru> cevaplanmamisSorular;

    private Soru gecerliSoru;

    [SerializeField]
    private Text soruText;

    [SerializeField]
    private Text dogruCevapText, yanlisCevapText;

    [SerializeField]
    private GameObject dogruButton, yanlisButton;

    int dogruAdet, yanlisAdet;

    int toplamPuan;

    [SerializeField]
    private GameObject sonucPaneli;

    SonucManager sonucManager;


    void Start()
    {
        if(cevaplanmamisSorular == null || cevaplanmamisSorular.Count == 0)
        {
            cevaplanmamisSorular = sorular.ToList<Soru>();
        }

        dogruAdet = 0;
        yanlisAdet = 0;
        toplamPuan = 0;

        RastgeleSoruSec();

    }

    void RastgeleSoruSec()
    {
        yanlisButton.GetComponent<RectTransform>().DOLocalMoveX(321, 0.2f);
        dogruButton.GetComponent<RectTransform>().DOLocalMoveX(-321, 0.2f);


        int randomSoruIndex = Random.Range(0, cevaplanmamisSorular.Count);
        gecerliSoru = cevaplanmamisSorular[randomSoruIndex];
        soruText.text = gecerliSoru.soru;

        if (gecerliSoru.dogruMu)
        {
            dogruCevapText.text = "DOGRU CEVAPLADINIZ.";
            yanlisCevapText.text = "YANLIS CEVAPLADINIZ!";
        }
        else
        {
            dogruCevapText.text = "YANLIS CEVAPLADINIZ.";
            yanlisCevapText.text = "DOGRU CEVAPLADINIZ!";
        }

    }


    IEnumerator SorularArasiBekleRoutine()
    {
        cevaplanmamisSorular.Remove(gecerliSoru);

        yield return new WaitForSeconds(1f);
        
        if(cevaplanmamisSorular.Count <= 0)
        {
            Debug.Log("DOGRU ADET" + dogruAdet);
            Debug.Log("yanlıs ADET" + yanlisAdet);
            sonucPaneli.SetActive(true);
            sonucManager = Object.FindObjectOfType<SonucManager>();
            sonucManager.sonuclariYazdir(dogruAdet, yanlisAdet, toplamPuan);
        }
        else
        {
            RastgeleSoruSec();
        }
    }


    public void dogruButonaBasildi()
    {
        if(gecerliSoru.dogruMu)
        {
            dogruAdet++;
            toplamPuan += 100;
        }
        else
        {
            yanlisAdet++;
        }

        yanlisButton.GetComponent<RectTransform>().DOLocalMoveX(1000, .3f);
        StartCoroutine(SorularArasiBekleRoutine());
    }

    public void yanlisButonaBasildi()
    {
        if (!gecerliSoru.dogruMu)
        {
            dogruAdet++;
            toplamPuan += 100;
        }
        else
        {
            yanlisAdet++;
        }

        dogruButton.GetComponent<RectTransform>().DOLocalMoveX(-1000, .3f);
        StartCoroutine(SorularArasiBekleRoutine());
    }

}
