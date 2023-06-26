using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDelay : MonoBehaviour
{
    public float DelayTime;
    public float BeatTempo;
    public bool Left;
    public bool Right;
    public bool LeftUp;
    public bool LeftDown;
    public bool RightUp;
    public bool RightDown;
    private float SideTempo;
    private float Tempo;
    private float SideSpeed;

    void Start()
    {
        SideSpeed = BeatTempo + 50f;
        SideTempo = SideSpeed / 60f;
        Tempo = ((SideSpeed * 70) /100 ) / 60f;
    }

    void Update()
    {   
        if (Left == true) {
            // Invoke("DelayNoteDown", DelayTime);
            this.Wait(DelayTime, DelayNoteLeft);
        } else if (Right == true) {
            // Invoke("DelayNoteUp", DelayTime);
            this.Wait(DelayTime, DelayNoteRight);
        } else if (LeftUp == true) {
            // Invoke("DelayNoteLeftUp", DelayTime);
            this.Wait(DelayTime, DelayNoteLeftUp);
        } else if (LeftDown == true) {
            // Invoke("DelayNoteLeftDown", DelayTime);
            this.Wait(DelayTime, DelayNoteLeftDown);
        } else if (RightUp == true) {
            // Invoke("DelayNoteRightUp", DelayTime);
            this.Wait(DelayTime, DelayNoteRightUp);
        } else if (RightDown == true) {
            // Invoke("DelayNoteRightDown", DelayTime);
            this.Wait(DelayTime, DelayNoteRightDown);
        }
    }

    void DelayNoteLeft() {
        transform.position -= new Vector3(Tempo * Time.deltaTime, 0f, 0f);  
    }

    void DelayNoteRight() {
        transform.position += new Vector3(Tempo * Time.deltaTime, 0f, 0f);
    }

    void DelayNoteLeftUp() {
        transform.position -= new Vector3((Tempo * Time.deltaTime), -(Tempo * Time.deltaTime), 0f);
    }

    void DelayNoteLeftDown() {
        transform.position += new Vector3(-(Tempo * Time.deltaTime), -(Tempo * Time.deltaTime), 0f);
    }
    
    void DelayNoteRightUp() {
        transform.position -= new Vector3(-(Tempo * Time.deltaTime), -(Tempo * Time.deltaTime), 0f);
    }

    void DelayNoteRightDown() {
        transform.position += new Vector3((Tempo * Time.deltaTime), -(Tempo * Time.deltaTime), 0f);
    }
}
