using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Evento : MonoBehaviour
{
    public Transform pauseMenu;
    private bool somOn = true;
    [SerializeField] Image soundOff;
    [SerializeField] Image soundOn;
    public float passouFase = 0;
    public GameObject bt0;
    public Button bt1;
    public GameObject bt2;

    private void Start()
    {
        soundOn.enabled = false;
        soundOff.enabled = true;
        Time.timeScale = 1;
    
    }

    private void Update()
    {
        BtPause();
        OnOff();
        
        
    }
    //botao que puxa a primeira fase
    public void BotaoJogar()
    {
        SceneManager.LoadScene("Fase1_1");
    }
    //botao que puxa a cena para selecionar a fase
    public void BotaoFases()
    {
        SceneManager.LoadScene("DesbloqueandoFase");
    }
    //botao que puxa a cena que explica a narrativa do jogo
    public void BotaoNarrativa()
    {
        SceneManager.LoadScene("Narrativa");
    }
    //sair do jogo
    public void BotaoSair()
    {
        Application.Quit();
    }
    //botao que volta para a cena de menu
    public void BotaoVoltar()
    {
        SceneManager.LoadScene("Menu");
       // pauseMenu.gameObject.SetActive(false);

    }
    //botao que seleciona se o jogo vai estar com volume ou nao
    public void BotaoSom()
    {
        somOn = !somOn;
        if(somOn)
        {
            AudioListener.volume = 1;

        }
        else
        {
            AudioListener.volume = 0;
        }
    }
    //pausa o jogo 
    public void BtPause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.gameObject.activeSelf)
            {
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    //desativa a imagem de que esta com som para ativar que esta sem som
    public void OnOff()
    {
        if (!somOn)
        {
            soundOn.enabled = true;
            soundOff.enabled = false;
        }
        if (somOn)
        {
            soundOn.enabled = false;
            soundOff.enabled = true;
        }

    }
    //volta do pause
    public void BtResume()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    //botao para carregar a primeira fase
    public void BtFaseMangue()
    {
        SceneManager.LoadScene("fase1_1");
    }
    //botao para carregar a segunda fase
    public void BtFaseEstuario()
    {
        SceneManager.LoadScene("fase1_2");
        
    }
    //botao para carregar a terceira fase
    public void BtFaseMar()
    {
        SceneManager.LoadScene("fase1_3");
    }
    //desbloqueia as fases de acordo com o avanco nas fases do jogador
    public void AtivarBotao(int ativarBotao)
    {
        passouFase = ativarBotao;
        if(passouFase == 0)
        {
           bt0.GetComponent<Button>().enabled = true;
        }
        if(passouFase == 1)
        {
           bt1.gameObject.SetActive (true);
        }
        if(passouFase == 2)
        {
           bt2.GetComponent<Button>().enabled = true;
        }
    }
    
}
