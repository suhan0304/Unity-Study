using UnityEngine;
using System.Text;

public class Data
{
    private string name;
    private int age;

    public Data(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public string GetName()
    {
        return name;
    }

    public int GetAge()
    {
        return age;
    }
}

public abstract class Builder
{
    // 상속한 자식 클래스에서 사용하도록 protected 접근제어자 지정
    protected Data data;

    public Builder(Data data)
    {
        this.data = data;
    }

    // Data 객체의 데이터들을 원하는 형태의 문자열 포맷을 해주는 메서드들 (머리 - 중간 - 끝 형식)
    public abstract string Head();
    public abstract string Body();
    public abstract string Foot();
}

// Data 데이터를 평범한 문자열로 변환해주는 빌더
public class PlainTextBuilder : Builder
{
    public PlainTextBuilder(Data data) : base(data) { }

    public override string Head()
    {
        return "";
    }

    public override string Body()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Name: ");
        sb.Append(data.GetName());
        sb.Append(", Age: ");
        sb.Append(data.GetAge());
        return sb.ToString();
    }

    public override string Foot()
    {
        return "";
    }
}

// Data 데이터를 JSON 형태로 변환해주는 빌더
public class JSONBuilder : Builder
{
    public JSONBuilder(Data data) : base(data) { }

    public override string Head()
    {
        return "{\n";
    }

    public override string Body()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("\t\"Name\" : ");
        sb.Append("\"" + data.GetName() + "\",\n");
        sb.Append("\t\"Age\" : ");
        sb.Append(data.GetAge());
        return sb.ToString();
    }

    public override string Foot()
    {
        return "\n}";
    }
}

// Data 데이터를 XML 형태로 변환해주는 빌더
public class XMLBuilder : Builder
{
    public XMLBuilder(Data data) : base(data) { }

    public override string Head()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>\n");
        sb.Append("<DATA>\n");
        return sb.ToString();
    }

    public override string Body()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("\t<NAME>");
        sb.Append(data.GetName());
        sb.Append("</NAME>\n");
        sb.Append("\t<AGE>");
        sb.Append(data.GetAge());
        sb.Append("</AGE>");
        return sb.ToString();
    }

    public override string Foot()
    {
        return "\n</DATA>";
    }
}

// 각 문자열 포맷 빌드 과정을 템플릿화 시킨 디렉터
public class Director
{
    private Builder builder;

    public Director(Builder builder)
    {
        this.builder = builder;
    }

    // 빌드 템플릿 메서드
    public string Build()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(builder.Head());
        sb.Append(builder.Body());
        sb.Append(builder.Foot());
        return sb.ToString();
    }
}

public class DirectorBuilder : MonoBehaviour
{
    void Start()
    {
        // 1. Data 객체 생성
        Data data = new Data("홍길동", 44);

        // 2. 일반 텍스트로 포맷하여 출력하기
        Builder plainTextBuilder = new PlainTextBuilder(data);
        Director plainTextDirector = new Director(plainTextBuilder);
        string plainTextResult = plainTextDirector.Build();
        Debug.Log(plainTextResult);

        // 3. JSON 형식으로 포맷하여 출력하기
        Builder jsonBuilder = new JSONBuilder(data);
        Director jsonDirector = new Director(jsonBuilder);
        string jsonResult = jsonDirector.Build();
        Debug.Log(jsonResult);

        // 4. XML 형식으로 포맷하여 출력하기
        Builder xmlBuilder = new XMLBuilder(data);
        Director xmlDirector = new Director(xmlBuilder);
        string xmlResult = xmlDirector.Build();
        Debug.Log(xmlResult);
    }
}
