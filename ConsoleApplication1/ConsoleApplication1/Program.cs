// Movies class which contains the list of Movie objects

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

private object textBox_XmlFileName;

public class Movies
{
    public List<Movie> movieList = new List<Movie>();

}

//Movie class
public class Movie
{

    public string Title
    { get; set; }


    public int Rating
    { get; set; }


    public DateTime ReleaseDate
    { get; set; }

}

public class XmlHandler
{
}

private void CreateXml_Click(object sender, EventArgs e)
{
    string filePath = path + textBox_XmlFileName.Text + ".xml";

    Movie firstMov = new Movie();
    firstMov.Title = "Shrek";
    firstMov.Rating = 2;
    firstMov.ReleaseDate = DateTime.Now;

    Movie secondMov = new Movie();
    secondMov.Title = "Spider Man";
    secondMov.Rating = 4;
    secondMov.ReleaseDate = DateTime.Now;

    Movies moviesObj = new Movies();
    moviesObj.movieList.Add(firstMov);
    moviesObj.movieList.Add(secondMov);
    List<Movie> movList = new List<Movie>() { firstMov, secondMov };

    XmlHandler.SerializeToXml(moviesObj.movieList, filePath);

}

// The static class and funcion that creates the xml file 
public static void SerializeToXml(List<Movie> movies, string filePath)
{
    XmlSerializer xls = new XmlSerializer(typeof(List<Movie>));

    TextWriter tw = new StreamWriter(filePath);
    xls.Serialize(tw, movies);
    tw.Close();
}
