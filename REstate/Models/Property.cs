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
        [Display(Name ="Post Privee")]
        public bool PrivatePost { get; set; }
        [Required]
        [Display(Name ="Titre")]
        public string Title { get; set; }
        [Display(Name ="Type De Propriete")]
        public PropertyType propertyType { get; set; }

        [Required]
        [Display(Name ="Nbr/Num D'Etages")]
        public int Etages { get; set; }
        [Display(Name ="Type D'Annonce")]
        public SaleType SaleType { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateAdded { get; set; }
        [Required]
        [Display(Name ="Prix")]
        public double Price { get; set; }
        [Display(Name = "Montant du prix")]
        public PriceAmmount PriceAmmount { get; set; }
        [Display(Name = "Duree du paiement")]
        public PaymentDuration PaymentDuration{ get; set; }
        [Display(Name = "Nombre De Chambres")]
        [Required]
        public int Bedrooms { get; set; }
        [Display(Name = "Nombre De Salle de bains")]
        public int Bathrooms { get; set; }
        [Display(Name = "Nombre De Toilet")]
        public int WashRooms { get; set; }
        [Required]
        [Display(Name = "Superficie")]
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
        [Display(Name = "Image Principale")]
        public string MainThumbnail { get; set; }

        [NotMapped]
        public IFormFile ThumbnailFile{ get; set; }
        public List<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();
    }

    public enum PropertyType
    {
        All,
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
        PayementUneFois,
        PayementParTranches
    }

    public enum SaleType
    {
        All,
        vente,
        location
    }
}
