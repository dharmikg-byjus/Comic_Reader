using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoBook : MonoBehaviour
{
    public Animator bookAnim;
    public List<PageSound> pageSounds;
    public Button btn_StartRead;
    public AudioSource ads_Dialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action_GotoBook()
    {
        btn_StartRead.gameObject.SetActive(false);
        bookAnim.Play("CameraAnimation");
    }
    public void Action_Play_Dialog(int index=0)
    {
        StartCoroutine(dialog_play(index));
    }

    IEnumerator dialog_play(int pageindex)
    {
        for (int i = 0; i < pageSounds[pageindex].dialog.Count; i++)
        {
            ads_Dialog.clip = pageSounds[pageindex].dialog[i];
            ads_Dialog.Play();
            yield return new WaitForSeconds(pageSounds[pageindex].dialog[i].length);
            yield return new WaitForSeconds(5);
        }
        yield return null;
    }
    IEnumerator AfterPlayed(AudioSource audioSource, System.Action action)
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        action();
    }
}
[System.Serializable]
public class PageSound
{
    public List<AudioClip> dialog;
}