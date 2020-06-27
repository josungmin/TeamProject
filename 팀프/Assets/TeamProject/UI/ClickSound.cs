using System.Collections;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour
{

    public AudioClip sound;
    private Button NEWGAME { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

        NEWGAME.onClick.AddListener(() => PlaySound());
    }


    // Update is called once per frame
    void PlaySound()
    {
        source.PlayOneShot(sound);
    }
}
