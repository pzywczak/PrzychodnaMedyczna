using ViewWPF.baza;

namespace ViewWPF.DAL
{
    class Singel
    {
        private static readonly Singel instance = new Singel();
        private readonly PrzychodniaLekarskaEntities context;

        private Singel()
        {
            context = new PrzychodniaLekarskaEntities();
        }

        public static Singel Instance
        {
            get
            {
                return instance;
            }
        }

        public PrzychodniaLekarskaEntities Context
        {
            get
            {
                return context;
            }
        }        
    }
}
