using Newtonsoft.Json;
using System;

namespace CribBlazor.Client.Models
{
    internal class Player
    {
        private Player(Guid playerId, string name, int score, int seatOrder)
        {
            PlayerId = playerId;
            Name = name;
            Score = score;
            SeatOrder = seatOrder;
        }

        public Guid PlayerId { get; }

        public string Name { get; }

        public int Score { get; }

        public int SeatOrder { get; }

        public static Player Create(Guid playerId, string name, int score, int seatOrder) => new Player(playerId, name, score, seatOrder);

        public static Player CreateWithDefaultScore(Guid playerId, string name, int seatOrder) => new Player(playerId, name, 0, seatOrder);

        public static Player FromJson(string playerJson) => JsonConvert.DeserializeObject<Player>(playerJson);
    }
}
