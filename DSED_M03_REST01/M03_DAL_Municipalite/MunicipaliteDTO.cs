using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M03_Svr_Municipalite;

namespace M03_DAL_Municipalite
{
    public class MunicipaliteDTO
    {
        [Key]
        [Column("id")]
        public int MunicipaliteID { get; set; }
        public string NomMunicipalite { get; set; }
        public string? AdresseCourriel { get; set; }
        public string? AdresseWeb { get; set; }
        public DateTime? DateProchaineElection { get; set; }
        public MunicipaliteDTO()
        {

        }
        public MunicipaliteDTO(Municipalite p_municipalite)
        {
            MunicipaliteID = p_municipalite.CodeGeographique;
            NomMunicipalite = p_municipalite.NomMunicipalite;
            AdresseCourriel = p_municipalite.AdresseCourriel;
            AdresseWeb = p_municipalite.AdresseWeb;
            DateProchaineElection = p_municipalite.DateProchaineElection;
        }

        public MunicipaliteDTO(int municipaliteID, string nomMunicipalite, string? adresseCourriel, string? adresseWeb, DateTime? dateProchaineElection)
        {
            MunicipaliteID = municipaliteID;
            NomMunicipalite = nomMunicipalite;
            AdresseCourriel = adresseCourriel;
            AdresseWeb = adresseWeb;
            DateProchaineElection = dateProchaineElection;
        }

        public Municipalite VersEntite()
        {
            return new Municipalite(MunicipaliteID, NomMunicipalite, AdresseCourriel, AdresseWeb, DateProchaineElection);
        }
    }
}
