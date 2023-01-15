using UnityEngine;
using UnityEngine.UI;

public class BuzzerManager : MonoBehaviour
{
    public Text timer_text;
    public Text score_text;
    public Buzzer[] buzzers;
    public AudioSource wrongBuzzerSound;
    public AudioSource goodBuzzerSound;
    public AudioSource tickingSound;

    private const int game_duration = 30;
    private int elapsed_time = 0;
    private float game_started_at = 0;
    private int lighted_buzzer = -1;
    private int score = 0;
    private bool game_is_running = false;
    private System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        score_text.text = score.ToString() + " pts";
        timer_text.text = game_duration + " sec";
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time - game_started_at > elapsed_time)
        {
            elapsed_time += 1;
            if (game_is_running)
            {
                tickingSound.Play();
                int time_left = game_duration - elapsed_time;
                if (time_left == 0)
                {
                    game_is_running = false;
                    buzzers[lighted_buzzer].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                    timer_text.text = "partie terminée".ToUpper();
                }
                else
                {
                    if (time_left <= 10)
                        timer_text.color = Color.red;
                    else if (time_left <= 20)
                        timer_text.color = new Color(1, 0.5f, 0);
                    string time_left_string = time_left + " sec";
                    while (time_left_string.Length < 6)
                        time_left_string = " " + time_left_string;
                    timer_text.text = time_left_string;
                }
            }
        }
    }
    public void BuzzerClick(int id)
    {
        Debug.Log("BuzzerManager : received click from " + id);
        if (game_is_running && id == lighted_buzzer)
        {
            goodBuzzerSound.Play();
            score += 1;
            score_text.text = score.ToString() + " pts";
            ChangeBuzzer();
        }
        else
        {
            wrongBuzzerSound.Play();
        }
    }

    public void StartGame()
    {
        game_is_running = false;
        if (buzzers.Length == 0)
        {
            Debug.LogWarning("Aucun buzzer n'est connecté.");
            return;
        }
        game_started_at = Time.time + 1;
        elapsed_time = 0;
        score = 0;
        score_text.text = score.ToString() + " pts";
        timer_text.text = game_duration + " sec";
        if (lighted_buzzer != -1)
            buzzers[lighted_buzzer].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        for (int i = 0; i < buzzers.Length; i++)
            buzzers[i].Init(this, i);
        lighted_buzzer = rand.Next(0, buzzers.Length);
        buzzers[lighted_buzzer].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        game_is_running = true;
    }

    void ChangeBuzzer()
    {
        if (buzzers.Length > 0)
        {
            buzzers[lighted_buzzer].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            int new_buzzer = rand.Next(0, buzzers.Length);
            while (lighted_buzzer == new_buzzer && buzzers.Length > 1)
                new_buzzer = rand.Next(0, buzzers.Length);
            lighted_buzzer = new_buzzer;
            buzzers[lighted_buzzer].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
    }
}
