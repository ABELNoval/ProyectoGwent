using UnityEngine;
using UnityEngine.Audio;
using Image = UnityEngine.UI.Image;

public class OptionsMenu : MonoBehaviour
{
    public GameObject menuOptions;
    public GameObject mainMenu;
    public GameObject curse;
    public GameObject sorcerer;
    public int cont;
    [SerializeField] private AudioMixer audioMixer;

    //Ajuste de pantalla( Fullscreen )
    public void FullscreenBool()
    {
        if (Screen.fullScreen == false)
        {
            Screen.fullScreen = true;
        }
        else 
        {
            Screen.fullScreen = false;
        }
    }

    //Ajuste del volumen de la musica
    public void  VolumMusic(float volum)
    {
        
        audioMixer.SetFloat("Volum(music)", volum);
    }

    //Volver al menu principal( BackButton )
    public void ChangesToMainMenu()
    {
        mainMenu.SetActive(true);
        menuOptions.SetActive(false);
    }

    //Cambiar de deck selecionado( sorcerers / curses )
    public void ChangeDeck()
    {
        cont++;
        Image curseImage = curse.GetComponent<Image>();
        Color colorCurse = curseImage.color;
        colorCurse.a = (colorCurse.a == 1f) ?  0.4f : 1f;
        curseImage.color = colorCurse;

        Image sorcererImage = sorcerer.GetComponent<Image>();
        Color colorSorcerer = sorcererImage.color;
        colorSorcerer.a = (colorSorcerer.a == 1f) ?  0.4f : 1f;
        sorcererImage.color = colorSorcerer;
    }
}
