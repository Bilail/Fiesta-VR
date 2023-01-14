using UnityEngine;
using UnityEngine.UI;

public class BuzzerManager : MonoBehaviour
{
    public Text timer_text;
    public Text score_text;
    public Buzzer[] buzzers;
    private int game_duration = 30;
    private int elapsed_time = 0;
    private int lighted_buzzer = -1;
    private int score = 0;
    private bool game_is_running = true;
    private System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        timer_text.text = game_duration + " sec";
        if (buzzers.Length == 0)
            Debug.LogWarning("Aucun buzzer n'est connecté.");
        else
        {
            for (int i = 0; i < buzzers.Length; i++)
                buzzers[i].init(this, i);
            lighted_buzzer = rand.Next(0, buzzers.Length);
            buzzers[lighted_buzzer].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > elapsed_time)
        {
            if (game_is_running)
            {
                int time_left = game_duration - elapsed_time;
                if (time_left == 0)
                {
                    game_is_running = false;
                    timer_text.text = "partie terminée".ToUpper();
                }
                else
                {
                    if (time_left <= 10)
                        timer_text.color = Color.red;
                    else if (time_left <= 20)
                        timer_text.color = new Color(1, 0.5f, 0);
                    elapsed_time += 1;
                    timer_text.text = game_duration - elapsed_time + " sec";
                }
            }
        }
    }
    public void buttonClicked(int id)
    {
        Debug.Log("BuzzerManager : received click from " + id);
        if (game_is_running && id == lighted_buzzer)
        {
            score += 1;
            score_text.text = score.ToString() + " pts";
            changeBuzzer();
        }
    }

    void changeBuzzer()
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
