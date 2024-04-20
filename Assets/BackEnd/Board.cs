using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Jujutsu_Kaisen_Game_Proyect.Assets.BackEnd
{
    public enum BoardPosition
    {
        Mele,
        Range,
        Siege,
        Expansion,
        BuffMele,
        BuffRange,
        BuffSiege,
        Cementery
    }

    public enum EffectPosition
    {
        Mele,
        Range,
        Siege
    }

    public enum BoardEffectType
    {
        Buff,
        ExpansionSukuna,
        ExpansionYuta,
        ExpansionHakari,
        ExpansionMahito,
        ExpansionJogo,
    }

    public class BoardEffect
    {
        public BoardEffectType boardEffectType;
        public EffectPosition effectPosition;
        public BoardEffect(BoardEffectType boardEffectType, EffectPosition effectPosition)
        {
            this.boardEffectType = boardEffectType;
            this.effectPosition = effectPosition;
        }
    }

    public class Board
    {
        public List<BoardEffect> effects = new List<BoardEffect>();
        //Zonas del tablero.
        public List<Card> meleCards = new List<Card>();
        public List<Card> siegeCards = new List<Card>();
        public List<Card> rangeCards = new List<Card>();
        public List<Card> buffMeleCards = new List<Card>();
        public List<Card> buffRangeCards = new List<Card>();
        public List<Card> buffSiegeCards = new List<Card>();
        public List<Card> expansionCards = new List<Card>();
        public List<Card> cementeryCards = new List<Card>();

        public void  AddCementeryCard(Card card)
        {
            cementeryCards.Add(card);
        }
        
        public void AddMeleCard(Card card)
        {
            List<BoardEffect> boardEffects = effects.FindAll(e => e.effectPosition == EffectPosition.Mele);
            ApplyEffectOnCard(boardEffects, card);
            meleCards.Add(card);
        }

        public void AddRangeCard(Card card)
        {
            List<BoardEffect> boardEffects = effects.FindAll(e => e.effectPosition == EffectPosition.Range);
            ApplyEffectOnCard(boardEffects, card);
            rangeCards.Add(card);
        }

        public void AddSiegeCard(Card card)
        {
            List<BoardEffect> boardEffects = effects.FindAll(e => e.effectPosition == EffectPosition.Siege);
            ApplyEffectOnCard(boardEffects, card);
            siegeCards.Add(card);
        }

        public void AddExpansionCard(Card card)
        {
            expansionCards.Add(card);
        }

        public void AddBuffMeleCard(Card card)
        {
            buffMeleCards.Add(card);
        }

        public void AddBuffRangeCard(Card card)
        {
            buffRangeCards.Add(card);
        }

        public void AddBuffSiegeCard(Card card)
        {
            buffSiegeCards.Add(card);
        }

        public int GetBoardPoints()
        {
            return GetMelePoints() + GetRangePoints() + GetSiegePoints();
        }

        private int GetMelePoints()
        {
            int point = 0;
            for (int i = 0; i < meleCards.Count; i++) 
            {
                point += meleCards[i].currentPower;
            }
            return point;
        }

        private int GetRangePoints()
        {
            int point = 0;
            for (int i = 0; i < rangeCards.Count; i++) 
            {
                point += rangeCards[i].currentPower;
            }
            return point;
        }

        private int GetSiegePoints()
        {
            int point = 0;
            for (int i = 0; i < siegeCards.Count; i++)
            {
                point += siegeCards[i].currentPower;
            }
            return point;
        }
    
        public void RemoveCards()
        {
            int i = 0;
            while (i < meleCards.Count)
            {
                AddCementeryCard(meleCards[i]);
                meleCards.Remove(meleCards[i]);
            }

            while (i < rangeCards.Count)
            {
                AddCementeryCard(rangeCards[i]);
                rangeCards.Remove(rangeCards[i]);
            }

            while (i < siegeCards.Count)
            {
                AddCementeryCard(siegeCards[i]);
                siegeCards.Remove(siegeCards[i]);
            }

            while( i < buffMeleCards.Count )
            {
                AddCementeryCard(buffMeleCards[i]);
                buffMeleCards.Remove(buffMeleCards[i]);
            }

            while( i < buffRangeCards.Count )
            {
                AddCementeryCard(buffRangeCards[i]);
                buffRangeCards.Remove(buffRangeCards[i]);
            }

            while( i < buffSiegeCards.Count )
            {
                AddCementeryCard(buffSiegeCards[i]);
                buffSiegeCards.Remove(buffSiegeCards[i]);
            }

            while (i < expansionCards.Count)
            {
                AddCementeryCard(expansionCards[i]);
                expansionCards.Remove(expansionCards[i]);
            }
        }
    
        public int GetCardCount(BoardPosition cardPos)
        {
            if (cardPos == BoardPosition.Mele)
            {
                Debug.Log("Mele count: " + meleCards.Count);
                return meleCards.Count;
            }
            if (cardPos == BoardPosition.Range)
            {
                return rangeCards.Count;
            }
            if (cardPos == BoardPosition.Siege)
            {
                return siegeCards.Count;
            }
            return 0;
        }
    
        public void ChangesCards(Guid cardId)
        {
            int i = 0;
            while (i < meleCards.Count && cardId != meleCards[i].id)
            {
                i++;
            }
            if (i < meleCards.Count)
            {
                meleCards[i] = null;
                return;
            }

            while (i < rangeCards.Count && cardId != rangeCards[i].id)
            {
                i++;
            }
            if (i < rangeCards.Count)
            {
                rangeCards[i] = null;
                return;
            }

            while (i < siegeCards.Count && cardId != siegeCards[i].id)
            {
                i++;
            }
            if (i < siegeCards.Count)
            {
                siegeCards[i] = null;
                return;
            }
        }
    
        public Card GetCard(Guid cardId)
        {
            Card foundCard = meleCards.Find(c => c.id == cardId);
            if (foundCard != null)
            {
                return foundCard;
            }
            foundCard = rangeCards.Find(c => c.id == cardId);
            if (foundCard != null)
            {
                return foundCard;
            }
            foundCard = siegeCards.Find(c => c.id == cardId);
            if (foundCard != null)
            {
                return foundCard;
            }
            return null;
        }
    
        public void IncreasePowerBy(EffectPosition effectPosition, int cant)
        {
            if (effectPosition == EffectPosition.Mele)
            {
                foreach (Card card in meleCards)
                {
                    card.currentPower += cant;
                }
                return;
            }

            if (effectPosition == EffectPosition.Range)
            {
                foreach (Card card in rangeCards)
                {
                    card.currentPower += cant;
                }
                return;
            }

            if (effectPosition == EffectPosition.Siege)
            {
                foreach (Card card in siegeCards)
                {
                    card.currentPower += cant;
                }
                return;
            }
        }
    
        public Card GetWeakCard()
        {
            List<Card> cards = GetAllCards();
            if (cards.Count == 0)
            {
                return null;
            }
            int minIndex = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                if(cards[i].currentPower < cards[minIndex].currentPower)
                {
                    minIndex = i;
                }
            }
            
            return cards[minIndex];
        }

        public int GetCountSameCard(Card card)
        {
            List<Card> cards = GetAllCards();
            return cards.FindAll(c => c.nameBase == card.nameBase).Count;
        }

        private List<Card> GetAllCards()
        {
            return meleCards.Concat(rangeCards).Concat(siegeCards).ToList();
        }

        public Card GetMaxCard()
        {
            List<Card> cards = GetAllCards();
            if (cards.Count == 0)
            {
                return null;
            }
            int maxIndex = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                if(cards[i].currentPower > cards[maxIndex].currentPower)
                {
                    maxIndex = i;
                }
            }
            return cards[maxIndex];
        }
        
        public void RemoveCard(Guid cardId)
        {
            RemoveMeleCard(cardId);
            RemoveRangeCard(cardId);
            RemoveSiegeCard(cardId);
        }
        
        private void RemoveMeleCard(Guid cardId)
        {
            Card card = meleCards.Find(x => x.id == cardId);
            if (card != null)
            {
                meleCards.Remove(card);
                AddCementeryCard(card);
            }
        }

        private void RemoveRangeCard(Guid cardId)
        {
            Card card = rangeCards.Find(x => x.id == cardId);
            if (card != null)
            {
                rangeCards.Remove(card);
                AddCementeryCard(card);
            }
        }

        private void RemoveSiegeCard(Guid cardId)
        {
            Card card = siegeCards.Find(x => x.id == cardId);
            if (card != null)
            {
                siegeCards.Remove(card);
                AddCementeryCard(card);
            }
        }

        private void ApplyEffectOnCard(List<BoardEffect> boardEffects, Card card)
        {
            foreach (BoardEffect boardEffect in boardEffects)
            {
                switch (boardEffect.boardEffectType)
                {
                    case BoardEffectType.Buff :
                    {
                        card.currentPower += 2;
                        break;
                    }
                    case BoardEffectType.ExpansionYuta:
                    case BoardEffectType.ExpansionSukuna:
                    {
                        card.currentPower -= 2;
                        break;
                    }
                    case BoardEffectType.ExpansionMahito:
                    case BoardEffectType.ExpansionJogo:
                    case BoardEffectType.ExpansionHakari:
                    {
                        card.currentPower -= 1;
                        break;
                    }
                }
            }
        }
    }
}