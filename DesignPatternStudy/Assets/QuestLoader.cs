using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

enum QuestLevel
 {
     LEVEL10,
     LEVEL20,
     LEVEL30
 }

class Quest
{
    private string questName;
    private string questDescription;
    private QuestLevel questLevel;

    public Quest(string questName, QuestLevel questLevel)
    {
        this.questName = questName;
        this.questLevel = questLevel;
    }

    public string GetQuestName()
    {
        return questName;
    }

    public QuestLevel GetQuestLevel()
    {
        return questLevel;
    }

    public string GetInfo()
    {
        return "Display : " + GetQuestName() + " Quest information";
    }
}

class PrintQuestInfo
{
    private int userLevel;

    public PrintQuestInfo(int userLevel)
    {
        this.userLevel = userLevel;
    }

    public void PrintAllQuests(List<Quest> quests)
    {
        quests.ForEach(quest => Debug.Log(quest.GetInfo()));
    }
}

public class QuestLoader : MonoBehaviour
{
    void Start()
    {
        Quest gatherHerbs = new Quest("Gather Healing Herbs", QuestLevel.LEVEL10);
        Quest defendVillage = new Quest("Defend the Village", QuestLevel.LEVEL10);
        Quest huntBoars = new Quest("Hunt Wild Boars", QuestLevel.LEVEL20);
        Quest rescueCaptives = new Quest("Rescue the Captives", QuestLevel.LEVEL20);
        Quest slayDragon = new Quest("Slay the Fire Dragon", QuestLevel.LEVEL30);
        Quest retrieveArtifact = new Quest("Retrieve the Lost Artifact", QuestLevel.LEVEL30);

        List<Quest> quests = new List <Quest>
        {
            gatherHerbs, defendVillage, huntBoars, rescueCaptives, slayDragon, retrieveArtifact
        };
        
        /*--------------------------------------------------*/

        PrintQuestInfo view = new PrintQuestInfo(10);
        view.PrintAllQuests(quests);
    }
}
