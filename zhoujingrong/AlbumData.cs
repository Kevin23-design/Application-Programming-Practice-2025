using choices;
using System.Collections.Generic;

namespace ImageViewer
{
    public static class AlbumData
    {
        public static readonly Album[] AllAlbums = new Album[]
        {

            new Album("Alpha", new List<Photo>
                {
                    new Photo("../../../images/jane.jpg", "Jane Crocker","Maid of Life"),
                    new Photo("../../../images/jake.jpg", "Jake English","Page of Hope"),
                    new Photo("../../../images/kankri.jpg", "Kankri Vantas","walalalalala"),
                    new Photo("../../../images/latula.jpg", "Latula Pyrope","rad girl")
                }),
            new Album("Beta", new List<Photo>
                {
                    new Photo("../../../images/john.jpg", "John Egbert","Heir of Breath"),
                    new Photo("../../../images/jade.jpg", "Jade Harley","Witch of Space"),
                    new Photo("../../../images/karkat.jpg", "Karkat Vantas","Knight of Blood"),
                    new Photo("../../../images/terezi.jpg", "Terezi Pyrope","Seer of Mind"),
                    new Photo("../../../images/aradia.jpg", "Aradia Megido","Maid of Time"),
                    new Photo("../../../images/nepeta.jpg", "Nepeta Leijon","Rouge of Heart"),
                    new Photo("../../../images/sollux.jpg", "Sollux Captor","Mage of Doom"),
                    new Photo("../../../images/kanaya.jpg", "Kanaya Maryam","Sylph of space"),
                    new Photo("../../../images/tavros.jpg", "Tavros Nitram","Page of Breath"),
                })
        };
    }
}
