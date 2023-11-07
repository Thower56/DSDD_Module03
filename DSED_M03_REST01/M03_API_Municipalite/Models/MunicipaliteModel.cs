using M03_Svr_Municipalite;

namespace M03_API_Municipalite.Models
{
    public class MunicipaliteModel
    {
        public int codeGeographique { get; set; }
        public string NomMunicipalite { get; set; }
        public string AdresseCourriel { get; set; }
        public string AdresseWeb { get; set; }
        public DateTime? DateProchaineElection { get; set; }
        public bool Actif { get; set; }

        public MunicipaliteModel()
        {

        }
        public MunicipaliteModel(Municipalite p_municipalite)
        {
            codeGeographique = p_municipalite.CodeGeographique;
            NomMunicipalite = p_municipalite.NomMunicipalite;
            AdresseCourriel = p_municipalite.AdresseCourriel;
            AdresseWeb = p_municipalite.AdresseWeb;
            DateProchaineElection = p_municipalite.DateProchaineElection;
            Actif = p_municipalite.Actif;
        }
        public Municipalite VersEntite()
        {
            return new Municipalite()
            {
                CodeGeographique = codeGeographique,
                NomMunicipalite = NomMunicipalite,
                AdresseCourriel = AdresseCourriel,
                AdresseWeb = AdresseWeb,
                DateProchaineElection = DateProchaineElection,
                Actif = Actif
            };
        }
    }
}
