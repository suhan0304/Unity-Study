using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Memory {
    public static long size = 0; // 메모리 사용량

    public static void Print() {
        Debug.Log("총 메모리 사용량 : " + Memory.size + "MB");
    }
}

// ConcreteFlyweight - 플라이웨이트 객체는 불변성을 가져야 한다. 변경되면 모든 것에 영향을 준다.
public sealed class TreeModel
{
    // 메시, 텍스쳐 총 사이즈 (메모리 사용 크기)
    private readonly long objSize = 90; // 90MB

    // 불변 필드
    private readonly string type; // 나무 종류
    private readonly Mesh mesh; // 메쉬
    private readonly Texture2D texture; // 나무 껍질 + 잎사귀 텍스쳐

    // 생성자
    public TreeModel(string type, Mesh mesh, Texture2D texture)
    {
        this.type = type;
        this.mesh = mesh;
        this.texture = texture;

        // 나무 객체를 생성하여 메모리에 적재했으니 메모리 사용 크기 증가
        Memory.size += this.objSize;
    }
}

// UnsahredConcreteFlyweight
public class DefaultTree
{
    // 좌표값과 나무 모델 참조 객체 크기를 합친 사이즈
    private readonly long objSize = 10; // 10MB

    // 위치 변수
    public readonly double position_x;
    public readonly double position_y;

    // 나무 모델
    public readonly TreeModel model;

    // 생성자
    public DefaultTree(TreeModel model, double position_x, double position_y)
    {
        this.model = model;
        this.position_x = position_x;
        this.position_y = position_y;

        // 나무 객체를 생성하였으니 메모리 사용 크기 증가
        Memory.size += this.objSize;
    }

    // 나무의 위치 정보와 모델을 출력하기 위한 메서드
    public void Render()
    {
        Debug.Log("x: " + position_x + " y: " + position_y + " 위치에 " + model.GetType() + " 나무 생성 완료");
    }
}

// FlyweightFactory
public static class TreeModelFactory
{
    // Flyweight Pool - TreeModel 객체들을 Dictionary로 등록하여 캐싱
    private static readonly Dictionary<string, TreeModel> cache = new Dictionary<string, TreeModel>(); // Thread-Safe

    // static factory method
    public static TreeModel GetInstance(string key)
    {
        // 캐시되어 있다면 반환
        if (cache.ContainsKey(key))
        {
            return cache[key];
        }
        else
        {
            // 캐시되어 있지 않으면 나무 모델 객체를 새로 생성
            TreeModel model = new TreeModel(
                key,
                new Mesh(),     // Unity에서 사용할 실제 Mesh
                new Texture2D(1, 1) // Unity에서 사용할 실제 Texture
            );

            Debug.Log("-- 나무 모델 객체 새로 생성 완료 --");

            // 캐시에 적재
            cache[key] = model;

            return model;
        }
    }
}

// user
public class Terrain : MonoBehaviour
{
    // 지형 타일 크기
    public const int CANVAS_SIZE = 10000;

    // 나무를 렌더링하는 메서드
    public void Render(string type, float positionX, float positionY)
    {
        // 1. 캐시되어 있는 나무 모델 객체 가져오기
        TreeModel model = TreeModelFactory.GetInstance(type);

        // 2. 재사용한 나무 모델 객체와 변화하는 속성인 좌표값으로 나무 생성
        DefaultTree tree = new DefaultTree(model, positionX, positionY);

        Debug.Log($"x: {tree.position_x} y: {tree.position_y} 위치에 {type} 나무 생성 완료");
    }
}

public class Flyweight : MonoBehaviour
{
     private Terrain terrain;

    void Start()
    {
        // 지형 생성
        terrain = new Terrain();

        // 지형에 Oak 나무 5 그루 생성
        for (int i = 0; i < 5; i++)
        {
            terrain.Render(
                "Oak", // type
                Random.Range(0, Terrain.CANVAS_SIZE), // position_x
                Random.Range(0, Terrain.CANVAS_SIZE)  // position_y
            );
        }

        // 지형에 Acacia 나무 5 그루 생성
        for (int i = 0; i < 5; i++)
        {
            terrain.Render(
                "Acacia", // type
                Random.Range(0, Terrain.CANVAS_SIZE), // position_x
                Random.Range(0, Terrain.CANVAS_SIZE)  // position_y
            );
        }

        // 지형에 Jungle 나무 5 그루 생성
        for (int i = 0; i < 5; i++)
        {
            terrain.Render(
                "Jungle", // type
                Random.Range(0, Terrain.CANVAS_SIZE), // position_x
                Random.Range(0, Terrain.CANVAS_SIZE)  // position_y
            );
        }

        // 총 메모리 사용률 출력
        Memory.Print();
    }
}
