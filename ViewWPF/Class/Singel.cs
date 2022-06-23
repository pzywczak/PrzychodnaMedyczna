using ViewWPF.baza;

namespace ViewWPF.Class
{
    class Singel
    {
        private static readonly Singel instance = new Singel();
        private readonly PrzychodniaLekarskaEntities1 context;

        private Singel()
        {
            context = new PrzychodniaLekarskaEntities1();
        }

        public static Singel Instance
        {
            get
            {
                return instance;
            }
        }

        public PrzychodniaLekarskaEntities1 Context
        {
            get
            {
                return context;
            }
        }        
    }
}
