using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class Buttons : MonoBehaviour
{
    [Header("Start Button")]
    public bool start;

    [Header("Settings Button")]
    public bool settings;
    public Image menu;

    [Header("Quit Button")]
    public bool quit;

    [Header("Close Button")]
    public bool closeMenu;

    [Header("Resume Button")]
    public bool resume;
    [HideInInspector]
    public int resumeCount = 0;

    [Header("Return to a Scene Button")]
    public bool returnMainMenu;

    [Header("Restart Button")]
    public bool restart;

    public void PressButton()
    {
        //Iniciar jogo
        if (start)
        {
            //Se estiver pausado
            if(Time.timeScale != 1)
                Time.timeScale = 1f;

            SceneManager.LoadScene("TestMap");
        }

        //Abrir e fechar menu de opções
        if (settings)
        {
            //Se o menu de opções estiver aberto, fecha-o, senão, abre-o
            if (menu.gameObject.activeSelf)
            {
                menu.gameObject.SetActive(false);
            }
            else
            {
                menu.gameObject.SetActive(true);
            }
        }

        //Sair da aplicação
        if (quit)
        {
            Application.Quit();
        }

        //Fechar menu de opções
        if (closeMenu)
        {
            menu.gameObject.SetActive(false);
        }

        //Resumir jogo
        if (resume)
        {
            resumeCount = 1;
        }

        //Voltar ao menu principal
        if (returnMainMenu)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = enabled;
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }

        //Recarregar mapa
        if(restart)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }
}
