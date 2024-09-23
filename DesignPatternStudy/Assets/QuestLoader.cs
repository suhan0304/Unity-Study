using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;


public interface IQuest
{
    string GetQuestName();
    QuestLevel GetQuestLevel();
    string GetInfo(IQuest quest);
}

public enum QuestLevel
 {
     LEVEL10,
     LEVEL20,
     LEVEL30
 }

class Quest : IQuest
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

    public string GetInfo(IQuest quest)
    {
        return "Display : " + GetQuestName() + " Quest information";
    }
}

class PrintQuestInfo
{
    private IQuest viewer;

    public PrintQuestInfo(IQuest viewer)
    {
        this.viewer = viewer;
    }

    public void PrintAllQuests(List<IQuest> quests)
    {
        quests.ForEach(quest => Debug.Log(quest.GetInfo(viewer)));
    }
}

public class ProtectedQuest : IQuest
{
    private IQuest quest;

    public ProtectedQuest(IQuest quest) {
        this.quest = quest;
    }

    public string GetQuestName() {
        return this.quest.GetQuestName();
    }

    public QuestLevel GetQuestLevel() {
        return this.quest.GetQuestLevel();
    }

    public string GetInfo(IQuest viewer)
    {
        QuestLevel questLevel = this.quest.GetQuestLevel(); // 조회 당하는 퀘스트의 레벨 조건
        
        // 조회 유저의 레벨에 따라 출력을 제어
        switch (viewer.GetQuestLevel())
        {
            case QuestLevel.LEVEL30 :
                // 레벨 30은 모든 퀘스트 열람 가능하므로 바로 반환
                return this.quest.GetInfo(viewer);
            case QuestLevel.LEVEL20 :
                // 레벨 20은 30레벨 퀘스트를 볼 수 없음
                if (questLevel != QuestLevel.LEVEL30)
                {
                    return this.quest.GetInfo(viewer);
                }

                return "현재 레벨에는 공개되지 않는 퀘스트입니다.";
            case QuestLevel.LEVEL10 :     
                // 레벨 10은 20, 30레벨 퀘스트를 볼 수 없음
                if (questLevel != QuestLevel.LEVEL30 && questLevel != QuestLevel.LEVEL20)
                {
                    return this.quest.GetInfo(viewer);
                }

                return "현재 레벨에는 공개되지 않는 퀘스트입니다.";
            default :
                return "viewer 퀘스트 레벨을 확인해주세요.";
        }
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

        List<IQuest> protectedQuests = new List<IQuest>();
        foreach (Quest quest in quests)
        {
            protectedQuests.Add(new ProtectedQuest(quest));
        }

        Debug.Log("----- Level. 10 유저가 퀘스트 정보 조회 -----");
        PrintQuestInfo view = new PrintQuestInfo(new Quest("_user", QuestLevel.LEVEL10));
        view.PrintAllQuests(protectedQuests);
        Debug.Log("-----------------------------------------");

        Debug.Log("----- Level. 20 유저가 퀘스트 정보 조회 -----");
        view = new PrintQuestInfo(new Quest("_user", QuestLevel.LEVEL20));
        view.PrintAllQuests(protectedQuests);
        Debug.Log("-----------------------------------------");

        Debug.Log("----- Level. 30 유저가 퀘스트 정보 조회 -----");
        view = new PrintQuestInfo(new Quest("_user", QuestLevel.LEVEL30));
        view.PrintAllQuests(protectedQuests);
        Debug.Log("-----------------------------------------");
    }
}
