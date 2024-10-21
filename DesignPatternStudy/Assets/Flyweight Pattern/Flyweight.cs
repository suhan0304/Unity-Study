using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Memory {
    public static long size = 0; // 메모리 사용량

    public static void Print() {
        Debug.Log("총 메모리 사용량 : " + Memory.size + "MB");
    }
}

public class DefaultTree
{
    long objSize = 100; // 100MB

    string type; // 나무 종류
    Mesh mesh; // 메쉬
    Texture texture; // 나무 껍질 + 잎사귀 텍스쳐

    // 위치 변수
    public double position_x;
    public double position_y;

    // public 생성자
    public DefaultTree(string type, Mesh mesh, Texture texture, double position_x, double position_y)
    {
        this.type = type;
        this.mesh = mesh;
        this.texture = texture;
        this.position_x = position_x;
        this.position_y = position_y;

        // 나무 객체를 생성하였으니 메모리 사용 크기 증가
        Memory.size += this.objSize;
    }
}


// user
public class Terrain
{
    // 지형 타일 크기
    public static readonly int CANVAS_SIZE = 10000;

    // 나무를 렌더링
    public void Render(string type, Mesh mesh, Texture texture, double position_x, double position_y)
    {
        // Random 객체 생성
        System.Random rand = new System.Random();

        // 나무를 지형에 생성
        DefaultTree tree = new DefaultTree(
            type, // 나무 종류
            mesh, // mesh
            texture, // texture
            Random.Range(0, CANVAS_SIZE), // position_x
            Random.Range(0, CANVAS_SIZE)  // position_y
        );

        Debug.Log("x:" + tree.position_x + " y:" + tree.position_y + " 위치에 " + type + " 나무 생성 완료");
    }
}

public class Flyweight : MonoBehaviour
{
    void Start()
    {
        // 지형 생성
        Terrain terrain = new Terrain();

        // 지형에 Oak 나무 5 그루 생성
        for (int i = 0; i < 5; i++)
        {
            terrain.Render(
                "Oak", // type
                new Mesh(), // mesh
                new Texture2D(256, 256), // texture
                Random.Range(0, Terrain.CANVAS_SIZE), // position_x
                Random.Range(0, Terrain.CANVAS_SIZE)  // position_y
            );
        }

        // 지형에 Acacia 나무 5 그루 생성
        for (int i = 0; i < 5; i++)
        {
            terrain.Render(
                "Acacia", // type
                new Mesh(), // mesh
                new Texture2D(256, 256), // texture
                Random.Range(0, Terrain.CANVAS_SIZE), // position_x
                Random.Range(0, Terrain.CANVAS_SIZE)  // position_y
            );
        }

        // 지형에 Jungle 나무 5 그루 생성
        for (int i = 0; i < 5; i++)
        {
            terrain.Render(
                "Jungle", // type
                new Mesh(), // mesh
                new Texture2D(256, 256), // texture
                Random.Range(0, Terrain.CANVAS_SIZE), // position_x
                Random.Range(0, Terrain.CANVAS_SIZE)  // position_y
            );
        }

        // 총 메모리 사용률 출력
        Memory.Print();
    }
}
