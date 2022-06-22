using ViewWPF.baza;

namespace ViewWPF.DAL
{
    class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        private readonly PrzychodniaLekarskaEntities context;

        private Singleton()
        {
            context = new PrzychodniaLekarskaEntities();
        }

        public static Singleton Instance
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
