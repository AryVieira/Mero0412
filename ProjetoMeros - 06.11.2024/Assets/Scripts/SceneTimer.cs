using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTimer : MonoBehaviour
{
    private void Start()
    {
        // Inicia a coroutine para aguardar 3 segundos
        StartCoroutine(WaitAndLoadMenu());
    }

    private IEnumerator WaitAndLoadMenu()
    {
        // Espera 3 segundos
        yield return new WaitForSeconds(2);

        // Carrega a cena "Menu"
        SceneManager.LoadScene("Menu");
    }
}