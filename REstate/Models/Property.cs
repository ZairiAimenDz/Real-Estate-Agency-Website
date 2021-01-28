using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REstate.Models
{
    public class Property
    {
        [Key]
        public Guid ID { get; set; }
        public bool PrivatePost { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public int Etages { get; set; }
        public SaleType SaleType { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateAdded { get; set; }
        [Required]
        public double Price { get; set; }
        public PriceAmmount PriceAmmount { get; set; }
        public PaymentDuration PaymentDuration{ get; set; }
        [Required]
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int WashRooms { get; set; }
        [Required]
        public double Surface { get; set; }
        [Required]
        public string Adresse { get; set; }
        public bool Furniture { get; set; }
        public bool Jardain { get; set; }
        public bool TransportProche { get; set; }
        public bool Parking { get; set; }
        public bool Climatisation { get; set; }
        public bool ConnectionInternet { get; set; }
        public bool Security { get; set; }
        public bool Garage { get; set; }
        public bool Ascenceur { get; set; }
        public string MainThumbnail { get; set; }

        [NotMapped]
        public IFormFile ThumbnailFile{ get; set; }
        public List<PropertyImage> PropertyImages { get; set; }
    }

    public enum PropertyType
    {
        Villa,
        Appartement,
        LotdeTerrain,
        Carcasse,
        Duplex
    }

    public enum PriceAmmount
    {
        DA,
        MillionDA,
        MillardDA
    }
    public enum PaymentDuration
    {
        ParJour,
        ParMois,
        ParAnnee,
        UneFois,
        ParTranches
    }

    public enum SaleType
    {
        Sale,
        Rent
    }
}
