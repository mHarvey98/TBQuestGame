using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

namespace TBQuestGame.PresentationLayer
{
    public class GameSessionViewModel
    {
        // Fields
        private Player _player;
        private List<string> _messages;


        // Properties
        public List<string> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }


        //Constructors
        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(        // Constructor for new GameSessionView
            Player player,
            List<string> initialMessages)
        {
            _player = player;
            _messages = initialMessages;
        }

        //Methods

        //
        // return the list of strings converted to a single string 
        // with new lines between each message
        //
        public string MessageDisplay
        {
            get { return string.Join("\n\n", _messages); }
        }
    }
}
