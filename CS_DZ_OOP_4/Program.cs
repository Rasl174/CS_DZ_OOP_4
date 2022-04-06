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

            player.Play();
        }
    }

    class Player
    {
        private List<Deck> _playerDeck = new List<Deck>();
        public int Takes { get; private set; }

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
                        isPlay = false;
                        break;
                    default:
                        Console.WriteLine("Не верный ввод!");
                        break;
                }
            }
        }

        private void ShowPlayerCards()
        {
            if(_playerDeck.Count > 0)
            {
                foreach (var item in _playerDeck)
                {
                    item.ShowCards(Takes);
                }
                _playerDeck.Clear();
                Console.WriteLine("Карты скинуты в колоду!");
            }
            else
            {
                Console.WriteLine("Нет карт на руках.");
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
                Console.Clear();
                Console.WriteLine("Колода на руках. Внимание колода не перемешана!");
                Console.ReadKey();
            }
        }

        private void TakeOneCard()
        {
            int takes = 1;

            if(_playerDeck.Count == 1 && Takes < 36)
            {
                Takes += takes;
                Console.Clear();
                Console.WriteLine("На руках " + Takes + " карт(a)");
            }
            else
            {
                Console.WriteLine("В руках нет колоды или на руках все карты!");
            }
        }

        private void Shuffle()
        {
            if (_playerDeck.Count == 1)
            {
                foreach (var deck in _playerDeck)
                {
                    deck.ShuffleDeck();
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
            TakeDeck();
        }

        public void ShowCards(int takes)
        {
            Console.Clear();

            for (int i = 0; i < takes; i++)
            {
                Console.WriteLine(_cards[i].CardFace);
            }
        }

        public void ShuffleDeck()
        {
            Random random = new Random();

            var deck = _cards;
            var shuffleDeck = deck.OrderBy(x => random.Next());

            foreach (var card in shuffleDeck)
            {
                _cards.Remove(card);
                _cards.Add(card);
            }
            Console.Clear();
            Console.WriteLine("Колода перемешана!");
            Console.ReadKey();
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