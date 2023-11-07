using System.Threading.Channels;

namespace Client_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MunicipalitesClient mc = new MunicipalitesClient();

            Task<ICollection<MunicipaliteModel>> getTask = mc.GetAllAsync();
            getTask.Wait();

            List<MunicipaliteModel> listMuni = getTask.Result.ToList();
            MunicipaliteModel model = listMuni.Where(m => m.NomMunicipalite == "Quebecq").SingleOrDefault();

            ModifierNomMunicipalite(model.codeGeographique, "Québec");

            listMuni.ForEach(m => Console.WriteLine(m.NomMunicipalite));

        }

        public static IEnumerable<MunicipaliteModel> genererListeMunicipalite()
        {
            MunicipalitesClient mc = new MunicipalitesClient();

            Task<ICollection<MunicipaliteModel>> getTask = mc.GetAllAsync();
            getTask.Wait();

            return getTask.Result.ToList();
        }

        public static void ModifierNomMunicipalite(int p_id, string p_nomMuni)
        {
            MunicipalitesClient mc = new MunicipalitesClient();
            Task<MunicipaliteModel> getTask = mc.GetAsync(p_id);
            getTask.Wait();

            MunicipaliteModel muni = getTask.Result;
            muni.NomMunicipalite = p_nomMuni;

            mc.PutAsync(muni.codeGeographique, muni);
        }
    }
}