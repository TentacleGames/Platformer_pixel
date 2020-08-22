using System;
using UnityEngine;
 
public class homework : MonoBehaviour
{
    //don't forget to redifine this
    public double square_side = 12f;
    public double rect_side_a = 11.8f;
    public double rect_side_b = 14.53f;
    public double circle_radius = 16.321f;
 
    void Start()
    {
        
        string msg;
 
        double square_area = Math.Pow(square_side, 2);
        msg = string.Format("Area of square with side {0,12:F2} is {1,12:F2}", square_side, square_area);
        Debug.Log(msg);
 
        double rect_area = rect_side_a * rect_side_b;
        msg = string.Format("Area of rectangle with sides {0,12:F2} and {1,12:F2} is {2,12:F2}", rect_side_a, rect_side_b, rect_area);
        Debug.Log(msg);
 
        double circle_area = Math.PI * Math.Pow(circle_radius, 2);
        msg = string.Format("Area of circle with radius {0,12:F2} is {1,12:F2}", circle_radius, circle_area);
        Debug.Log(msg);
        
    }
 
}