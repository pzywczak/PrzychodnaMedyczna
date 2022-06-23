using ViewWPF.baza;

namespace ViewWPF.Class
{
    class Singel
    {
        private static readonly Singel instance = new Singel();
        private readonly PrzychodniaLekarskaEntities2 context;

        private Singel()
        {
            context = new PrzychodniaLekarskaEntities2();
        }

        public static Singel Instance
        {
            get
            {
                return instance;
            }
        }

        public PrzychodniaLekarskaEntities2 Context
        {
            get
            {
                return context;
            }
        }        
    }
}
