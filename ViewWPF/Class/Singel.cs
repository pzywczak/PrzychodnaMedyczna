using ViewWPF.baza;

namespace ViewWPF.Class
{
    class Singel
    {
        private static readonly Singel instance = new Singel();
        private readonly PrzychodniaLekarskaEntities5 context;

        private Singel()
        {
            context = new PrzychodniaLekarskaEntities5();
        }

        public static Singel Instance
        {
            get
            {
                return instance;
            }
        }

        public PrzychodniaLekarskaEntities5 Context
        {
            get
            {
                return context;
            }
        }        
    }
}
