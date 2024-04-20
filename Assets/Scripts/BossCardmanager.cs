using Jujutsu_Kaisen_Game_Proyect.Assets.BackEnd;
using UnityEngine;

public class BossCardmanager : MonoBehaviour
{
    private App app;
    public Card card;
    
    public void SetupCard(Card card)
    {
        this.card = card;
    }

    private void Start()
    {
        app = FindFirstObjectByType<App>();
    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseEnter()
    {
        app.panelInfo.SetActive(false);
        app.bossCardPanelInfo.SetActive(true);
        app.GenerateBossCardPanelInfo(card);
    }

    private void OnMouseExit()
    {
        app.bossCardPanelInfo.SetActive(false);
    }
}
