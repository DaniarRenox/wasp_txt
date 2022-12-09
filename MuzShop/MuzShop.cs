using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace mainfile
{
    interface IStoreItem
    {
        double Price { get; set; }
        void DiscountPrice(int percent)
        {
            Price = Price / 100 * percent;
        }
    }

    public class Disk : IStoreItem//DiscountPrice реализован по умолчанию
    {
        private string _name;
        private string _genre;
        private int _burnCount;

        public virtual int DiskSize { get; set; }
        public double Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Disk(string name, string genre)
        {
            _name = name;
            _genre = genre;
        }
        public virtual void Burn(params string[] size)
        {
        }

    }
    public class Audio : Disk
    {
        private string _name;
        private string _genre;
        private int _burnCount=0;
        private string _artist;
        private string _recordingStudio;
        private int _songNumber;
        public Audio(string artist, string recordingStudio, int songNumber, string name, string genre) : base(name, genre)
        {
            _name = name;
            _genre = genre;
            _artist = artist;
            _recordingStudio = recordingStudio;
            _songNumber = songNumber;

        }
        public override int DiskSize
        {
            get { return _songNumber * 8; }//??????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????????//
        }
        public override void Burn(params string[] size)
        {
            _artist = size[0];
            _recordingStudio = size[1];
            _songNumber = Convert.ToInt32(size[2]);
            _name = size[3];
            _genre = size[4];
            _burnCount += 1;
            ////Переопределить метод ToString, чтобы он выводил данные о диске в
            //следующем формате: название, жанр, исполнитель, студия звукозаписи,
            //количество песен, количество прожигов.

        }
        public override string ToString()
        {
            return $"name is: {_name}\n genre is: {_genre}\n artist is: {_artist}\n recording studio is: {_recordingStudio} \n songNumber is: {_songNumber}\n burns amount is: {_burnCount}\n";
        }
    }
    public class DVD : Disk
    {
        public string _name { get; set; }
        private string _genre;
        private string _producer;
        private string _filmCompany;
        private int _minutesCount;
        private int _burnCount;
        public DVD(string producer,string filmCompany, int minutesCount, string name, string genre) : base(name, genre)
        {
            _name = name;
            _genre = genre;
            _producer= producer;
            _filmCompany = filmCompany;
            _minutesCount = minutesCount;
        }
        public override int DiskSize
        {
            get
            {
                return (_minutesCount / 64) * 2;
            }
        }
        public override void Burn(params string[] size)
        {
            _producer= size[0];
            _filmCompany = size[1];
            _minutesCount = Convert.ToInt32(size[2]);
            _name = size[3];
            _genre= size[4];
            _burnCount += 1;
        }
        ////название, жанр, режиссер, кинокомпания, количество
        //минут, количество прожигов.

        public override string ToString()
        {
            return $"name = {_name}\n genre = {_genre}\n producer ={_producer}\n film company = {_filmCompany}\n amount of minutes = {_minutesCount} \n burns amount = {_burnCount} \n";
        }
    }
    public class Store
    {
        private string _StoreName;
        private string _StoreAdress;
        public List<Audio> _Audios = new List<Audio>();
        public List<DVD> _Dvds = new List<DVD>();
        public Store(string storeName, string storeAdress)
        {
            
            _StoreName = storeName;
            _StoreAdress = storeAdress;
        }
        public static List<Audio> operator +(Store audios, Audio audio)
        {
            if (audio is null)
            {
                throw new ArgumentNullException(nameof(audio));
            }
            audios._Audios.Add(audio);
            return audios._Audios;
        }
        public static List<Audio> operator -(Store audios, Audio audio)
        {
            if (audios._Audios.Contains(audio))
            {
                audios._Audios.Remove(audio);
            }
            return audios._Audios;
        }
        public static List<DVD> operator +(Store dvds, DVD dvd)
        {
            if (dvd is null) { throw new ArgumentNullException(nameof(dvd));}
            dvds._Dvds.Add(dvd);
            return dvds._Dvds;
        }
        public static List<DVD> operator -(Store dvds, DVD dvd)
        {
            if (dvds._Dvds.Contains(dvd))
            {
                dvds._Dvds.Remove(dvd);
            }
            return dvds._Dvds;
        }
        public override string ToString()
        {
            return $"films: {_Audios}\ndisks: {_Dvds}";
        }
    }
}
