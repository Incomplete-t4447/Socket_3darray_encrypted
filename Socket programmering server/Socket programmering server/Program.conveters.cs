using System.Threading;

namespace Socket_programmering_server
{
    partial class Program
    {
        private class conveters
        {
            public void firstAndSecondPoint(out char[,,] firstPoint, out char[,,] secondPoint)
            {
                firstPoint = new char[4, 4, 4] //95 different char 64 4*4*4
               {
                    {
                        {'a', 'b', 'c', 'd'},
                        {'e', 'f', 'g', 'h'},
                        {'i', 'j', 'k', 'l'},
                        {'m', 'n', 'o', 'p'}
                    },
                    {
                        {'q', 'r', 's', 't'},
                        {'u', 'v', 'w', 'x'},
                        {'y', 'z', ' ', '-'},
                        {'1', '2', '3', '4'}
                    },
                    {
                        {'5', '6', '7', '8'},
                        {'9', 'A', 'B', 'C'},
                        {'D', 'E', 'F', 'G'},
                        {'H', 'I', 'J', 'K'}
                    },
                    {
                        {'L', 'M', 'N', 'O'},
                        {'P', 'Q', 'R', 'S'},
                        {'T', 'U', 'V', 'W'},
                        {'Y', 'Z', '0', '+'}
                    },

               };

                secondPoint = new char[4, 4, 4] //95 different char 64 4*4*4
                {

                    {
                        {'r', 'P', '8', '0'},
                        {'Y', 'p', 'O', 'K'},
                        {'u', 'b', '-', 'm'},
                        {'I', 't', 'W', 'D'}
                    },
                    {
                        {'h', 's', 'q', '6'},
                        {'w', 'Z', 'M', 'j'},
                        {'J', 'y', 'l', '7'},
                        {'o', 'k', '2', '9'}
                    },
                    {
                        {'z', 'L', 'T', 'i'},
                        {'E', 'Q', 'F', '1'},
                        {'5', 'n', 'c', 'e'},
                        {'3', 'g', 'U', 'd'}
                    },
                    {
                        {'4', 'R', ' ', 'v'},
                        {'+', 'a', 'G', 'H'},
                        {'A', 'V', 'x', 'f'},
                        {'S', 'C', 'N', 'B'}
                    },
                };

            }
            public string textDeConverter(string resivedConvetedText)
            {
                

                char[] outPutChars = new char[resivedConvetedText.Length + 1];

                int one;
                int two;
                int three;
                int j = 0;
                int tæller = 0;
                firstAndSecondPoint(out char[,,] firstPoint, out char[,,] secondPoint);
                for (int Counter = 0; Counter < resivedConvetedText.Length; Counter++)
                {
                    for (int i1 = 0; i1 < 4; i1++)
                    {
                        for (int i2 = 0; i2 < 4; i2++)
                        {
                            while (j < 4)
                            {
                                if (resivedConvetedText[Counter] == secondPoint[i1, i2, j])
                                {
                                    one = i1;
                                    two = i2;
                                    three = j;
                                        outPutChars[tæller] = firstPoint[i1, i2, j];
                                    tæller = tæller + 1;

                                }
                                j = j + 1;
                            }
                            j = 0;
                        }
                    }
                }



                string returnText = new string(outPutChars);
                return returnText;
            }
            public string textConverter(string resivedText)
            {


                firstAndSecondPoint(out char[,,] firstPoint, out char[,,] secondPoint);
                char[] outPutChars = new char[resivedText.Length + 1];
                int demention = 0;
                int collum = 0;
                int row = 0;
                int i3 = 0;
                int tæller = 0;
                for (int Counter = 0; Counter < resivedText.Length; Counter++)
                {
                    for (int i1 = 0; i1 < 4; i1++)
                    {
                        for (int i2 = 0; i2 < 4; i2++)
                        {
                            while (i3 < 4)
                            {
                                if (resivedText[Counter] == firstPoint[i1, i2, i3])
                                {
                                    demention = i1;
                                    collum = i2;
                                    row =
                                        outPutChars[tæller] = secondPoint[i1, i2, i3];
                                    tæller = tæller + 1;

                                }
                                i3 = i3 + 1;
                            }
                            i3 = 0;
                        }
                    }
                }



                string returnText = new string(outPutChars);
                return returnText;
            }
        }
    }
}