using System.Collections.Generic;
using Jujutsu_Kaisen_Game_Proyect.Assets.BackEnd;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelCardInformation : MonoBehaviour
{
    public TextMeshProUGUI cardName;
    public Image cardImage;
    public TextMeshProUGUI cardDescription;
    public TextMeshProUGUI cardPos;
    public TextMeshProUGUI cardPower; 
    public TextMeshProUGUI effect1;
    public TextMeshProUGUI effect2;
    public TextMeshProUGUI effect3;
    public TextMeshProUGUI effect4;
    public TextMeshProUGUI effect5;

    public void CreateCardPanelInfo(string cardName, Sprite cardImage, string cardDescription, CardPos cardPos, int cardPower, TypeOfCard typeOfCard, List<string> effects)
    {
        this.cardPos.text = cardPos.ToString();
        this.cardName.text = cardName;
        this.cardImage.sprite = cardImage;
        this.cardDescription.text = cardDescription;
        this.cardPower.text = cardPower.ToString();
        this.effect1.text = effects.Count > 0 ? effects[0] : null;
        this.effect2.text = effects.Count > 1 ? effects[1] : null;
        this.effect3.text = effects.Count > 2 ? effects[2] : null;
        this.effect4.text = effects.Count > 3 ? effects[3] : null;
        this.effect5.text = effects.Count > 4 ? effects[4] : null;
    }
}

/*public class PanelComunCardInfo : PanelCardInformation
{
    public PanelComunCardInfo(string cardName, Sprite cardImage, string cardDescription, int cardPower, CardPos cardPos): base(cardName, cardImage, cardDescription, cardPos)
    {
        this.cardName.text = cardName;
        this.cardImage.sprite = cardImage;
        this.cardDescription.text = cardDescription;
        this.cardPower.text = cardPower.ToString();
        this.cardPos.text = cardPos.ToString();
    }
}

public class PanelPlatCardInfo : PanelCardInformation
{
    
    public PanelPlatCardInfo(string cardName, Sprite cardImage, string cardDescription, int cardPower, CardPos cardPos, string effect): base(cardName, cardImage, cardDescription, cardPos)
    {
        this.effect.text = effect;
        this.cardName.text = cardName;
        this.cardImage.sprite = cardImage;
        this.cardDescription.text = cardDescription;
        this.cardPower.text = cardPower.ToString();
        this.cardPos.text = cardPos.ToString();
    }
}

public class PanelGoldCardInfo : PanelCardInformation
{
    public PanelGoldCardInfo(string cardName, Sprite cardImage, string cardDescription, int cardPower, CardPos cardPos, string effect): base(cardName, cardImage, cardDescription, cardPos)
    {
        this.effect.text = effect;
        this.cardName.text = cardName;
        this.cardImage.sprite = cardImage;
        this.cardDescription.text = cardDescription;
        this.cardPower.text = cardPower.ToString();
        this.cardPos.text = cardPos.ToString();
    }
}

public class PanelSpecialCardInfo : PanelCardInformation
{

    public PanelSpecialCardInfo(string cardName, Sprite cardImage, string cardDescription, CardPos cardPos, string effect): base(cardName, cardImage, cardDescription, cardPos)
    {
        this.effect.text = effect;
        this.cardName.text = cardName;
        this.cardImage.sprite = cardImage;
        this.cardDescription.text = cardDescription;
        this.cardPos.text = cardPos.ToString();
    }
}

public class PanelBossCardInfo : PanelCardInformation
{

    public PanelBossCardInfo(string cardName, Sprite cardImage, string cardDescription, CardPos cardPos, string effect1, string effect2, string effect3, string effect4, string effect5): base(cardName, cardImage, cardDescription, cardPos)
    {
        this.effect1.text = effect1;
        this.effect2.text = effect2;
        this.effect3.text = effect3;
        this.effect4.text = effect4;
        this.effect5.text = effect5;
        this.cardName.text = cardName;
        this.cardImage.sprite = cardImage;
        this.cardDescription.text = cardDescription;
        this.cardPos.text = cardPos.ToString();
    }
}*/

