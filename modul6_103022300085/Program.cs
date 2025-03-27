using System;
using System.Collections.Generic;

public class SayaTubeVideo {
    private int id;
    private string title;
    private int playCount;
    public string Title { get { return title; } }
    public SayaTubeVideo(string title) {
        if (string.IsNullOrEmpty(title) || title.Length > 200) {
            throw new ArgumentException("Judul tidak boleh Kosong dan maksimal adalah 200 kata");
        }
        Random randomNumber = new Random();
        this.id = randomNumber.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void increasePlayCount(int count) {
        if (count > 25000000) {
            throw new ArgumentException("Playcount tidak boleh melebihi 25.000.000");
        }
        try {
            checked {
                this.playCount += count;
            }
        }
        catch {
            Console.WriteLine("Play count max");
        }
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
        if (string.IsNullOrEmpty(username) || username.Length > 100)
        {
            throw new ArgumentException("Usernmae tidak boleh Kosong dan maksimal adalah 100 kata");
        }
        Random randomNumber = new Random();
        this.id = randomNumber.Next(10000, 99999);
        this.username = username;
        this.UploadedVideos = new List<SayaTubeVideo>();
    }

    public void AddVideo(SayaTubeVideo video) {
        if (video == null) {
            throw new AbandonedMutexException("Video tidak boleh null");
    }
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
    }
}

