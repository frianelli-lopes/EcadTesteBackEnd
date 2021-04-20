using EcadTeste.Infra.Data.Context;

namespace EcadTeste.Infra.Data.Seeds
{
    public static class SeedControl
    {
        public static void Seed(this EcadTesteContext context)
        {
            SeedGenero.Carregar(context);
            SeedCategoria.Carregar(context);
        }
    }
}
