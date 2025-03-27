using System;
using System.Collections.Generic;

public class SayaTubeVideo {
    private int id;
    private string title;
    private int playCount;
    public string Title { get { return title; } }
    public SayaTubeVideo(string title) { 
        Random randomNumber = new Random();
        this.id = randomNumber.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void increasePlayCount(int count) {
        playCount += count;
    }

    public void printVideoDetails() {
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Title : " + title);
        Console.WriteLine("Play Count : " + playCount);
    }

    public int getPlayCount() { 
        return playCount;
    }
}

public class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> UploadedVideos;
    private string username;

    public SayaTubeUser(string username) {
        Random randomNumber = new Random();
        this.id = randomNumber.Next(10000, 99999);
        this.username = username;
        this.UploadedVideos = new List<SayaTubeVideo>();
    }

    public void AddVideo(SayaTubeVideo video) {
        UploadedVideos.Add(video);
    }

    public int GetTotalVideoPlayCount() { 
        int total = 0;
        foreach (var video in UploadedVideos){
            total += video.getPlayCount();
        }
        return total;
    }

    public void PrintAllVideoPlayCount() { 
        Console.WriteLine("User: " + username);
        for (int i = 0; i < UploadedVideos.Count; i++) {
            Console.WriteLine("Video " + (i + 1) + " " + UploadedVideos[i].Title);
        }
    }
}

public class Program {
    public static void Main() {
        SayaTubeUser user = new SayaTubeUser("Devon Arya Daniswara");

        for (int i = 1; i <= 10; i++) {
            SayaTubeVideo video = new SayaTubeVideo("Review Film " + i + " Oleh Devon Arya Daniswara");
            user.AddVideo(video);
        }
        user.PrintAllVideoPlayCount();

        Console.WriteLine("Hello world");
    }
}

