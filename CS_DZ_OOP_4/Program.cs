using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DZ_OOP_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Deck> deck = new List<Deck>();
            Player player = new Player(deck);

            Console.WriteLine("Это игра в очко. Нужно набрать 21 балл.");

            player.Play();
        }
    }

    class Player
    {
        private List<Deck> _playerDeck = new List<Deck>();
        private Queue<Deck> _cardsInHend = new Queue<Deck>();

        public Player(List<Deck> playerDeck)
        {
            _playerDeck = playerDeck;
        }

        public void Play()
        {
            bool isPlay = true;

            while (isPlay)
            {
                Console.WriteLine("Для того что бы взять колоду введите 1");
                Console.WriteLine("Для того что бы перемешать колоду введите 2");
                Console.WriteLine("Для того что бы вытянуть карту введите 3");
                Console.WriteLine("Для того что бы вскрыться введите 4");
                Console.WriteLine("Для выхода введите 5 или exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        TakeDeck();
                        break;
                    case "2":
                        Shuffle();
                        break;
                    case "3":
                        TakeOneCard();
                        break;
                    case "4":
                        ShowPlayerCards();
                        break;
                    case "5":
                    case "exit":
                        break;
                    default:
                        Console.WriteLine("Не верный ввод!");
                        break;
                }
            }
        }

        private void ShowPlayerCards()
        {
            foreach (var item in _playerDeck)
            {
                _cardsInHend.Enqueue(item);
                item.ShowCards();
            }
        }

        private void TakeDeck()
        {
            if (_playerDeck.Count > 0)
            {
                Console.WriteLine("В руках уже есть колода.");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                _playerDeck.Add(new Deck());
            }
        }

        private void TakeOneCard()
        {

        }

        private void Shuffle()
        {
            if (_playerDeck.Count == 1)
            {
                foreach (var deck in _playerDeck)
                {
                    deck.ShuffleDeck(_playerDeck);
                }
            }
            else
            {
                Console.WriteLine("В руках нет колоды!");
            }
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>();

        public Deck()
        {
            TryTakeDeck();
        }

        public void TryTakeDeck()
        {
            if (_cards.Count > 0)
            {
                Console.WriteLine("    wefwfwefwe    ");
            }
            else
            {
                TakeDeck();
            }
        }

        public void ShowCards()
        {
            foreach (var item in _cards)
            {
                Console.WriteLine(item.CardFace);
            }
        }

        public void ShuffleDeck<Deck>(List<Deck> cards)
        {
            Console.WriteLine("Колода перемешана!");

            Random random = new Random();

            for (int i = _cards.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                Deck temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
        }

        public void TakeDeck()
        {
            _cards.Add(new Card("6 - буби")); _cards.Add(new Card("6 - пики")); _cards.Add(new Card("6 - черви")); _cards.Add(new Card("6 - крести"));
            _cards.Add(new Card("7 - буби")); _cards.Add(new Card("7 - пики")); _cards.Add(new Card("7 - черви")); _cards.Add(new Card("7 - крести"));
            _cards.Add(new Card("8 - буби")); _cards.Add(new Card("6 - пики")); _cards.Add(new Card("8 - черви")); _cards.Add(new Card("8 - крести"));
            _cards.Add(new Card("9 - буби")); _cards.Add(new Card("6 - пики")); _cards.Add(new Card("9 - черви")); _cards.Add(new Card("9 - крести"));
            _cards.Add(new Card("10 - буби")); _cards.Add(new Card("10 - пики")); _cards.Add(new Card("10 - черви")); _cards.Add(new Card("10 - крести"));
            _cards.Add(new Card("Валет - буби")); _cards.Add(new Card("Валет - пики")); _cards.Add(new Card("Валет - черви")); _cards.Add(new Card("Валет - крести"));
            _cards.Add(new Card("Дама - буби")); _cards.Add(new Card("Дама - пики")); _cards.Add(new Card("Дама - черви")); _cards.Add(new Card("Дама - крести"));
            _cards.Add(new Card("Король - буби")); _cards.Add(new Card("Король - пики")); _cards.Add(new Card("Король - черви")); _cards.Add(new Card("Король - крести"));
            _cards.Add(new Card("Туз - буби")); _cards.Add(new Card("Туз - пики")); _cards.Add(new Card("Туз - черви")); _cards.Add(new Card("Туз - крести"));
        }
    }

    class Card
    {
        public string CardFace { get; private set; }

        public Card(string cardFace)
        {
            CardFace = cardFace;
        }
    }
}