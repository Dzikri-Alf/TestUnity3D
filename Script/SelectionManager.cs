using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManajer : MonoBehaviour
{

    // private float lastJumpPress = -1f;
    public int key1 = 2;
    public GameObject interaction_info;
    public GameObject subject_info;
    public GameObject shift_info;
    public GameObject affine_info;
    public GameObject subtitute_info;
    public GameObject hill_info;
    public GameObject hillD_info;
    public GameObject VA_key_info;
    public GameObject VA_e_info;
    public GameObject VA_d_info;

    public GameObject one_info;
    public GameObject two_info;
    public GameObject three_info;
    public GameObject four_info;
    public GameObject five_info;
    public GameObject six_info;
    public GameObject seven_info;
    public GameObject eight_info;
    public GameObject nine_info;

    private int i, one = 0, two = 0, three = 0, four = 0, five = 0, six = 0, seven = 0, eight = 0, nine = 0;
    private char[] alphabet = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
    private char[] subtitute = {'X','N','Y','A','H','P','O','G','Z','Q','W','B','T','S','F','L','R','C','V','M','U','E','K','J','D','I'};
    // private char[] subtitute = {'Z','Y','X','W','V','U','T','S','R','Q','P','O','N','M','L','K','J','I','H','G','F','E','D','C','B','A'};

    Text interaction_text;
    Text subject_text;
    Text shift_text;
    Text affine_text;
    Text subtitute_text;
    Text hill_text;
    Text hillD_text;
    Text VA_key_text;
    Text VA_e_text;
    Text VA_d_text;

    Text one_text;
    Text two_text;
    Text three_text;
    Text four_text;
    Text five_text;
    Text six_text;
    Text seven_text;
    Text eight_text;
    Text nine_text;
    // Start is called before the first frame update
    private void Start()
    {
        interaction_text = interaction_info.GetComponent<Text>();
        subject_text = subject_info.GetComponent<Text>();
        shift_text = shift_info.GetComponent<Text>();
        affine_text = affine_info.GetComponent<Text>();
        subtitute_text = subtitute_info.GetComponent<Text>();
        hill_text = hill_info.GetComponent<Text>();
        hillD_text = hillD_info.GetComponent<Text>();
        VA_key_text = VA_key_info.GetComponent<Text>();
        VA_e_text = VA_e_info.GetComponent<Text>();
        VA_d_text = VA_d_info.GetComponent<Text>();

        one_text = one_info.GetComponent<Text>();
        two_text = two_info.GetComponent<Text>();
        three_text = three_info.GetComponent<Text>();
        four_text = four_info.GetComponent<Text>();
        five_text = five_info.GetComponent<Text>();
        six_text = six_info.GetComponent<Text>();
        seven_text = seven_info.GetComponent<Text>();
        eight_text = eight_info.GetComponent<Text>();
        nine_text = nine_info.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit hit;
        // if (Physics.Raycast(ray, out hit))
        // {
        //     var selectionTransform = hit.transform;
        //     if (selectionTransform.GetComponent<InteractableObject>())
        //     {
        //         interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
        //         interaction_info.SetActive(true);
        //         if (Input.GetKeyDown(KeyCode.Q))
        //         {
        //             subject_text.text = subject_text.text + selectionTransform.GetComponent<InteractableObject>().GetItemName();
        //         }
        //     }
        //     else
        //     {
        //         interaction_info.SetActive(false);
        //     }
        // }
        // else
        // {
        //     interaction_info.SetActive(false);
        // }
    }

    public void AddLetter(string value)
    {
        subject_text.text = subject_text.text + value;
    }

    public void AddLetterKeyVA(string value)
    {
        VA_key_text.text = VA_key_text.text + value;
    }

    public void AddOne(int value)
    {
        int key = 1;
        switch (value)
        {
            case 1:
                one = one + key;
                one_text.text = one.ToString();
                break;
            case 2:
                two = two + key;
                two_text.text = two.ToString();
                break;
            case 3:
                three = three + key;
                three_text.text = three.ToString();
                break;
            case 4:
                four = four + key;
                four_text.text = four.ToString();
                break;
            case 5:
                five = five + key;
                five_text.text = five.ToString();
                break;
            case 6:
                six = six + key;
                six_text.text = six.ToString();
                break;
            case 7:
                seven = seven + key;
                seven_text.text = seven.ToString();
                break;
            case 8:
                eight = eight + key;
                eight_text.text = eight.ToString();
                break;
            case 9:
                nine = nine + key;
                nine_text.text = nine.ToString();
                break;
            default:
                Debug.Log("Error AddOne");
                break;
        }
    }

    public void MinOne(int value)
    {
        int key = 1;
        switch (value)
        {
            case 1:
                one = one - key;
                one_text.text = one.ToString();
                break;
            case 2:
                two = two - key;
                two_text.text = two.ToString();
                break;
            case 3:
                three = three - key;
                three_text.text = three.ToString();
                break;
            case 4:
                four = four - key;
                four_text.text = four.ToString();
                break;
            case 5:
                five = five - key;
                five_text.text = five.ToString();
                break;
            case 6:
                six = six - key;
                six_text.text = six.ToString();
                break;
            case 7:
                seven = seven - key;
                seven_text.text = seven.ToString();
                break;
            case 8:
                eight = eight - key;
                eight_text.text = eight.ToString();
                break;
            case 9:
                nine = nine - key;
                nine_text.text = nine.ToString();
                break;
            default:
                Debug.Log("Error MinOne");
                break;
        }
    }

    public void ShiftEncryption(int key)
    {
        i = 0;
        string word = subject_text.text;
        char[] myWord = word.ToCharArray();
        char[] temp = word.ToCharArray();
        word = "";
        foreach (char ch in temp)
        {
            if (ch == ' ')
            {
                word += " "; 
                continue;
            }
            else
            {
                int index = ((int)ch % 32) - 1;
                int encrypt = ((index + key) % 26 + 26) % 26;
                temp[i] = alphabet[encrypt];
            }
            word += Char.ToString(temp[i]); 
            i = i + 1;
        }
        shift_text.text = word;
    }

    public void ShiftDecryption(int key)
    {
        i = 0;
        string word = shift_text.text;
        char[] myWord = word.ToCharArray();
        char[] temp = word.ToCharArray();
        word = "";
        foreach (char ch in temp)
        {
            if (ch == ' ')
            {
                word += " "; 
                continue;
            }
            else
            {
                int index = ((int)ch % 32) - 1;
                int encrypt = ((index - key) % 26 + 26) % 26;
                temp[i] = alphabet[encrypt];
            }
            word += Char.ToString(temp[i]); 
            i = i + 1;
        }
        shift_text.text = word;
    }

    public void ShiftDecryption1(int key)
    {
        i = 0;
        string word = subject_text.text;
        char[] myWord = word.ToCharArray();
        char[] temp = word.ToCharArray();
        word = "";
        foreach (char ch in temp)
        {
            if (ch == ' ')
            {
                word += " "; 
                continue;
            }
            else
            {
                int index = ((int)ch % 32) - 1;
                int encrypt = ((index - key) % 26 + 26) % 26;
                temp[i] = alphabet[encrypt];
            }
            word += Char.ToString(temp[i]); 
            i = i + 1;
        }
        shift_text.text = word;
    }

    public void VigenereEncryption()
    {
        i = 0;
        string word = subject_text.text;
        string key1 = VA_key_text.text;
        char[] temp = word.ToCharArray();
        string new_one = "";
        foreach(char ch in word)
        {
            if(i > (key1.Length - 1))
            {
                i = 0;
            }
            new_one += key1[i];
            i = i + 1;
        }
        key1 = new_one;
        word = "";
        i = 0;
        foreach (char ch in key1)
        {
            int index = ((int)ch % 32) + ((int)temp[i] % 32) - 1;
            int encrypt = ((index) % 26 + 26) % 26;
            temp[i] = alphabet[encrypt];
            
            word += Char.ToString(temp[i]); 
            i = i + 1;
        }
        // char[] tempkey = key1.ToCharArray();
        // for(int i = 0; i < temp.Length; i++) {
        //     int ascii = (int)temp[i] + (int)tempkey[i%tempkey.Length] - 65;
        //     temp[i] = (char)ascii;
        // }
        // word = new string(temp);
        VA_e_text.text = word;
    }

    public void VigenereDecryption()
    {
        i = 0;
        string word = VA_e_text.text;
        string key1 = VA_key_text.text;
        char[] temp = word.ToCharArray();
        string new_one = "";
        foreach(char ch in word)
        {
            if(i > (key1.Length - 1))
            {
                i = 0;
            }
            new_one += key1[i];
            i = i + 1;
        }
        key1 = new_one;
        word = "";
        i = 0;
        foreach (char ch in key1)
        {
            int index = ((int)temp[i] % 32) - ((int)ch % 32) - 1;
            int encrypt = ((index) % 26 + 26) % 26;
            temp[i] = alphabet[encrypt];
            
            word += Char.ToString(temp[i]); 
            i = i + 1;
        }
        VA_e_text.text = word;
    }

    public void VigenereDecryption1()
    {
        i = 0;
        string word = subject_text.text;
        string key1 = VA_key_text.text;
        char[] temp = word.ToCharArray();
        string new_one = "";
        foreach(char ch in word)
        {
            if(i > (key1.Length - 1))
            {
                i = 0;
            }
            new_one += key1[i];
            i = i + 1;
        }
        key1 = new_one;
        word = "";
        i = 0;
        foreach (char ch in key1)
        {
            int index = ((int)temp[i] % 32) - ((int)ch % 32) - 1;
            int encrypt = ((index) % 26 + 26) % 26;
            temp[i] = alphabet[encrypt];
            
            word += Char.ToString(temp[i]); 
            i = i + 1;
        }
        VA_d_text.text = word;
    }

    public void AutokeyEncryption()
    {
        i = 0;
        string word = subject_text.text;
        string key1 = VA_key_text.text;
        char[] temp = word.ToCharArray();
        string new_one = key1 + word.Substring(0, word.Length - key1.Length);
        key1 = new_one;
        word = "";
        i = 0;
        foreach (char ch in key1)
        {
            int index = ((int)ch % 32) + ((int)temp[i] % 32) - 1;
            int encrypt = ((index) % 26 + 26) % 26;
            temp[i] = alphabet[encrypt];
            
            word += Char.ToString(temp[i]); 
            i = i + 1;
        }
        VA_e_text.text = word;
    }

    public void AutokeyDecryption()
    {
        i = 0;
        string word = VA_e_text.text;
        string key1 = VA_key_text.text;
        char[] temp = word.ToCharArray();
        word = subject_text.text;
        string new_one = key1 + word.Substring(0, word.Length - key1.Length);
        key1 = new_one;
        word = "";
        i = 0;
        foreach (char ch in key1)
        {
            int index = ((int)temp[i] % 32) - ((int)ch % 32) - 1;
            int encrypt = ((index) % 26 + 26) % 26;
            temp[i] = alphabet[encrypt];
            
            word += Char.ToString(temp[i]); 
            i = i + 1;
        }
        VA_e_text.text = word;
    }

    public void AffineEncryption(int key)
    {
        i = 0;
        string word = subject_text.text;
        char[] myWord = word.ToCharArray();
        char[] temp = word.ToCharArray();
        word = "";
        foreach(char ch in temp)
        {
            if (ch == ' ')
            {
                word += " "; 
                continue;
            }
            else
            {
                int index = ((int)ch % 32) - 1;
                int encrypt = (((key * index) + key1) % 26 + 26) % 26;
                temp[i] = alphabet[encrypt];
            }
            word += Char.ToString(temp[i]); 
            i = i + 1;
        }
        affine_text.text = word;
    }

    public void AffineDecryption(int key)
    {
        i = 0;
        string word = affine_text.text;
        char[] myWord = word.ToCharArray();
        char[] temp = word.ToCharArray();
        word = "";
        int k = 0;
        for (int j = 1; j < 26; j++)
            if (((key % 26) * (j % 26)) % 26 == 1)
            	k = j;
        foreach(char ch in temp)
        {
            if (ch == ' ')
            {
                word += " "; 
                continue;
            }
            else
            {
                int index = ((int)ch % 32) - 1;
                int encrypt = ((k * (index - key1)) % 26 + 26) % 26;
                temp[i] = alphabet[encrypt];
            }
            word += Char.ToString(temp[i]); 
            i = i + 1;
        }
        affine_text.text = word;
    }
    public void AffineDecryption1(int key)
    {
        i = 0;
        string word = subject_text.text;
        char[] myWord = word.ToCharArray();
        char[] temp = word.ToCharArray();
        word = "";
        int k = 0;
        for (int j = 1; j < 26; j++)
            if (((key % 26) * (j % 26)) % 26 == 1)
            	k = j;
        foreach(char ch in temp)
        {
            if (ch == ' ')
            {
                word += " "; 
                continue;
            }
            else
            {
                int index = ((int)ch % 32) - 1;
                int encrypt = ((k * (index - key1)) % 26 + 26) % 26;
                temp[i] = alphabet[encrypt];
            }
            word += Char.ToString(temp[i]); 
            i = i + 1;
        }
        affine_text.text = word;
    }

    public void HillEncryption()
    {
        i = 0;
        string word = subject_text.text;
        char[] myWord = word.ToCharArray();
        char[] temp = word.ToCharArray();
        word = "";
        int[,] arr1 = {
        {one, two, three},
        {four, five, six},
        {seven, eight, nine}
        };
        int[,] letter = new int[3,3];
        foreach (char ch in myWord)
        {
            int index = 0;
            for (int j = 0; j < 3; j++)
            {
                index = ((int)ch % 32) - 1;
                letter[i, j] = index * arr1[i, j];
            }
            i = i + 1;
        }
        for (i = 0; i < 3; i++)
        {
            int encrypt = ((letter[0, i] + letter[1, i] + letter[2, i]) % 26 + 26) % 26;
            Console.WriteLine(encrypt);
            temp[i] = alphabet[encrypt];
            word = word + Char.ToString(temp[i]);
        }
        hill_text.text = word;
    }

    public void HillDecryption()
    {
        i = 0;
        string word = hill_text.text;
        char[] myWord = word.ToCharArray();
        char[] temp = word.ToCharArray();
        word = "";
        int[,] arr1 = {
        {one, two, three},
        {four, five, six},
        {seven, eight, nine}
        };
        int det = 0;
        for(i=0;i<3;i++)
        {
            det = det + (arr1[0,i]*(arr1[1,(i+1)%3]*arr1[2,(i+2)%3] - arr1[1,(i+2)%3]*arr1[2,(i+1)%3]));
        }
        int k = 0;
        for (int j = 1; j < 26; j++)
                if (((det % 26) * (j % 26)) % 26 == 1)
                    k = j;
        int[,] result = new int[3,3];
        for(i=0;i<3;i++){
            for(int j=0;j<3;j++)
                result[i,j] = (arr1[(i+1)%3,(j+1)%3] * arr1[(i+2)%3,(j+2)%3]) - (arr1[(i+1)%3,(j+2)%3]*arr1[(i+2)%3,(j+1)%3]);
        }
        for(i = 0; i < 3; i++)
        {
            int index = 0;
            int x = 0;
            for(int j = 0; j < 3; j++)
            {
                index = ((int)temp[j] % 32) - 1;
                x = x + (index * result[i, j]);
            }
            int encrypt = ((x * k) % 26 + 26) % 26;
            myWord[i] = alphabet[encrypt];
            word = word + Char.ToString(myWord[i]);
        }
        hill_text.text = word;
    }

    public void HillDecryption1()
    {
        i = 0;
        string word = subject_text.text;
        char[] myWord = word.ToCharArray();
        char[] temp = word.ToCharArray();
        word = "";
        int[,] arr1 = {
        {one, two, three},
        {four, five, six},
        {seven, eight, nine}
        };
        int det = 0;
        for(i=0;i<3;i++)
        {
            det = det + (arr1[0,i]*(arr1[1,(i+1)%3]*arr1[2,(i+2)%3] - arr1[1,(i+2)%3]*arr1[2,(i+1)%3]));
        }
        int k = 0;
        for (int j = 1; j < 26; j++)
                if (((det % 26) * (j % 26)) % 26 == 1)
                    k = j;
        int[,] result = new int[3,3];
        for(i=0;i<3;i++){
            for(int j=0;j<3;j++)
                result[i,j] = (arr1[(i+1)%3,(j+1)%3] * arr1[(i+2)%3,(j+2)%3]) - (arr1[(i+1)%3,(j+2)%3]*arr1[(i+2)%3,(j+1)%3]);
        }
        for(i = 0; i < 3; i++)
        {
            int index = 0;
            int x = 0;
            for(int j = 0; j < 3; j++)
            {
                index = ((int)temp[j] % 32) - 1;
                x = x + (index * result[i, j]);
            }
            int encrypt = ((x * k) % 26 + 26) % 26;
            myWord[i] = alphabet[encrypt];
            word = word + Char.ToString(myWord[i]);
        }
        hillD_text.text = word;
    }

    public void SubtituteEncryption()
    {
        i = 0;
        string word = subject_text.text;
        char[] myWord = word.ToCharArray();
        char[] temp = word.ToCharArray();
        word = "";
        foreach(char ch in temp)
        {
            if (ch == ' ')
            {
                word += " "; 
                continue;
            }
            else
            {
                int index = ((int)ch % 32) - 1;
                temp[i] = subtitute[index];
                // temp[i] = sub_encryption[ch];
            }
            word += Char.ToString(temp[i]); 
            i = i + 1;
        }
        subtitute_text.text = word;
    }

    public void SubtituteDecryption()
    {
        i = 0;
        string word = subtitute_text.text;
        char[] myWord = word.ToCharArray();
        char[] temp = word.ToCharArray();
        word = "";
        foreach(char ch in temp)
        {
            int index = 0;
            if (ch == ' ')
            {
                word += " "; 
                continue;
            }
            else
            {
                for(int x = 0; x < 26; x++)
                {
                    if(ch == subtitute[x])
                    {
                        index = x;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                temp[i] = alphabet[index];
                // temp[i] = sub_decryption[ch];
            }
            word += Char.ToString(temp[i]); 
            i = i + 1;
        }
        subtitute_text.text = word;
    }
    public void SubtituteDecryption1()
    {
        // var sub_decryption = new Dictionary<char, char>()
        // {
        //     {'X','A'},
        //     {'N','B'},
        //     {'Y','C'},
        //     {'A','D'},
        //     {'H','E'},
        //     {'P','F'},
        //     {'O','G'},
        //     {'G','H'},
        //     {'Z','I'},
        //     {'Q','J'},
        //     {'W','K'},
        //     {'B','L'},
        //     {'T','M'},
        //     {'S','N'},
        //     {'F','O'},
        //     {'L','P'},
        //     {'R','Q'},
        //     {'C','R'},
        //     {'V','S'},
        //     {'M','T'},
        //     {'U','U'},
        //     {'E','V'},
        //     {'K','W'},
        //     {'J','X'},
        //     {'D','Y'},
        //     {'I','Z'}
        // };
        i = 0;
        string word = subject_text.text;
        char[] myWord = word.ToCharArray();
        char[] temp = word.ToCharArray();
        word = "";
        foreach(char ch in temp)
        {
            int index = 0;
            if (ch == ' ')
            {
                word += " "; 
                continue;
            }
            else
            {
                for(int x = 0; x < 26; x++)
                {
                    if(ch == subtitute[x])
                    {
                        index = x;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                temp[i] = alphabet[index];
                // temp[i] = sub_decryption[ch];
            }
            word += Char.ToString(temp[i]); 
            i = i + 1;
        }
        subtitute_text.text = word;
    }

    public void ClearSubject()
    {
        subject_text.text = "";
        shift_text.text = "";
        affine_text.text = "";
        subtitute_text.text = "";
        hill_text.text = "";
        hillD_text.text = "";
    }

    public void ClearVASubject()
    {
        VA_key_text.text = "";
        VA_e_text.text = "";
        VA_d_text.text = "";
    }
}
