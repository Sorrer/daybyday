using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inboxMessage : MonoBehaviour
{
    public TextMeshProUGUI message;
    public TextMeshProUGUI response1, response2;
    public int dayShown, personShown;
    public string status;

    /*
    For simplicity:
    - Days are denoted as int 1-10 (eg. Day 1 is "1")
    - People are numbered in order of Inbox UI, as follows:

    1: Mom
    2: Grandma Betty
    3: Prof. Turner
    4: Buddy
    5: Brie
    6: Cuz Matt

    dayShown and personShown variables store last shown
    changeDay() and changePerson() if day or person changes, respectively

    Day changes daily, should be implemeneted in Tracking script
    Person changes when message is selected, implemented through Inbox buttons

    Status changes based on responses, implemented in-game and updated
    through updateStatus() method
    Status is: "isolated", "allResponse", or "noResponse"
    */

    void changeDay(int newDay) {
        dayShown = newDay;
        newMessage(dayShown, personShown, status);
        newResponse (dayShown, personShown);
    }
    void changePerson(int newPerson) {
        personShown = newPerson;
        newMessage(dayShown, personShown, status);
        newResponse (dayShown, personShown);
    }
    void updateStatus(string newStatus) {
        status = newStatus;
    }

    //START IS HERE FOR TESTING ONLY - remove later
    void Start() {
        // For testing purposes, fiddle with the values below
        newMessage(1, 1, "isolated");
    }

    void newMessage(int day, int person, string status) {
        if (person == 1) {
            message.text = "hello";
            if (day == 2) {
                message.text = "Sweetheart, Is Agenda helping you stay on track with your goals? I’ve heard so much about how it helped other students, and I thought it would be a good present for you, now that you are doing school from home. I’ve felt myself slipping lately - work isn’t what it used to be for me. I am finding my way through. In fact, I’ve taken up knitting. Would you like me to make you a scarf? I promise I can make it super fluffy and warm - just the way you like it. Love, Mom.";
            }
            if (day == 4) {
                message.text = "Sweetheart, remember the pair of bonsai plants we bought together? Mine finally bloomed! It’s so pretty and lush, I’m quite proud of how well I’ve taken care of it. I plan on decorating it for the winter holidays. How about yours? Have you watered it yet? I hope you are doing well and staying on top of your studies. I miss you. Love, Mom";
            }
            if (day == 7) {
                message.text = "Sweetheart, have you had any sweets lately? I’ve had such a craving for cake the past few weeks. Remember when I mentioned I wanted to get into baking? Well, I started baking banana bread. It’s healthy and super yummy, and I’m quite good at it! The trick is to use whole wheat flour and substitute white sugar for honey. Then you can make a delicious and mostly-healthy treat for just after supper. I would love to chat sometime soon. Maybe I can even bring you a loaf. Wouldn’t that be swell! Love, Mom.";
            }
            if (day == 9) {
                message.text = "Sweetheart, are you staying healthy? I had such a sweet tooth last month that by the end of it I felt like I could never have a treat again! I got myself a yoga mat and started working out. I feel a lot better. I meditate a few minutes every day, I do lots of stretching, and I go for long walks. You should try it sometime! Maybe it will help you relax after a hard day’s work. If you’d like, we could even meditate together! Let me know if you would like that, okay? Love, Mom.";
            }
            if (day == 10) {
                if (status == "allResponse") {
                    message.text = "Honey, I am so glad you’ve kept in touch. I know these past few months have been hard on you, it was hard on us, too. I really miss you. Let me know if I can come visit you. I promise to bring you a treat! Love, Mom.";
                }
                if (status == "noResponse") {
                    message.text = "Honey, Are you okay? I haven’t heard from you lately. I guess Agenda is helping you stay very productive. Let me know if you need anything, okay? I miss you. Love, Mom";
                }
                if (status == "isolated") {
                    message.text = "Please let me know that you are okay. I love you so much. Stay safe. Love, Mom";
                }
            }
        }
    }
    void newResponse (int day, int person) {
        if (person == 1) {
            if (day == 2) {
                
            }
        }
    }
}
