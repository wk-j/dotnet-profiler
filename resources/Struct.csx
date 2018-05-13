using System;

class __Class {
    //int a;
}

struct __Struct {
    //int a;
}

class A {
    public static void Main(String[] args) {
        var s = new __Struct();
        var y = new __Class();
        Console.WriteLine($"{s} {y}");
    }
}