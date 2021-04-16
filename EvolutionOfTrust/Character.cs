using System.Collections.Generic;

namespace EvolutionOfTrust
{
    /// <summary>
    /// Доступные действия Character'а
    /// </summary>
    public enum Action
    {
        Coop,
        Cheat
    }

    /// <summary>
    /// Абстрактный класс персонажа/характера
    /// </summary>
    public abstract class Character
    {
        public int Id
        {
            get => id;
        }

        public int Points
        {
            get => points;
        }

        public string Name
        {
            get => this.GetType().Name;
        }

        public int id;
        public int points;
        public Dictionary<int, List<Action>> OpponentsActions = new Dictionary<int, List<Action>>();
        public abstract Action FirstAction { get; }
        public abstract Action MakeAction(int opponentId);

        public Character(int id)
        {
            this.id = id;
        }
        public Character Clone()
        {
            return (Character)this.MemberwiseClone();
        }
    }
}
