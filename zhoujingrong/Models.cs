using System.Collections.Generic;

namespace choices
{
    public class Album
    {
        public string Name;
        public List<Photo> Photos;

        public Album(string name, List<Photo> photos)
        {
            Name = name;
            Photos = photos;
        }
    }

    public class Photo
    {
        public string ImagePath;
        public string Description;
        public string Title;
        public Photo(string path, string title, string desc)
        {
            ImagePath = path;
            Description = desc;
            Title = title;
        }
    }
}