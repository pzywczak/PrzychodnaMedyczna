using ViewWPF.baza;

namespace ViewWPF.Class
{
    class Singel
    {
        private static readonly Singel instance = new Singel();
        private readonly PrzychodniaLekarskaEntities3 context;

        private Singel()
        {
            context = new PrzychodniaLekarskaEntities3();
        }

        public static Singel Instance
        {
            get
            {
                return instance;
            }
        }

        public PrzychodniaLekarskaEntities3 Context
        {
            get
            {
                return context;
            }
        }        
    }
}
