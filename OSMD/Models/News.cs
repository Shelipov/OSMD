using System;

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace OSMD.Models
{
    //[Serializable]
    public class News
    {

        public int Id { get; set; }

        public string date { get; set; }
        public string news { get; set; }
        public string text { get; set; }
        public string _User { get; set; }
        public byte[] Avatar_News { get; set; }
        ////////// дибильно, я знаю - надо подумать как колекцию в бд передать целой (попробую сериализацию)
        public string Link1 { get; set; }
        public string Link2 { get; set; }
        public string Link3 { get; set; }
        public string Link4 { get; set; }
        public string Link5 { get; set; }
        public string Link6 { get; set; }
        public string Link7 { get; set; }
        public string Link8 { get; set; }
        public string Link9 { get; set; }
        public string Link10 { get; set; }
        ////////// дибильно, я знаю - надо подумать как колекцию в бд передать целой (попробую сериализацию)

    }
    //[DataContract]
    public class News_Foto
    {
        public int Id { get; set; }
       // [DataMember]
        //public List<string> Link { get; set; }

        //public ICollection<IFormFile> Foto_Stream { get; set; }
        public IFormFileCollection Foto_Stream { get; set; }
        

    }
    
}