using System;

namespace Game
{
    public class Game
    {

        const int _maxRollNum = 21;
        int[] _rollScore = new int[_maxRollNum]; // the main structure to stock all rolls pins number
        int _currentScorePos = 0;
        Random rnd = new Random();

        public void Roll(int pins)
        {
            _rollScore[_currentScorePos] = pins;
            if (_currentScorePos % 2 == 0 && pins == 10)
                _currentScorePos += 2;
            else
                _currentScorePos++;
        }

        public int Score()
        {
            int score = 0;
            for (int pos = 0; pos < _maxRollNum - 3; pos++)
            {
                int rollScore = _rollScore[pos];
                score += rollScore; 
                int bonus = 0;

                // bonus calculate
                if (pos % 2 == 0) // first try situation
                {
                    if (rollScore == 10)
                    {
                        bonus = _rollScore[pos + 2] + _rollScore[pos + 3]; // first try with 10 pins, get next two rolls's pins as bonus
                    }
                }
                else // second try situation
                {
                    if(_rollScore[pos - 1] != 10 && rollScore + _rollScore[pos -1] == 10)
                    {
                        bonus = _rollScore[pos + 1]; // first and second try with 10 pins in total, only next one roll's pins as bonus 
                    }
                }
                score += bonus;
                //Console.WriteLine($"{pos+1} : {rollScore}; bonus {bonus}; score :{score}"); //only for debug
            }
            score += _rollScore[_maxRollNum - 1] + _rollScore[_maxRollNum - 2] + _rollScore[_maxRollNum - 3];
            return score;
        }


        public void Play()
        {
            int frame = 1;
            while (frame <= 10)
            {
                int first = rnd.Next(0, 11);
                Roll(first);
                int second = 0;
                if (first != 10)
                {
                    second = rnd.Next(0, (11 - first));
                    Roll(second);
                }
                // manage the last frame situation
                if (frame == 10)
                {
                    if (first == 10)
                    {
                        int suppSecond = rnd.Next(0, (11 - first));
                        Roll(suppSecond);
                        int third = rnd.Next(0, 11 - suppSecond);
                        Roll(third);
                    }

                    else if ((first + second) == 10)
                    {
                        int third = rnd.Next(0, 11);
                        Roll(third);
                    }
                }
                frame++;
            }
        }

        public string RollScoreToString()
        {
            return string.Join(" ", _rollScore);
        }
    }

}
