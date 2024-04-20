using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Jujutsu_Kaisen_Game_Proyect.Assets.BackEnd
{
    public enum CardPos
    {
        Mele,
        Range,
        Siege,
        MeleAndSiege,
        MeleAndRange,
        RangeAndSiege,
        MeleAndRangeAndSiege,
        Buff,
        Expansion,
        Lure,
        Clearance,
        BossPosition

    }

    [System.Serializable]
    abstract public class Card
    {
        public Guid id;
        public TypeOfCard typeOfCard;
        public string nameBase;
        public string descriptionBase;
        public Sprite artworkBase;
        public CardPos cardPosBase;
        public int powerBase;
        public int currentPower;

        public Card(string name, string description, Sprite artwork, CardPos cardPos, TypeOfCard tipo, int powerBase = 0)
        {
            id = Guid.NewGuid();
            typeOfCard = tipo;
            nameBase = name;
            descriptionBase = description;
            artworkBase = artwork;
            cardPosBase = cardPos;
            this.powerBase = powerBase;
            currentPower = powerBase;
        }

        public bool IsMele()
        {  
            return (cardPosBase == CardPos.Mele) || (cardPosBase == CardPos.MeleAndRange) || (cardPosBase == CardPos.MeleAndSiege) || (cardPosBase == CardPos.MeleAndRangeAndSiege);
        }

        public bool IsRange()
        {  
            return (cardPosBase == CardPos.Range) || (cardPosBase == CardPos.MeleAndRange) || (cardPosBase == CardPos.RangeAndSiege) || (cardPosBase == CardPos.MeleAndRangeAndSiege);
        }

        public bool IsSiege()
        {  
            return (cardPosBase == CardPos.Siege) || (cardPosBase == CardPos.MeleAndSiege) || (cardPosBase == CardPos.RangeAndSiege) || (cardPosBase == CardPos.MeleAndRangeAndSiege);
        }
        
        public bool IsExpansion()
        {  
            return (cardPosBase == CardPos.Expansion) || (cardPosBase == CardPos.Clearance) || (cardPosBase == CardPos.Lure);
        }

        public bool IsBuff()
        {  
            return (cardPosBase == CardPos.Buff); 
        }
        abstract public List<string> GetEffects();

        abstract public List<TypeOfEffects> GetTypeOfEffects();
    }

    public class ComunCard : Card
    {
        public string claseBase;
        public ComunCard(string name, string description, Sprite artwork, CardPos cardPos, TypeOfCard type, string clase, int power): base (name, description, artwork, cardPos, type, power)
        {
            claseBase = clase;
            powerBase = power;
        }

        public override List<string> GetEffects()
        {
            return new List<string>();
        }
        public override List<TypeOfEffects> GetTypeOfEffects()
        {
            return new List<TypeOfEffects>();
        }
    }

    public class PlatCard : Card
    {
        public TypeOfEffects typeOfEffects;
        public string claseBase;
        public string effectBase;
        public PlatCard(string name, string description, Sprite artwork, CardPos cardPos, TypeOfCard type, string clase, string effect, int power, TypeOfEffects typeOfEffects): base (name, description, artwork, cardPos, type, power)
        {
            this.typeOfEffects = typeOfEffects;
            claseBase = clase;
            effectBase = effect;
        }

        public override List<string> GetEffects()
        {
            return  new List<string>(){effectBase};
        }
        public override List<TypeOfEffects> GetTypeOfEffects()
        {
            return new List<TypeOfEffects>(){typeOfEffects};
        }
    }

    public class GoldCard : Card
    {
        public TypeOfEffects typeOfEffects;
        public string claseBase;
        public string effectBase;
        public GoldCard(string name, string description, Sprite artwork, CardPos cardPos, TypeOfCard type,  string clase, string effect, int power, TypeOfEffects typeOfEffects): base (name, description, artwork, cardPos, type, power)
        {
            this.typeOfEffects = typeOfEffects;
            claseBase = clase;
            effectBase = effect;
        }

        public override List<string> GetEffects()
        {
            return  new List<string>(){effectBase};
        }

        public override List<TypeOfEffects> GetTypeOfEffects()
        {
            return new List<TypeOfEffects>(){typeOfEffects};
        }
    }

    public class BossCard : Card
    {
        public TypeOfEffects typeOfEffects1;
        public TypeOfEffects typeOfEffects2;
        public TypeOfEffects typeOfEffects3;
        public string effect1Base;
        public string effect2Base;
        public string effect3Base;
        public BossCard(string name, string description, Sprite artwork, CardPos cardPos, TypeOfCard type, string effect1, string effect2, string effect3, TypeOfEffects typeOfEffects1, TypeOfEffects typeOfEffects2, TypeOfEffects typeOfEffects3): base (name, description, artwork, cardPos, type)
        {
            this.typeOfEffects1 = typeOfEffects1;
            this.typeOfEffects2 = typeOfEffects2;
            this.typeOfEffects3 = typeOfEffects3;
            effect1Base = effect1;
            effect2Base = effect2;
            effect3Base = effect3;
        }

        public override List<string> GetEffects()
        {
            return  new List<string>(){effect1Base, effect2Base, effect3Base};
        }

        public override List<TypeOfEffects> GetTypeOfEffects()
        {
            return new List<TypeOfEffects>(){typeOfEffects1, typeOfEffects2, typeOfEffects3};
        }
    }

    public class  SpecialCard : Card
    {
        public TypeOfEffects typeOfEffects;
        public string effectBase;
        public SpecialCard(string name, string description, Sprite artwork,CardPos cardPos, TypeOfCard type, string effect, TypeOfEffects typeOfEffects): base (name, description, artwork, cardPos, type)
        {
            this.typeOfEffects = typeOfEffects;
            effectBase = effect;
        }

        public override List<string> GetEffects()
        {
            return  new List<string>(){effectBase};
        }

        public override List<TypeOfEffects> GetTypeOfEffects()
        {
            return new List<TypeOfEffects>(){typeOfEffects};
        }
    }
}