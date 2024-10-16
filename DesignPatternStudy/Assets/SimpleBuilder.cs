using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NPC
{
    // 불변 객체 필드들 (readonly 키워드로 불변 설정)
    private readonly string name;
    private readonly int level;
    private readonly string race;
    private readonly string gender;
    private readonly string job;

    // 정적 내부 빌더 클래스
    public class Builder
    {
        // 필수 파라미터 
        internal readonly string name;   //이름
        internal readonly int level;     //레벨

        // 선택 파라미터
        internal string race;   // 종족
        internal string gender; // 성별
        internal string job;    // 직업

        // 빌더의 필수 파라미터는 생성자로 받는다
        public Builder(string name, int level)
        {
            this.name = name;
            this.level = level;
        }

        // 선택 파라미터 메서드
        public Builder Race(string race)
        {
            this.race = race;
            return this;
        }

        public Builder Gender(string gender)
        {
            this.gender = gender;
            return this;
        }

        public Builder Job(string job)
        {
            this.job = job;
            return this;
        }

        // 최종적으로 NPC 객체를 생성하는 빌드 메서드
        public NPC Build()
        {
            return new NPC(this); // 빌더 객체를 넘겨 최종 NPC 생성
        }
    }

    // private 생성자 - 빌더 클래스에서만 호출 가능
    private NPC(Builder builder)
    {
        this.name = builder.name;
        this.level = builder.level;
        this.race = builder.race;
        this.gender = builder.gender;
        this.job = builder.job;
    }

    // NPC 객체 정보 출력
    public override string ToString()
    {
        return $"NPC {{ Name = {name}, Level = {level}, Race = {race}, Gender = {gender}, Job = {job} }}";
    }
}

public class SimpleBuilder : MonoBehaviour
{
    void Start()
    {
        // 빌더 패턴을 이용해 NPC 생성
        NPC npc = new NPC.Builder("마을촌장", 50)  // 필수 파라미터
            .Gender("man")                     // 선택 파라미터
            .Job("Villager")
            .Race("Human")
            .Build();                          // 최종 빌드

        Debug.Log(npc);  // NPC 정보 출력
    }
}
