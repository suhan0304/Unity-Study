using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class Hamburger {
    // 필수 매개변수
    private int bun;
    private int patty;

    // 선택 매개변수
    private int cheese;
    private int lettuce;
    private int tomato;
    private int bacon;

    public Hamburger(int bun, int patty, int cheese, int lettuce, int tomato, int bacon) {
        this.bun = bun;
        this.patty = patty;
        this.cheese = cheese;
        this.lettuce = lettuce;
        this.tomato = tomato;
        this.bacon = bacon;
    }

    public Hamburger(int bun, int patty, int cheese, int lettuce, int tomato) {
        this.bun = bun;
        this.patty = patty;
        this.cheese = cheese;
        this.lettuce = lettuce;
        this.tomato = tomato;
    }
    

    public Hamburger(int bun, int patty, int cheese, int lettuce) {
        this.bun = bun;
        this.patty = patty;
        this.cheese = cheese;
        this.lettuce = lettuce;
    }

    public Hamburger(int bun, int patty, int cheese) {
        this.bun = bun;
        this.patty = patty;
        this.cheese = cheese;
    }
}
public class Builder : MonoBehaviour
{
    void Start()
    {
        // 모든 재료가 있는 햄버거
        Hamburger hamburger1 = new Hamburger(2, 1, 2, 4, 6, 8);

        // 빵과 패티 치즈만 있는 햄버거
        Hamburger hamburger2 = new Hamburger(2, 1, 1);

        // 빵과 패티 베이컨만 있는 햄버거
        Hamburger hamburger3 = new Hamburger(2, 0, 0, 0, 0, 6);
    }
}
