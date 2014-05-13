using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConBeepLib
{
    public class Composer
    {
        private List<Note> notes = new List<Note>();
        private int octave = 0;
        private bool tri = false;
        private bool dot = false;
        private int speed = 0;

        public Composer(String musicText)
        {
            char[] musicTextCharactersArray = musicText.ToCharArray();
            for (int i = 0; i < musicTextCharactersArray.Length; i++)
            {
                if (musicTextCharactersArray[i] == 't')
                {
                    speed = (int)Char.GetNumericValue(musicTextCharactersArray[i + 1]) * 100 + (int)Char.GetNumericValue(musicTextCharactersArray[i + 2]) * 10 + (int)Char.GetNumericValue(musicTextCharactersArray[i + 3]);
                    i = i + 4;
                }
                if (musicTextCharactersArray[i] == '>')
                {
                    octave++;
                }
                else if (musicTextCharactersArray[i] == '<')
                {
                    octave--;
                }
                else if (musicTextCharactersArray[i] == '[')
                {
                    tri = true;
                }
                else if (musicTextCharactersArray[i] == ']')
                {
                    tri = false;
                }
                else if (musicTextCharactersArray[i] == '.')
                {
                    dot = true;
                }

                else if (Char.IsLetter(musicTextCharactersArray[i]))
                {
                    char note = musicTextCharactersArray[i];
                    int lenght = 4;
                    char sign = ' ';

                    if (musicTextCharactersArray[i + 1] == '$' && musicTextCharactersArray[i + 1] != '/')
                    {
                        sign = '$';
                        if (Char.IsNumber(musicTextCharactersArray[i + 2]) && musicTextCharactersArray[i + 1] != '/')
                        {
                            lenght = (int)Char.GetNumericValue(musicTextCharactersArray[i + 2]);
                            if (Char.IsNumber(musicTextCharactersArray[i + 3]) && musicTextCharactersArray[i + 2] != '/')
                            {
                                lenght = (lenght * 10) + (int)Char.GetNumericValue(musicTextCharactersArray[i + 3]);
                            }
                        }
                    }

                    else if (musicTextCharactersArray[i + 1] == '#' && musicTextCharactersArray[i + 1] != '/')
                    {
                        sign = '#';
                        if (Char.IsNumber(musicTextCharactersArray[i + 2]) && musicTextCharactersArray[i + 1] != '/')
                        {
                            lenght = (int)Char.GetNumericValue(musicTextCharactersArray[i + 2]);
                            if (Char.IsNumber(musicTextCharactersArray[i + 3]) && musicTextCharactersArray[i + 2] != '/')
                            {
                                lenght = (lenght * 10) + (int)Char.GetNumericValue(musicTextCharactersArray[i + 3]);
                            }
                        }
                    }

                    else if (Char.IsNumber(musicTextCharactersArray[i + 1]) && musicTextCharactersArray[i + 1] != '/')
                    {
                        lenght = (int)Char.GetNumericValue(musicTextCharactersArray[i + 1]);
                        if (Char.IsNumber(musicTextCharactersArray[i + 2]) && musicTextCharactersArray[i + 1] != '/')
                        {
                            lenght = (lenght * 10) + (int)Char.GetNumericValue(musicTextCharactersArray[i + 2]);
                        }
                    }

                    int duration = 1600 / lenght;
                    if (tri)
                    {
                        duration = (int)(duration * 0.3333);
                    }
                    if (dot)
                    {
                        duration = (int)(duration + (duration / 2));
                        dot = false;
                    }
                    double x = speed / 120.0;
                    notes.Add(new Note(FrequentionSeeker(note, octave, sign), (int)(duration*x)));
                }
            }
        }

        private int FrequentionSeeker(char note, int octave, char sign)
        {
            double n = 0;
            //set standard note value
            switch (Char.ToLower(note))
            {
                case 'a':
                    n = 0; break;
                case 'b':
                    n = 2.0; break;
                case 'c':
                    n = 3.0; break;
                case 'd':
                    n = 5.0; break;
                case 'e':
                    n = 7.0; break;
                case 'f':
                    n = 8.0; break;
                case 'g':
                    n = 10.0; break;
                case 'r':
                    return 32767;
                default:
                    throw new System.ArgumentException("Letter is not known to the Composer", "letter");
            }
            //set sign to note value
            if (sign == '$')
            {
                n--;
            }
            if (sign == '#')
            {
                n++;
            }
            //set octave to note value
            n = n + (octave * 12);
            //seek frequention
            return Convert.ToInt32(Math.Pow(2, (n / 12)) * 440);
        }

        public void playAll(){
            foreach (Note n in notes)
            {
                n.sound();
            }
        }
    }
}

            //String music = "t100<[ddd]g2>d2[cba]g2d[cba]g2d[cbc]a2<.d8d16g2>d2[cba]g2d[cba]g2d[cbc]ar<.d8d16.ee8>c8b8a8<g8[g>ab]a8<e8f#.d8d16.ee8>c8b8a8<g8>da2<";
            //music += ".d8d16.ee8>c8b8a8<g8[g>ab]a8<e8f#8r8>.d8d16.g8f16.e$8d16.c8b%16.a8<g16>d2<[ddd]g2>d2[cba]g2d[cba]g2d[cbc]a2<.d8d16g2>d2[cba]g2d[gfe$]>b$2a<g8r8<[ggg]gr/";
            //Composer comp1 = new Composer(music);
            //Task.Factory.StartNew(comp1.playAll);
            //Console.ReadKey();