using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotValue
{
    Gold,
    Seven,
    Strawberry,
    Cherry,
    Coin
}
public class Slot : MonoBehaviour
{

    private int randomValue;
    [HideInInspector]public float timeInterval;
    [HideInInspector] public SlotValue randItem;
    private float speed;
    public SlotValue stoppedSlot;
    private SlotMachine sm;

    private void Start()
    {
        sm = gameObject.GetComponentInParent<SlotMachine>();
    }
    public IEnumerator Spin()
    {
        timeInterval = sm.timeInterval;
        randomValue = Random.Range(0, 90);
        speed = 30f + randomValue;
        while(speed >= 10f)
        {
            speed = speed / 1.01f;
            transform.Translate(Vector2.up * Time.deltaTime * -speed);
            if (transform.localPosition.y <= -1394.48f)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, -1389.896f);
            }

            yield return new WaitForSeconds(timeInterval);
        }
        StartCoroutine("EndSpin");
        yield return null;
    }
    
    private IEnumerator EndSpin()
    {
        while (speed >= 2f)
        {
            if (transform.localPosition.y < -1393.54f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -1394.48f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -1394.48f))
                {
                    speed = 0;
                }
            }
            else if (transform.localPosition.y < -1392.63f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -1393.54f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -1393.54f))
                {
                    speed = 0;
                }
            }
            else if (transform.localPosition.y < -1391.73f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -1392.63f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -1392.63f))
                {
                    speed = 0;
                }
            }
            else if (transform.localPosition.y < -1390.83f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -1391.73f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -1391.73f))
                {
                    speed = 0;
                }
            }
            else if (transform.localPosition.y < -1389.896f)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, new Vector2(transform.localPosition.x, -1390.83f), speed * Time.deltaTime);
                if (new Vector2(transform.localPosition.x, transform.localPosition.y) == new Vector2(transform.localPosition.x, -1390.83f))
                {
                    speed = 0;
                }
            }
            speed = speed / 1.01f;
            yield return new WaitForSeconds(timeInterval);
        }
        speed = 0;
        CheckResults();
        yield return null;
    }
    private void CheckResults()
    {
        if (transform.localPosition.y == -1394.48f)
        {
            stoppedSlot = SlotValue.Gold;
        }
        else if (transform.localPosition.y == -1393.54f)
        {
            stoppedSlot = SlotValue.Seven;
        }
        else if (transform.localPosition.y == -1392.63f)
        {
            stoppedSlot = SlotValue.Strawberry;
        }
        else if (transform.localPosition.y == -1391.73f)
        {
            stoppedSlot = SlotValue.Cherry;
        }
        else if (transform.localPosition.y == -1390.83f)
        {
            stoppedSlot = SlotValue.Coin;
        }

        sm.WaitResults();
    }
}
