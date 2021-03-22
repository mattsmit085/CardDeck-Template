using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardDeck
{
    public partial class Form1 : Form
    {
        //standard deck of cards
        List<string> Deck = new List<string>();
        List<string> NewDeck = new List<string>();
        List<string> Dealer = new List<string>();
        List<string> Player = new List<string>();

        public Form1()
        {
            InitializeComponent();

            //fill deck with standard 52 cards
            //H - Hearts, D - Diamonds, C - Clubs, S - Spades
        }

        private void shuffleButton_Click(object sender, EventArgs e)
        {
            RedrawDeck();
            NewDeck.Clear();

            Dealer.Clear();
            Player.Clear();

            Random RandGen = new Random();

            //while (Deck.Count > 0)
            {
                int card = (RandGen.Next(0, Deck.Count));
                NewDeck.Add(Deck[card]);
                Deck.RemoveAt(card);
            }

            //Deck = NewDeck;
        }

        private void dealButton_Click(object sender, EventArgs e)
        {

            //deal 5 cards each to dealer and player and display them
            for (int i = 0; i < 5; i++)
            {

                Player.Add(Deck[0]);
                playerCardsLabel.Text += $"{Player[i] }";
                Deck.RemoveAt(0);

                Dealer.Add(Deck[0]);
                dealerCardsLabel.Text += $"{Dealer[i] }";
                Deck.Remove(Deck[0]);
            }
        }

        private void collectButton_Click(object sender, EventArgs e)
        {
            //put player and dealer cards back into the deck
            for (int i = 0; i < 5; i++)
            {
                Deck.Add(Player[i]);
                Deck.Add(Dealer[i]);

            }
            dealerCardsLabel.Text += "";
            playerCardsLabel.Text += "";
            Player.Clear();
            Dealer.Clear();

        }

        private void RedrawDeck()
        {
            Deck.AddRange(new string[] { "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "10H", "JH", "QH", "KH", "AH" });
            Deck.AddRange(new string[] { "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "10D", "JD", "QD", "KD", "AD" });
            Deck.AddRange(new string[] { "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "10C", "JC", "QC", "KC", "AC" });
            Deck.AddRange(new string[] { "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "10S", "JS", "QS", "KS", "AS" });
        }
    }
}
