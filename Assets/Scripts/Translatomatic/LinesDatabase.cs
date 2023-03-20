using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesDatabase : MonoBehaviour
{

    [SerializeField] private List<SpokenLines> languageList = new List<SpokenLines>();
    private int linesSize = 0;

    public static LinesDatabase Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
            Instance = this;

        //Generate list of test languages until database can be implemented
        for (int i = 0; i < 6; i++)
        {
            languageList.Add(new SpokenLines(i));
            switch (i)
            {
                case 0:
                    {
                        languageList[i].Addline("This is English");
                        languageList[i].Addline("I would like a burger");
                        languageList[i].Addline("One evil Leo, please");

                        break;
                    }
                case 1:
                    {
                        languageList[i].Addline("hsilgnE si sihT");
                        languageList[i].Addline("regrub a ekil dluow I");
                        languageList[i].Addline("esaelp ,oeL live enO");

                        break;
                    }
                case 2:
                    {
                        languageList[i].Addline("beep deet doot doot");
                        languageList[i].Addline("fizz buzz bleep bloop");
                        languageList[i].Addline("oel ole eol elo");

                        break;
                    }
                case 3:
                    {
                        languageList[i].Addline("Hista sia NglishEa");
                        languageList[i].Addline("Ia ouldwa ikela aa urgerba");
                        languageList[i].Addline("Neoa vilea Eola, leasepa");
                        break;
                    }
                case 4:
                    {
                        languageList[i].Addline("Questo è inglese");
                        languageList[i].Addline("Vorrei un hamburger");
                        languageList[i].Addline("Un Leone malvagio, per favore");
                        break;
                    }
                case 5:
                    {
                        languageList[i].Addline("Isso é inglês");
                        languageList[i].Addline("eu gostaria de um hamburguer");
                        languageList[i].Addline("Um Leo malvado, por favor");
                        break;
                    }
                default: break;

            }

        }
        linesSize = 3;
    }


    public string GetLine(int langID, int lineID)
    {
        return languageList[langID].GetLine(lineID);
    }

    public int GetLanguageSize()
    {
        return languageList.Count;
    }
    public int GetLineSize()
    {
        return linesSize;
    }

}
