using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject camera;
    public float speed;
    bool isright = false;
    bool isleft = false;
    float x=0, y=0, z=0;
    float f = 0f;
    float k = 0f;
    float gran = 0f;
    bool isdown = false;
    bool isup = false;
    float grany = 0f;
    bool above = true;
    int j = 0;
    float zf = 0f;
    // Start is called before the first frame update
    void choosel()
    {
        gran = -90;
    }
    void chooser()
    {
        gran = 90;
    }
    void toup()
    {
        
       
        grany = -90;
    }
    void todown()
    {
        
        grany = 90;
    }
    void Start()
    {
        z = speed;
        x = 0;
        y = 0;
    }
    void Update()
    {
        z = speed;
        if (gran > 0)
        {
            gran -= 9;
            k += 9;
            camera.transform.rotation = Quaternion.Euler(f, k, zf);
            z = 0;
        }
        else if(gran < 0)
        {
            gran += 9;
            k -= 9;
            camera.transform.rotation = Quaternion.Euler(f, k, zf);
            z = 0;
        }
        if (grany > 0)
        {
            grany -= 9;
            f += 9;
            camera.transform.rotation = Quaternion.Euler(f, k, zf);
            z = 0;
        }
        else if (grany < 0)
        {
            grany += 9;
            f -= 9;
            camera.transform.rotation = Quaternion.Euler(f, k, zf);
            z = 0;
        }
        transform.Translate(x, y, z);
        Foo();
    }
    private IEnumerator Foo()
    {
        yield return new WaitForSeconds(0.1f);
    }


    public void tap()
    {
        if (isleft)
        {
            choosel();
        }
        if (isright)
        {
            chooser();
        }
        if (isdown)
        {
            todown();
        }
        if (isup)
        {
            toup();
        }
        if (!isleft && !isright && !isdown && !isup)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "left")
        {
            isleft = true;
        }
        if(collision.gameObject.tag == "right")
        {
            isright = true;
        }
        if(collision.gameObject.tag == "die")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if(collision.gameObject.tag == "down")
        {
            isdown = true;
        }
        if (collision.gameObject.tag == "up")
        {
            isup = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "left")
        {
            isleft = false;
        }
        if (collision.gameObject.tag == "right")
        {
            isright = false;
        }
        if (collision.gameObject.tag == "down")
        {
            isdown = false;
        }
        if (collision.gameObject.tag == "up")
        {
            isup = false;
        }
    }
}
