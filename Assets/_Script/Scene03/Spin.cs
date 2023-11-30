using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rotationSpeed = 45f;
    public Transform rot;
    public bool left;
    public bool right;

    // public void Left()
    // {
    //     bool left = true;
    // }
    // public void Right()
    // {
    //     bool right = true;
    // }

            // if(left == true)
        // {
        //     rot.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        // }
    void Update()
    {
        input();

        if(left == true)
        {
            rot.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if(right == true)
        {
            rot.Rotate(0, 0, rotationSpeed * -Time.deltaTime);
        }
    }
    void input()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            left = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            right = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
        }
    }
}
